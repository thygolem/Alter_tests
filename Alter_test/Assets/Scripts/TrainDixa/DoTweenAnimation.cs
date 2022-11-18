using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


namespace Scripts.TrainDixa
{
    public class DoTweenAnimation : MonoBehaviour
    {
        Transform myTransform;

        private void Awake() {
            myTransform = transform;
            myTransform.DOMove(new Vector2(2, 3), 5).SetEase(Ease.InOutElastic).SetLoops(2).OnComplete(theEnd);
        }

        private void theEnd()
        {
            Debug.Log("finished Dotween animation");
        }
    }
}