using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Scripts.TrainDixa
{

    public class GroundController : MonoBehaviour
    {

        public event Action OnGameOverEvent;
        private const string BallTag = "BALL";

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(BallTag))
            {
                OnGameOverEvent?.Invoke();
            }
        }
    }
}