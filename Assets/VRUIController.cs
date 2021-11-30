using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.Examples.Room.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class VRUIController : MonoBehaviour
{

    public InputField inputField;

    public Text actionButtonText;
    
    public NetworkManager manager;
    

    private void Start()
    {
        actionButtonText.text = NetworkConfigurator.isClient ? "Connect" : "Host";
        inputField.readOnly = !NetworkConfigurator.isClient;
        inputField.text = GetLocalIPAddress();
    }

    public void NetworkAction()
    {
        manager.networkAddress = inputField.text;
        if (!NetworkConfigurator.isClient) manager.StartHost();
        else manager.StartClient();
    }
    

    public void ToggleServerClient()
    {
        NetworkConfigurator.isClient = !NetworkConfigurator.isClient;
        actionButtonText.text = NetworkConfigurator.isClient ? "Connect" : "Host";
        inputField.readOnly = !NetworkConfigurator.isClient;

    }
    
    
    public static string GetLocalIPAddress()
    {
        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork &&
                ip.ToString().Contains("192.168")) 
            {
                return ip.ToString();
            }
        }

        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }
    
    

}
