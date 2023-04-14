using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonsScriptMenuAndPlayUI : MonoBehaviour
{
    public GameObject playUIObject;
    public GameObject mainUIObject;
    public void reverseTransistion()
    {
        Animator playUIreverse = playUIObject.GetComponent<Animator>();
        Animator mainUIreverse = mainUIObject.GetComponent<Animator>();
        if (playUIreverse!=null && mainUIreverse!=null)
        {
            bool playUIBool = playUIreverse.GetBool("isPlayed");
            bool mainUIBool = mainUIreverse.GetBool("isPlayed");
            playUIreverse.SetBool("isPlayed",!(playUIBool));
            mainUIreverse.SetBool("isPlayed", !(mainUIBool));
        }
    }
}
