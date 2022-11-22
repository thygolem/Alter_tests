using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Scripts.Arkanoid
{
    public class WorldManager : MonoBehaviour
    {
        [SerializeField] BallController ballController;

        [SerializeField] VausController vausController;


        private void Awake()
        {
            vausController.onBallRelease += OnBallReleaseHandler;
        }

        private void OnBallReleaseHandler()
        {
            ballController.BeFree();
        }
    }


}