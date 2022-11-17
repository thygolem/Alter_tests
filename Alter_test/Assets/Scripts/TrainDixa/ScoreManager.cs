using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



namespace Scripts.TrainDixa
{
    // Responsable de las puntuaciones.
    public class ScoreManager : MonoBehaviour
    {

        [SerializeField] TMP_Text _tMP_score;
        [SerializeField] TMP_Text _tMP_highScore;
        private const string HIGHSCOREKEYCONST = "High Score";
        int score;
        int highScore;



        // public event Action<ScoreManager> OnColorChangeEvent;

        private void Awake()
        {
            if (_tMP_score == null || _tMP_highScore == null) throw new Exception("Scores sin asignar");
            if (PlayerPrefs.HasKey(HIGHSCOREKEYCONST))
            {
                highScore = PlayerPrefs.GetInt("High Score");
            }
            _tMP_score.text = $"Score: {score}";
            _tMP_highScore.text = $"High Score: {highScore}";
            // Debug.Log(highScore);
        }

        public void AddScore(int scoreToAdd)
        {
            score += scoreToAdd;
            Debug.Log(score);
            _tMP_score.text = $"Score: {score}";

            // ****************************************************************************************

            // Aqui el scoremanager pregunta si el score es mayor de x

            // envia una señal a worldManager para que cambie el color de las pelotas  

            // ****************************************************************************************
            // OnColorChangeEvent?.Invoke(this);

            // if (score > 100) WorldManager.ChangeBallSaturation("grey");


        }

        internal void UpdateHighScore()
        {
            // Actualizar/crear el high score
            if (highScore < score)
            {
                highScore = score;
                PlayerPrefs.SetInt("High Score: ", highScore);
                _tMP_highScore.text = $"High Score: {highScore}";

                // https://docs.unity3d.com/2020.3/Documentation/ScriptReference/PlayerPrefs.html
            }
        }

        internal void ResetScore()
        {
            score = 0;
            _tMP_score.text = $"Score: {score}";
        }
    }
}
