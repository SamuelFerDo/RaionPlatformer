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
            LevelManager.instance.GroundTrapRespawn1();
            LevelManager.instance.GroundTrapRespawn2();
            LevelManager.instance.GroundTrapRespawn3();
            LevelManager.instance.GroundTrapRespawn4();
            LevelManager.instance.GroundTrapRespawn5();
            LevelManager.instance.GroundTrapRespawn6();
            LevelManager.instance.GroundTrapRespawn7();
            LevelManager.instance.GroundTrapRespawn8();
            LevelManager.instance.GroundTrapRespawn9();
            LevelManager.instance.GroundTrapRespawn10();
            LevelManager.instance.GroundTrapRespawn11();
        }
    }
}
