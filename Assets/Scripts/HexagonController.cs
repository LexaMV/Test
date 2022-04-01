using System.Collections;
using System.Collections.Generic;
using cakeslice;
using DG.Tweening;
using UnityEngine;

public class HexagonController : MonoBehaviour
{
    public Outline Outline;
    public bool isFirstStepCompleted;
    public bool isUp;

    public void Rotate()
    {
        transform.DORotate(new Vector3(0, 0, 60f), 0.2f, RotateMode.LocalAxisAdd);
    }

    public void MoveUp()
    {
        Outline.color = 2;
        isFirstStepCompleted = true;
        transform.DOKill();
        transform.DOMoveY(0.1f, 0.2f);
        isUp = true;
    }

    public void MoveDown()
    {
        Outline.color = 0;
        isFirstStepCompleted = false;
        transform.DOKill();
        transform.DOMoveY(0.0f, 0.2f);
        isUp = false;
        isFirstStepCompleted = false;
    }

    public void MoveTo(Vector3 target)
    {
        transform.DOMove(target, 0.2f).OnComplete(MoveDown);
    }
}
