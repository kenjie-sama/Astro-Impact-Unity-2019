using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class slideInTransition : MonoBehaviour
{
    [SerializeField] private RectTransform slide1, slide2, slide3;
    public void SlideInTransition()
    {
        slide1.gameObject.SetActive(true);
        slide1.DOAnchorPos(new Vector2(0,0),0.6f).SetEase(Ease.OutCirc);
        slide2.gameObject.SetActive(true);
        slide2.DOAnchorPos(new Vector2(0, 0), 0.6f).SetDelay(0.3f).SetEase(Ease.OutCirc);
        slide3.gameObject.SetActive(true);
        slide3.DOAnchorPos(new Vector2(0, 0), 0.6f).SetDelay(0.5f).SetEase(Ease.OutCirc);
    }
}
