using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Scripts.TrainDixa
{

    public enum NivelDeJugador
    {
        MuyFacil, Facil, Dificil, MuyDificil
    }
    public class ChangeSaturation : MonoBehaviour
    {

        [SerializeField, Range(0, 3)]
        int _nivelJugador = 0;

        private void Awake()
        {
            // float coeficienteRandom = Random.Range(_minRandomness, _maxRandomness);
            LevelManager(_nivelJugador);
        }

        void LevelManager(int _nivelJugador)
        {

            switch (_nivelJugador)
            {
                case 0:
                    Debug.Log(NivelDeJugador.MuyFacil.ToString());
                    // Prefab de pelota en NEGRO
                    break;
                case 1:
                    Debug.Log(NivelDeJugador.Facil.ToString());
                    // Prefab de pelota en GRIS OSCURO
                    break;
                case 2:
                    Debug.Log(NivelDeJugador.Dificil.ToString());
                    // Prefab de pelota en GRIS
                    break;
                case 3:
                    Debug.Log(NivelDeJugador.MuyDificil.ToString());
                    // Prefab de pelota en GRIS CLARO
                    break;
            }
        }
    }
}