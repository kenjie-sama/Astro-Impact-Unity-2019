using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardButtonScript : MonoBehaviour
{
    public GameObject panelsObject;
    public static int dasboardNumber = 0;
    public float playbackSpeed;
    public void Dashboard()
    {
        Animator panelsTransition = panelsObject.GetComponent<Animator>();
        int panelNumber = panelsTransition.GetInteger("panelNumber");
        if (panelsTransition != null && panelNumber == 0)
        {
            panelsTransition.SetFloat("playback", playbackSpeed = -1f);
            panelsTransition.SetInteger("panelNumber", dasboardNumber);
        }
        if (panelsTransition!=null&& panelNumber==1)
        {
            panelsTransition.SetFloat("playback", playbackSpeed = -1f);
            panelsTransition.SetInteger("panelNumber", dasboardNumber);
        }
        if (panelsTransition != null && panelNumber == 2)
        {
            panelsTransition.SetFloat("playback", playbackSpeed = -1f);
            panelsTransition.SetInteger("panelNumber", dasboardNumber);
        }
        if (panelsTransition != null && panelNumber == 3)
        {
            panelsTransition.SetFloat("playback", playbackSpeed = -1f);
            panelsTransition.SetInteger("panelNumber", dasboardNumber);
        }
    }

}
