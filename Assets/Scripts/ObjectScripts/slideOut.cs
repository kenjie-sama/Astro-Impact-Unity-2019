using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class slideOut : MonoBehaviour
{
    [SerializeField] private RectTransform slide3, slide2, slide1;
    private void Start()
    {
        SlideOutTransition();
    }
    public void SlideOutTransition()
    {
        slide3.gameObject.SetActive(true);
        slide3.DOAnchorPos(new Vector2(1946,0),0.6f).SetEase(Ease.OutCirc);
        slide2.gameObject.SetActive(true);
        slide2.DOAnchorPos(new Vector2(1946, 0), 0.6f).SetDelay(0.3f).SetEase(Ease.OutCirc);
        slide1.gameObject.SetActive(true);
        slide1.DOAnchorPos(new Vector2(1946, 0), 0.6f).SetDelay(0.5f).SetEase(Ease.OutCirc);
    }

}
