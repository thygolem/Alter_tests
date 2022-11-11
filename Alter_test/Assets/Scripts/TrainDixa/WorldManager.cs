using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.TrainDixa
{

    public class WorldManager : MonoBehaviour
    {
        [SerializeField] BallController _ballController;

        private void Awake()
        {
            // Me suscribo al evento Action OnBallDestroyed. Haciendo _ballController.OnBallDestroyed
                // El evento y el manejador suelen tener el mismo nombre
            _ballController.OnBallDestroyedEvent += OnBallDestroyedHandler;
        }

        private void OnBallDestroyedHandler() // estamos desacoplando objetos
        {
            Debug.Log("Han pinchado la pelota");
        }
    }
}
