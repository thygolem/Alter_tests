using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;



namespace Scripts.Arkanoid
{
    public class WorldManager : MonoBehaviour
    {
        [SerializeField] BallController ballController;
        [SerializeField] VausController vausController;

        // [SerializeField] LevelManager levelManager;
        [SerializeField] DeadZoneController deadZoneController;
        [SerializeField] PowerUpController powerUpController;
        // [SerializeField] BrickController brickController;
        LevelManager levelManager;
        PlayerManager playerManager;
        List<GameObject> bricksGOs;

        [SerializeField] PowerUpController [] powerUpPrefabs; /////////////// ?


        private void Start()
        {

            playerManager = PlayerManager.GetInstance();
            levelManager = LevelManager.GetInstance();

            vausController.onBallReleaseEvent += OnBallReleaseHandler;
            playerManager.OnScoreUpdatedEvent += OnScoreUpdatedHandler;
            deadZoneController.OnEnterDeadZoneEvent += OnEnterDeadZoneHandler;
            powerUpController.OnVausTriggerEvent += OnVausTriggerHandler; 

            SetUpBricks();
            SetUpPowerUps();
        }

        private void SetUpPowerUps()
        {
            foreach (var brickGO in bricksGOs)
            {
                var brickController = brickGO.GetComponent<BrickController>();
                if (brickController.HasPowerUp())
                {
                    var powerUp = brickController.GetPowerUp();
                    powerUp.gameObject.SetActive(false);
                    powerUp.transform.position = brickController.transform.position;
                    powerUp.OnVausTriggerEvent += OnVausTriggerHandler;
                }
            }
            // CreatePowerUps();
        }

        // private void CreatePowerUps()
        // {
        //     bool hasFinished = false;
        //     while (!hasFinished)
        //     {
        //         // elegir un ladrillo
        //         int brickIndex = Random.Range(0, bricksGOs.Count);

        //         var brickController = bricksGOs[brickIndex].GetComponent<BrickController>();
        //         // Comporbar si tiene powerup
        //         if (brickController.HasPowerUp())
        //         {
        //             //  Si no lo tiene, le añado power up
        //             var powerUpPrefabIndex = Random.Range(0, powerUpPrefabs.Length);
        //             var powerUpGO = Instantiate(powerUpPrefabs[powerUpPrefabIndex]);
        //             brickController.SetPowerUp(powerUpGO.GetComponent<PowerUpController>());
        //             // hay que reubicar el prefab
        //             //  Actualizo nº de powerups
        //             numberOfPowerUpsToAdd --;
        //             //  pregunto si ha terminado
        //             // comprobar si ha creado todos los powerups

        //         }
        //     }
        // }

        private void OnVausTriggerHandler(PowerUpController powerUp)
        {
            switch (powerUp.GetPowerUpType())
            {
                case PowerUpType.Stretch:
                    vausController.Stretch();
                    break;
                case PowerUpType.Shrink:
                    vausController.Shrink();
                    break;
                case PowerUpType.Shoot:
                    break;
                case PowerUpType.Subdivide:
                    break;
            }
            powerUpController.OnVausTriggerEvent -= OnVausTriggerHandler;
            Destroy(powerUpController.gameObject);
            Debug.Log(" cambios vaus hechos");

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

            if(brickController.HasPowerUp())
            {
                PowerUpController powerUpController = brickController.GetPowerUp();
                powerUpController.gameObject.SetActive(true);
                // Guardar los powerups
            }

            if (bricksGOs.Count == 0)
            {
                Debug.Log("Paso de nivel");
                levelManager.NextLevel();
            }
            Destroy(brickController.gameObject);
        }

        private void OnBallReleaseHandler()
        {
            ballController.BeFree();
        }
    }


}