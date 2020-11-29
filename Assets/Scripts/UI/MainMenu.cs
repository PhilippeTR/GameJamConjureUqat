using System.Collections;
using System.Collections.Generic;
using Bytes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject _secondUI;
    public Scrollbar _difficultyScroll;

    public void FirstPlayButton()
    {
        gameObject.SetActive(false);
        _secondUI.SetActive(true);
    }

    public void SecondPlayButton()
    {
        SceneManager.LoadScene("Levels");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetDifficulty()
    {
        PlayerPrefs.SetInt("Difficulty", Mathf.RoundToInt(_difficultyScroll.value * 2));
        ;
    }
}
