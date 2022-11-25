using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Arkanoid
{
    public class PlayerManager : MonoBehaviour
    {
        // Player manager es el responsable de perder vida
        [SerializeField, Range(1, 5), Tooltip("Numero de vidas iniciales")] int lives = 3;

        [SerializeField] UIManager uIManager;
        public event Action<int> OnScoreUpdatedEvent; // para dislexia
        int score;

        static PlayerManager instance;
        private void Awake()
        {

            if (instance == null)
            {
                instance = this;
                if (uIManager == null) throw new Exception("falta uIManager");
                uIManager.UpdateScore(score);
                uIManager.UpdateLives(lives);
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        internal void AddScore(int scoreToAdd)
        {
            score += scoreToAdd;
            OnScoreUpdatedEvent?.Invoke(score); // para dislexia
            uIManager.UpdateScore(score);
        }

        internal void LoseLife()
        {
            lives--;
            uIManager.UpdateLives(lives);
        }

        internal static PlayerManager GetInstance()
        {
            return instance;
        }
    }
}