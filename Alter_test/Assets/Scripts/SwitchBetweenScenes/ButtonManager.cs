using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.SwitchBetweenScenes
{
    public class ButtonManager : MonoBehaviour
    {

        public void ChangeScene(int sceneId)
        {
            SceneManager.LoadScene($"scene{sceneId}");



        }

        public void ExitApplication()
        {
            Debug.Log("Salir");
        }

    }
}