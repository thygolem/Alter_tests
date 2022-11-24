using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace Scripts.Arkanoid
{
    public class LevelManager : MonoBehaviour
    {
        int levelId;
        internal void NextLevel()
        {
            levelId++;
            SceneManager.LoadScene("Arkanoid2");
        }
    }
}