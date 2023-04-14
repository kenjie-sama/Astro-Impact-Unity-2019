using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class sliceInTransition : MonoBehaviour
{
    [SerializeField] private RectTransform slice1, slice2;
    public void SliceInTransition()
    {
        slice1.gameObject.SetActive(true);
        slice1.DOAnchorPos(new Vector2(-645, -1132),0.5f).SetEase(Ease.OutCirc);
        slice2.gameObject.SetActive(true);
        slice2.DOAnchorPos(new Vector2(558, -1718), 0.5f).SetEase(Ease.OutCirc);
    }

}
