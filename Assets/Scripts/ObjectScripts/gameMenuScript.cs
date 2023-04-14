using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMenuScript : MonoBehaviour
{
    [SerializeField] private buttonsGameMenu getBool;
    private void Start()
    {
        getBool = FindObjectOfType<buttonsGameMenu>().GetComponent<buttonsGameMenu>();
    }
    public void pauseGame()
    {
            Time.timeScale=0f;
    }
    public void resumeGame()
    {
            Time.timeScale = 1f;
    }
}
