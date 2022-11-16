using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public enum NivelDeJugador 
{
    MuyFacil, Facil, Dificil, MuyDificil
}
public class RandomBallMovement : MonoBehaviour
{

    [SerializeField, Range(0, 4)]
    int _nivelJugador = 0;

    // [SerializeField, Tooltip("Punto por pelota")]
    // int ballValue = 10;

    // [SerializeField, Range(0, 1)] float _maxRandomness = 0.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        // float coeficienteRandom = Random.Range(_minRandomness, _maxRandomness);
        LevelManager(_nivelJugador);
    }

    void LevelManager(float coef)
    {

        switch (coef)
        {
            case 0.3f:
                Debug.Log(NivelDeJugador.MuyFacil.ToString());
                break;
            case 0.5f:
                Debug.Log(NivelDeJugador.Facil.ToString());
                break;
            case 0.8f:
                Debug.Log(NivelDeJugador.Dificil.ToString());
                break;
            case 1f:
                Debug.Log(NivelDeJugador.MuyDificil.ToString());
                break;
        }
    }
}
