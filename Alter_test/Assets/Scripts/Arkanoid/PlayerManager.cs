using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Arkanoid
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField, Range(1, 5), Tooltip("Numero de vidas iniciales")] int lives = 3;

        public event Action<int> OnScoreUpdatedEvent;
        int score;

        internal void AddScore(int scoreToAdd)
        {   
            score+= scoreToAdd;
            OnScoreUpdatedEvent?.Invoke(score);
        }

        private void Awake() {
            
        }


    }
}