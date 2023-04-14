using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverButtonScripts : MonoBehaviour
{
    [SerializeField] private slideInTransition slideTransition;
    public bool isGameRestart;
    public bool isGameOver;
    public void Awake()
    {
        isGameRestart = false;
    }
    public void toMainMenu()
    {
        Time.timeScale = 1;
        slideTransition.SlideInTransition();
        SceneManager.LoadScene(2);
    }
    public void toRestart()
    {
        Time.timeScale = 1;
        isGameRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
