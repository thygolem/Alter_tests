using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.TrainDixa
{

    public class BallController : MonoBehaviour
    {
        public event Action OnBallDestroyedEvent;
        private void OnMouseDown() // Manejador del evento OnMouseDown
        {
            // Informo de que ha cosurrido el evento OnBallDestroyed. Con '?' C# nos ayuda para saber si es nulo o no.
                // si quiero que se ejecute cuando es nulo, hay que usar un try catch para manejar la excepcion que se produce. 
            OnBallDestroyedEvent?.Invoke();
        }
    }
}
