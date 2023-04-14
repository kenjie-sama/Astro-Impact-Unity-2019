using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class boxOutTransition : MonoBehaviour
{
    [SerializeField] private RectTransform box1, box2, box3;

    public void BoxOutTransition()
    {
        box1.gameObject.SetActive(true);
        box1.DOScaleX(20,0.5f).SetEase(Ease.OutCirc);
        box1.DOScaleY(11, 0.5f).SetEase(Ease.OutCirc);
        box2.gameObject.SetActive(true);
        box2.DOScaleX(20, 0.5f).SetDelay(0.3f).SetEase(Ease.OutCirc);
        box2.DOScaleY(11, 0.5f).SetDelay(0.3f).SetEase(Ease.OutCirc);
        box3.gameObject.SetActive(true);
        box3.DOScaleX(20, 0.5f).SetDelay(0.5f).SetEase(Ease.OutCirc);
        box3.DOScaleY(11, 0.5f).SetDelay(0.5f).SetEase(Ease.OutCirc);
    }
}
