using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Arkanoid
{
    public class BrickController : MonoBehaviour
    {
        [SerializeField, Range(1, 5)] int resistance = 1;
        [SerializeField] int score;
        public event Action<BrickController> OnBrickDestroyedEvent;

        internal int GetScore()
        {
            return score;
        }

        // public event Action<int> OnBrickDestroyedEvent; // alternativa(*2) si quisieramos enviar solo el dato de score

        private void Awake() {
            if(score <= 0) throw new Exception("ERROR puntuación no valida");
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(Constants.BALLTAG))
            {
                resistance--;
                if(resistance == 0)
                {
                    OnBrickDestroyedEvent?.Invoke(this);
                    // OnBrickDestroyedEvent?.Invoke(score); // alternativa(*2) si quisieramos enviar solo el dato de score
                }
            }
        }




    }
}
