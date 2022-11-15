using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.TrainDixa
{
    // Responsable de las puntuaciones.
    public class ScoreManager : MonoBehaviour
    {
        private const string HighScoreKey = "High Score";
        int score;
        int highScore;

        private void Awake()
        {
            if (PlayerPrefs.HasKey(HighScoreKey))
            {
                highScore = PlayerPrefs.GetInt("High Score");
            }
            Debug.Log(highScore);
        }

        public void AddScore(int scoreToAdd)
        {
            score += scoreToAdd;
            Debug.Log(score);
        }

        internal void UpdateHighScore()
        {
            // Actualizar/crear el high score
            if (highScore < score)
            {
                highScore = score;
                PlayerPrefs.SetInt("High Score", highScore);

                // https://docs.unity3d.com/2020.3/Documentation/ScriptReference/PlayerPrefs.html
            }
        }
    }
}
