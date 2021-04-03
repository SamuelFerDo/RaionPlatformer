using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    int levelsUnlocked;

    public Button[] buttons;

    private void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }
        public void LoadLevel(int levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }
    public void resetPlayerPrefs()
    {
        buttons[1].interactable = false;
        buttons[2].interactable = false;
        PlayerPrefs.DeleteAll();
    }
}
