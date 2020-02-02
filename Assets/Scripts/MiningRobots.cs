using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MiningRobots : MonoBehaviour
{
    Vector3 firstPos, currentPos;
    [SerializeField]
    Vector3 finalPos;
    [SerializeField]
    Ease ease;

    private void Start()
    {
        firstPos = transform.position;
        currentPos = finalPos;
        Move(currentPos);
    }

    private void Move(Vector3 pos)
    {
        transform.DOMove(pos, 2.5f).OnComplete(() => Move(currentPos)).SetEase(ease);
        currentPos = currentPos == finalPos ? firstPos : finalPos;
    }

}
