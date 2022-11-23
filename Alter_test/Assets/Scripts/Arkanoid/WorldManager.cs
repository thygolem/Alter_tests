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

        [SerializeField] BrickController brickController;
        [SerializeField] PlayerManager playerManager;

        [SerializeField] DeadZoneController deadZoneController;

        private void Awake()
        {
            vausController.onBallReleaseEvent += OnBallReleaseHandler;
            brickController.OnBrickDestroyedEvent += OnBrickDestroyedHandler;
            playerManager.OnScoreUpdatedEvent += OnScoreUpdatedHandler;
            deadZoneController.OnEnterDeadZoneEvent += OnEnterDeadZoneHandler;
        }

        private void OnEnterDeadZoneHandler(GameObject obj)
        {
            Debug.Log("Si es la ultim abola, pierdes vida y reseteas nivel");
        }

        private void OnScoreUpdatedHandler(int score)
        {   
            Debug.Log($"puntuacion ´{score}"); // string interpolation
        }

        private void OnBrickDestroyedHandler(BrickController brickController)
        {
            playerManager.AddScore(brickController.GetScore()); // usar patron singleton
            Debug.Log("El ladrillo se destruye");
            Destroy(brickController.gameObject);
        }

        private void OnBallReleaseHandler()
        {
            ballController.BeFree();
        }
    }


}