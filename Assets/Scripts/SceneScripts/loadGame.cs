using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loadGame : MonoBehaviour
{
    [SerializeField] private BGMusicAstroRhythm avengersTheme;
    public void clickLoad()
    {
        StartCoroutine(loadCampaignMode());
    }
    IEnumerator loadCampaignMode()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
        avengersTheme = FindObjectOfType<BGMusicAstroRhythm>().GetComponent<BGMusicAstroRhythm>();
        Destroy(avengersTheme.gameObject);
    }
}
