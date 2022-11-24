using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


namespace Scripts.Arkanoid
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] RectTransform livesImage;
        [SerializeField] TMP_Text scoreText;
        [SerializeField] TMP_Text highScoreText;



        private void Awake()
        {
            if (livesImage == null) throw new Exception("Flata livesImage");
            if (scoreText == null) throw new Exception("Falta TMPRO score");
            if (highScoreText == null) throw new Exception("Falta TMPRO hisghscore");


        }

        public void UpdateLives(int lives)
        {
            livesImage.sizeDelta = new Vector2(42 * lives, livesImage.sizeDelta.y);
        }

        public void UpdateScore(int score) 
        {
            scoreText.text = score.ToString();
        }


        public void UpdateHighScore(int highScore)
        {
            highScoreText.text = highScore.ToString();

        }
    }
}