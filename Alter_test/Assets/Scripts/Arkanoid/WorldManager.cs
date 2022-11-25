using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



namespace Scripts.Arkanoid
{
    public class WorldManager : MonoBehaviour
    {
        [SerializeField] BallController ballController;
        [SerializeField] VausController vausController;

        // [SerializeField] LevelManager levelManager;
        [SerializeField] DeadZoneController deadZoneController;
        // [SerializeField] BrickController brickController;
        LevelManager levelManager;
        PlayerManager playerManager;
        List<GameObject> bricksGOs;

        private void Start()
        {

            playerManager = PlayerManager.GetInstance();
            levelManager = LevelManager.GetInstance();

            vausController.onBallReleaseEvent += OnBallReleaseHandler;
            playerManager.OnScoreUpdatedEvent += OnScoreUpdatedHandler;
            deadZoneController.OnEnterDeadZoneEvent += OnEnterDeadZoneHandler;
            SetUpBricks();
        }


        private void SetUpBricks()
        {
            // busca los gameobject con etiqueta BRICK
            GameObject[] bricksAux = GameObject.FindGameObjectsWithTag(Constants.BRICK);
            // convertimos el array en una lista
            bricksGOs = bricksAux.ToList();
            // Recorremos los GameObject y suscribimos a su evento
            for (int i = 0; i < bricksGOs.Count; i++)
            {
                bricksGOs[i].GetComponent<BrickController>().OnBrickDestroyedEvent += OnBrickDestroyedHandler;

            }
        }

        private void OnEnterDeadZoneHandler(GameObject obj)
        {
            playerManager.LoseLife();
            vausController.Reset();
            ballController.Reset(vausController.transform);
            Debug.Log("Si es la ultim abola, pierdes vida y reseteas nivel");

        }

        private void OnScoreUpdatedHandler(int score) // PARA DISLEXIA IRIA AQUI
        {
            Debug.Log($"puntuacion ´{score}"); // string interpolation
        }

        private void OnBrickDestroyedHandler(BrickController brickController)
        {
            bricksGOs.Remove(brickController.gameObject);
            playerManager.AddScore(brickController.GetScore()); // usar patron singleton
            // Debug.Log("El ladrillo se destruye");
            Destroy(brickController.gameObject);

            if (bricksGOs.Count == 0)
            {
                Debug.Log("Paso de nivel");
                levelManager.NextLevel();
            }
        }

        private void OnBallReleaseHandler()
        {
            ballController.BeFree();
        }
    }


}