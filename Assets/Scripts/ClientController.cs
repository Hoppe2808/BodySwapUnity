using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Udp;

public class ClientController : NetworkBehaviour {

    //[SerializeField] private UdpHost udp;
    private PlayerNetworkController playerNetwork;

    [Networked(OnChanged = nameof(UpdateMessage))] private string message { get; set; }

    public void Start() {
        //UdpHost.OnReceiveMsg += OnMotorValue;
        playerNetwork = FindObjectOfType<PlayerNetworkController>();
    }

    public static void UpdateMessage(Changed<ClientController> changed)
    {
        changed.Behaviour.UpdateMessage();   
    }

    public void UpdateMessage()
    {
        Debug.Log("THIS IS A TEST");
    }
/*
    private void OnMotorValue(string value)
    {
        if (Runner == null) return;
        if (IsMaster())
        {
            message = String.Copy(value);
            string[] values = value.Split(',');

            elbow.SetElbow(float.Parse(values[1]));
            client.SetMessage(message);
        }
    }*/
}
