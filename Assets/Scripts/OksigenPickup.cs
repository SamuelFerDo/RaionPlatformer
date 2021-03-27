using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OksigenPickup : MonoBehaviour
{
    public int addTime = 60;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            LevelManager.instance.IncreaseOksigenTime(addTime);
        }
    }
}
