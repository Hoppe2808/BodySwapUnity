using Fusion;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnHost : NetworkBehaviour
{
    [SerializeField] NetworkObject player;
    [SerializeField] CameraController cam;
    [SerializeField] UIController uI;

    [Networked] private NetworkBool spawned { get; set; }

    private bool done;
    private NetworkObject hostPlayer;

    private void Update()
    {
        if (Runner != null && !done)
        {
            Spawn();
            spawned = true;
        }
    }

    public void Spawn()
    {
        //if (Runner.IsServer)
        PlayerController detectPlayer = FindObjectOfType<PlayerController>();
        if (Runner != null && detectPlayer == null && !spawned)
        {
            hostPlayer = Runner.Spawn(player, Vector3.zero, Quaternion.identity, Runner.LocalPlayer, onBeforeSpawned: null);
            spawned = true;
        }
        if (detectPlayer != null && spawned)
        {
            cam.FindTarget();
            uI.SetUI();
            done = true;
        }
    }

    public void SpawnClient(PlayerRef pRef)
    {
        Runner.Despawn(hostPlayer);

        PlayerController currentPlayer = FindObjectOfType<PlayerController>();
        currentPlayer.gameObject.SetActive(false);

        //Runner.Spawn(player, Vector3.zero, Quaternion.identity, pRef, onBeforeSpawned: null);
        cam.FindTarget();
    }
}
