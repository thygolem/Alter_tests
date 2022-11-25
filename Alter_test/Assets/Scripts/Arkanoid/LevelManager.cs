using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace Scripts.Arkanoid
{
    public class LevelManager : MonoBehaviour
    {
        // Se suele utilizar instance para indicar la unica instancia del patron singleton
        static LevelManager instance;
        [SerializeField] int levelId;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                // Se suele poner aquí la logica del script
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
            // Alejandro pone aquí la logica del script
        }


        internal void NextLevel()
        {
            levelId++;
            // if(levelId == 3){levelId = 0;}
            SceneManager.LoadScene($"Arkanoid{levelId}");
        }


        // El patron singleton suele tener un unico punto de acceso con un metodo static
        internal static LevelManager GetInstance()
        {
            return instance;
        }
    }
}