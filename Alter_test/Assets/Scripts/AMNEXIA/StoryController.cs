using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Scripts.Dislexia
{
    [RequireComponent(typeof(TMP_Text))]
    public class StoryController : MonoBehaviour
    {
        [SerializeField, Multiline] string[] _textos;

        TMP_Text tMP_Text;



        // string textoEnPantalla;

        private void Awake()
        {
            tMP_Text = GetComponent<TMP_Text>();
            tMP_Text.text = string.Empty;
            StartCoroutine(ReadText());
        }

        IEnumerator ReadText()
        {
            for (int j = 0; j < _textos.Length; j++)
            {
                for (int i = 0; i < _textos[j].Length; i++)
                {
                    tMP_Text.text += _textos[j][i];
                    // Debug.Log(tMP_Text);
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(.5f);
                tMP_Text.text = string.Empty;
            }
        }
    }
}