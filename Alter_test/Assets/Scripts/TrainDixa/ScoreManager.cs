using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.TrainDixa
{
    // Responsable de las puntuaciones.
    public class ScoreManager : MonoBehaviour
    {
        int score;

        public void AddScore(int scoreToAdd)
        {
            score += scoreToAdd;
            Debug.Log(score);
        }
    }
}
