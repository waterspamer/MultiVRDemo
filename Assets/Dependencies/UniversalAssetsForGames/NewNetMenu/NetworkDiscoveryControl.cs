using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public enum NetRole {
    None,
    Server,
    Client,
    Host
}

public class NetworkDiscoveryControl : MonoBehaviour {

    public OverriddenNetworkDiscovery OverriddenNetworkDiscovery;
    private NetworkManager _networkManager;
    public GameObject UiGameObject;
    [HideInInspector]
    //public NetRole NetRole;

    private static NetworkDiscoveryControl _instance;
    public static NetworkDiscoveryControl Instance {
        get {
            return _instance;
        }
    }

    void Awake() {
        if (_instance == null) {
            _instance = this;
        } else {
            Destroy(gameObject);
        }
        _networkManager = FindObjectOfType<NetworkManager>();
    }

    void Start() {
        ConnectButton.SetActive(false);
        NewGameButton.SetActive(false);
        SearchGameObject.SetActive(true);

        OverriddenNetworkDiscovery.Initialize();
        OverriddenNetworkDiscovery.StartAsClient();
    }

    public GameObject MenuGameObject;
    public GameObject NewGameButton;
    public GameObject ConnectButton;
    public GameObject SearchGameObject;
    private float ClientTryTimer;

    private float _broadcastWasReceivedTimer = 3f;
    void Update() {
        _broadcastWasReceivedTimer -= Time.deltaTime;
        if(_broadcastWasReceivedTimer > 0 && _broadcastWasReceivedTimer < 1f){
            ConnectButton.SetActive(false);
            NewGameButton.SetActive(false);
            SearchGameObject.SetActive(true);
        }
        if(_broadcastWasReceivedTimer <= 0){
            ConnectButton.SetActive(false);
            NewGameButton.SetActive(true);
            SearchGameObject.SetActive(false);
        }
    }

    private string _fromAddress;

    public void WhenReceivedBroadcast(string fromAddress, string data){
        Debug.Log("WhenReceivedBroadcast");
        _fromAddress = fromAddress;
        _broadcastWasReceivedTimer = 3f;
        ConnectButton.SetActive(true);
        NewGameButton.SetActive(false);
        SearchGameObject.SetActive(false);
    }

    public void Connect(){
        NetworkManager.singleton.networkAddress = _fromAddress;
        NetworkManager.singleton.StartClient();
        OverriddenNetworkDiscovery.StopBroadcast();
        HideUI();
    }

    public void GoAsHost() {
        Debug.Log("GoAsHost");
        OverriddenNetworkDiscovery.StopBroadcast();
        OverriddenNetworkDiscovery.Initialize();
        OverriddenNetworkDiscovery.StartAsServer();
        _networkManager.StartHost();
        HideUI();
    }
    
    //public FindBracer FindBracer;
    void HideUI(){
        //FindBracer.RemoveListener();
        this.enabled = false;
        Destroy(UiGameObject);
        //UiGameObject?.SetActive(false);
    }

}
