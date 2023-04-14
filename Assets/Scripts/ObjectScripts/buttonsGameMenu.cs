using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class buttonsGameMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject menuPanel;
    public GameObject menuButton;
    private void Start()
    {
        //menuBool = FindObjectOfType<gameMenuScript>().GetComponent<gameMenuScript>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            openGameMenu();
        }

    }
    void Resume()
    {
        //objects.gameObject.SetActive(true);
        //pauseMenuPanel.gameObject.SetActive(false);
        //yield return new WaitForSeconds(1f);
        StartCoroutine(delay());
        menuPanel.SetActive(false);
        menuButton.SetActive(true);
        Time.timeScale = 1;
        GamePaused = false;
        
        //objects.DOAnchorPos(new Vector2(0f, 0f), 0.8f).SetEase(Ease.OutCirc);
        //pauseMenuPanel.DOAnchorPos(new Vector2(-1927f, 0f), 0.8f).SetEase(Ease.OutCirc);
        //animate.SetBool("isPause", false);
        //animate.Play("resumeAnim");
        //menuBool.enabled = false;
        //menuBool.resumeGame();
        //menuBool.enabled = true;
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
    }
    void Pause()
    {

        //pauseMenuPanel.gameObject.SetActive(true);
        //objects.DOAnchorPos(new Vector2(1927f,0f),0.8f).SetEase(Ease.OutCirc);
        //pauseMenuPanel.DOAnchorPos(new Vector2(1f, 0f), 0.8f).SetEase(Ease.OutCirc);
        //objects.gameObject.SetActive(false);
        //menuBool.enabled = false;
        //animate.SetBool("isPause", true);
        //animate.Play("pauseAnim");
        //yield return new WaitForSeconds(1f);
        StartCoroutine(delay());
        menuPanel.SetActive(true);
        menuButton.SetActive(false);
        GamePaused = true;
        Time.timeScale = 0;
        //menuBool.enabled = true;
        //menuBool.pauseGame();
    }
    public void openGameMenu()
    {
        if (GamePaused == true)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    
}
