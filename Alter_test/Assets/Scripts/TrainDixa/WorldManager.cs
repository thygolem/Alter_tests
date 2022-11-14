using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Elimina la ambugüedad de random
using Random = UnityEngine.Random;


namespace Scripts.TrainDixa
{

    public class WorldManager : MonoBehaviour
    {
        [SerializeField] GameObject _ballPrefab;
        [SerializeField] Transform _ballPosition;
        [SerializeField] int _MaxNumberOfBalls = 5;

        int ballsCounter = 0;

        private void Awake()
        {

            if (_MaxNumberOfBalls <= 0) throw new Exception("ERROR, número no válido");
            StartCoroutine(CreateBall());

        }

        IEnumerator CreateBall()
        {
            yield return new WaitForSeconds(1f);
            ballsCounter++;
            // Me suscribo con "+=" al evento Action OnBallDestroyed. Haciendo _ballController.OnBallDestroyed
            // El evento y el manejador(handler) suelen tener el mismo nombre
            // _ballPrefab.OnBallDestroyedEvent += OnBallDestroyedHandler;
            ////////////////////////////////////////////////////////////////
            float HorizontalVariation = Camera.main.orthographicSize * Camera.main.aspect * 0.8f;
            // var sirve para crear variables locales, que solo van a poder ser usadas dentro del método donde se crean.
            var xPosition = _ballPosition.position.x + Random.Range(-HorizontalVariation, HorizontalVariation);
            var ballGO = Instantiate(_ballPrefab);
            ballGO.transform.position = new Vector2(xPosition, _ballPosition.position.y);
            ballGO.GetComponent<BallController>().OnBallDestroyedEvent += OnBallDestroyedHandler;
            // Recursividad
            if (ballsCounter < _MaxNumberOfBalls)
            {
                StartCoroutine(CreateBall());

            }
            

        }


        private void OnBallDestroyedHandler() // estamos desacoplando objetos
        {
            Debug.Log("Han pinchado la pelota");
        }
    }
}
