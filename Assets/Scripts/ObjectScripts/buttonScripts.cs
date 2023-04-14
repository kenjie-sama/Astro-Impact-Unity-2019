 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonScripts : MonoBehaviour
{
    public AudioSource ButtonSFX;
    public AudioClip hoverButtonSFX;
    public AudioClip clickButtonSFX;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
            ButtonSFX.PlayOneShot(clickButtonSFX);
        }
    }
    public void WhenMouseOver()
    {
        ButtonSFX.PlayOneShot(hoverButtonSFX);
    }
    public void WhenMouseClick()
    {
        ButtonSFX.PlayOneShot(clickButtonSFX);
    }
}
