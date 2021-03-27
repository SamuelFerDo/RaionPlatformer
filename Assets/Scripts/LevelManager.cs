using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPoint;
    public Transform groundTrapRespawnPoint;
    public GameObject playerPrefab;
    public GameObject groundTrapPrefab;

    public CinemachineVirtualCameraBase cam;

    [Header("Oksigen")]
    [SerializeField] public float oksigenTime;
    public Text oksigemTimeUI;
    public int oksigenTimeInt;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (oksigenTimeInt <= 0)
        {
            Debug.Log("Kalah");
        }
        oksigenTime -= Time.deltaTime;
        oksigenTimeInt = (int)oksigenTime;
        oksigemTimeUI.text = " OKSIGEN " + oksigenTimeInt;
    }
    public void Respawn()
    {
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;
    }
    public void IncreaseOksigenTime(int amount)
    {
        oksigenTime += amount;
        oksigemTimeUI.text = " OKSIGEN " + oksigenTime;
    }
    public void GroundTrapRespawn()
    {
        GameObject groundTrap = Instantiate(groundTrapPrefab, groundTrapRespawnPoint.position, Quaternion.identity);
    }
}
