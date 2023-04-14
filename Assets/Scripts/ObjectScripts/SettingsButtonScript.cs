using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonScript : MonoBehaviour
{
    public GameObject panelsObject;
    public static int settingsNumber = 3;
    public float playbackSpeed;
    public void Settings()
    {
        Animator panelsTransition = panelsObject.GetComponent<Animator>();
        int panelNumber = panelsTransition.GetInteger("panelNumber");
        if (panelsTransition != null && panelNumber == 0)
        {
            panelsTransition.SetFloat("playback", playbackSpeed = -1f);
            panelsTransition.SetInteger("panelNumber", settingsNumber);
        }
        if (panelsTransition != null && panelNumber == 1)
        {
            panelsTransition.SetFloat("playback", playbackSpeed = -1f);
            panelsTransition.SetInteger("panelNumber", settingsNumber);
        }
        if (panelsTransition != null && panelNumber == 2)
        {
            panelsTransition.SetFloat("playback", playbackSpeed = -1f);
            panelsTransition.SetInteger("panelNumber", settingsNumber);
        }
        if (panelsTransition != null && panelNumber == 3)
        {
            panelsTransition.SetFloat("playback", playbackSpeed = -1f);
            panelsTransition.SetInteger("panelNumber", settingsNumber);
        }
    }
}
