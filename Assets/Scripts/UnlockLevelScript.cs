using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockLevelScript : MonoBehaviour
{
   public void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentLevel);

        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }
        Debug.Log(PlayerPrefs.GetInt("levelsUnlocked"));
    }
}
