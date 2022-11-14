using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.TrainDixa
{

    public class BallController : MonoBehaviour
    {
        // Definimos el evento con la información de la propia (this) pelota
        public event Action<BallController> OnBallDestroyedEvent;

        [SerializeField, Tooltip("Punto por pelota")] int ballValue = 10;

        private void Awake() {
            if(ballValue <= 0) throw new  Exception ("No hay puntuación asignador a ballValue");
        }


        private void OnMouseDown() // Manejador del evento OnMouseDown
        {
            // Informo de que ha cosurrido el evento OnBallDestroyed. Con '?' C# nos ayuda para saber si es nulo o no.
                // si quiero que se ejecute cuando es nulo, hay que usar un try catch para manejar la excepcion que se produce. 
            OnBallDestroyedEvent?.Invoke(this); // invoke() simepre va unido a +=, son publicar y suscribir. Para desuscribirse, se usa -=.
            // publico con esta(this) información.
        }


        // método de acceso a la puntuación de la pelota
        internal int GetBallValue()
        {
            return ballValue;
        } 
    }
}
