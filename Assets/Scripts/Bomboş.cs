using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomboş : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            DoTweenController.DoMoveAnimate(this.gameObject, new Vector3(0, 0, -20), 1, DG.Tweening.Ease.OutBounce);
        }       
    }
}
