using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadIntro : MonoBehaviour
{
    [SerializeField] private slideOut slides;
    void Start()
    {
        slides.SlideOutTransition();
    }
}
