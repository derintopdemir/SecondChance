using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public struct DoTweenController
{

    public static void DoMoveAnimate(GameObject gameObject, Vector3 endValue, float duration, Ease ease)
    {
        gameObject.transform.DOLocalMove(endValue, duration, false).SetEase(ease).SetLoops(-1);
    }


}
