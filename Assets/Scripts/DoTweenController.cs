using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public struct DoTweenController
{


    public void DoAnimate(GameObject gameObject, Vector3 endValue, float duration)
    {
        gameObject.transform.DOMove(endValue, duration, false);
    }


}
