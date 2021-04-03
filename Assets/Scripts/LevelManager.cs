using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform groundTrapRespawnPoint1;
    public Transform groundTrapRespawnPoint2;
    public Transform groundTrapRespawnPoint3;
    public Transform groundTrapRespawnPoint4;
    public Transform groundTrapRespawnPoint5;
    public Transform groundTrapRespawnPoint6;
    public Transform groundTrapRespawnPoint7;
    public Transform groundTrapRespawnPoint8;
    public Transform groundTrapRespawnPoint9;
    public Transform groundTrapRespawnPoint10;
    public Transform groundTrapRespawnPoint11;

    public Transform respawnPoint;
    public GameObject playerPrefab;
    public GameObject groundTrapPrefab;

    public CinemachineVirtualCameraBase cam;

    [SerializeField] public float oksigenTime;
    public Text oksigemTimeUI;
    public int oksigenTimeInt;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        oksigenTime -= Time.deltaTime;
        oksigenTimeInt = (int)oksigenTime;
        oksigemTimeUI.text = " OKSIGEN " + oksigenTimeInt;
        if (oksigenTimeInt <= 0)
        {
            SceneManager.LoadScene(4);
        }
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
    public void GroundTrapRespawn1()
    {
        GameObject groundTrap = Instantiate(groundTrapPrefab, groundTrapRespawnPoint1.position, Quaternion.identity);
    }
    public void GroundTrapRespawn2()
    {
        GameObject groundTrap = Instantiate(groundTrapPrefab, groundTrapRespawnPoint2.position, Quaternion.identity);
    }
    public void GroundTrapRespawn3()
    {
        GameObject groundTrap = Instantiate(groundTrapPrefab, groundTrapRespawnPoint3.position, Quaternion.identity);
    }
    public void GroundTrapRespawn4()
    {
        GameObject groundTrap = Instantiate(groundTrapPrefab, groundTrapRespawnPoint4.position, Quaternion.identity);
    }
    public void GroundTrapRespawn5()
    {
        GameObject groundTrap = Instantiate(groundTrapPrefab, groundTrapRespawnPoint5.position, Quaternion.identity);
    }
    public void GroundTrapRespawn6()
    {
        GameObject groundTrap = Instantiate(groundTrapPrefab, groundTrapRespawnPoint6.position, Quaternion.identity);
    }
    public void GroundTrapRespawn7()
    {
        GameObject groundTrap = Instantiate(groundTrapPrefab, groundTrapRespawnPoint7.position, Quaternion.identity);
    }
    public void GroundTrapRespawn8()
    {
        GameObject groundTrap = Instantiate(groundTrapPrefab, groundTrapRespawnPoint8.position, Quaternion.identity);
    }
    public void GroundTrapRespawn9()
    {
        GameObject groundTrap = Instantiate(groundTrapPrefab, groundTrapRespawnPoint9.position, Quaternion.identity);
    }
    public void GroundTrapRespawn10()
    {
        GameObject groundTrap = Instantiate(groundTrapPrefab, groundTrapRespawnPoint10.position, Quaternion.identity);
    }
    public void GroundTrapRespawn11()
    {
        GameObject groundTrap = Instantiate(groundTrapPrefab, groundTrapRespawnPoint11.position, Quaternion.identity);
    }
}
