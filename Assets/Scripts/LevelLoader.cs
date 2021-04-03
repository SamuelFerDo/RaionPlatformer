using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] public int iLevelToLoad;
    [SerializeField] public string sLeveleToLoad;

    public bool useIntToLoadLevel = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.CompareTag("Player"))
        {
            LoadScene();
        }
    }
    void LoadScene()
    {
        if (useIntToLoadLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            Pass();
            SceneManager.LoadScene(sLeveleToLoad);
        }
    }
    public void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentLevel);

        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }
        //Debug.Log(PlayerPrefs.GetInt("levelsUnlocked"));
    }

}
