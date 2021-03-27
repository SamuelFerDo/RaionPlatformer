using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            LevelManager.instance.Respawn();
            LevelManager.instance.GroundTrapRespawn();
        }
    }
}
