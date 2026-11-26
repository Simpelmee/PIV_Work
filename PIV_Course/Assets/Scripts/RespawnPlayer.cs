using System;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject respawnPoint;

    public void Respawn()
    {
        player.transform.position = respawnPoint.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Respawn();
        }
    }
}
