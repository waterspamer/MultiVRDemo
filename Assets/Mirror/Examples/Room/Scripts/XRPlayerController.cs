using Antilatency.SDK;
using UnityEngine;

namespace Mirror.Examples.Room.Scripts
{
    public class XRPlayerController : NetworkBehaviour
    {

        public AltTrackingDirect playerTracking; 
        // Start is called before the first frame update

    
    
        public override void OnStartLocalPlayer()
        {
            Camera.main.orthographic = false;
            Camera.main.transform.SetParent(transform);
            playerTracking = GameObject.Find("AltTrackingXr").GetComponent<AltTrackingDirect>();
            Camera.main.transform.localPosition = playerTracking.transform.position;
            Camera.main.transform.rotation = playerTracking.transform.rotation;

        }
    
    
        void OnValidate()
        {
            GetComponent<NetworkTransform>().clientAuthority = true;
        }
    
        void OnDisable()
        {
            if (isLocalPlayer && Camera.main != null)
            {
                Camera.main.orthographic = true;
                Camera.main.transform.SetParent(null);
                Camera.main.transform.localPosition = new Vector3(0f, 70f, 0f);
                Camera.main.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!isLocalPlayer)
                return;

            transform.position = playerTracking.transform.position;
            transform.rotation = playerTracking.transform.rotation;
        }
    }
}
