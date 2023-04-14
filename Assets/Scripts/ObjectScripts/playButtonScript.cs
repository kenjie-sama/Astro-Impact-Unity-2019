using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playButtonScript : MonoBehaviour
{
    public GameObject menuUIObject;
    public GameObject playUIObject;
    public void runPlayUITransistion()
    {
        Animator playMenuTransition = playUIObject.GetComponent<Animator>();
        Animator mainMenuTransition= menuUIObject.GetComponent<Animator>();
        if (mainMenuTransition != null && playMenuTransition!=null)
        {
            bool playUI = playMenuTransition.GetBool("isPlayed");
            bool menuUI = mainMenuTransition.GetBool("isPlayed");
            playMenuTransition.SetBool("isPlayed",!(playUI));
            mainMenuTransition.SetBool("isPlayed", !(menuUI));
        }
    }
}
