using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Elimina la ambigüedad de random
using Random = UnityEngine.Random;


namespace Scripts.TrainDixa
{

    public class WorldManager : MonoBehaviour
    {
        [SerializeField] GameObject[] _ballPrefabs;
        [SerializeField] Transform _ballPosition;
        [SerializeField] GroundController _groundController;
        [SerializeField] int _MaxNumberOfBalls = 5;
        [SerializeField] float _minTimeBtweenBalls = 1f;
        [SerializeField] float _maxTimeBtweenBalls = 4f;
        [SerializeField] ScoreManager scoreManager;
        [SerializeField] ParticleSystem explosionParticle;
        [SerializeField] Button _playButton;

        // int ballsCounter;
        List<GameObject> balls;

        private void Awake()
        {

            if (_MaxNumberOfBalls <= 0) throw new Exception("ERROR, número no válido");
            // || cortocircuito.
            // | puede seguir comparando.
            if (_minTimeBtweenBalls > _maxTimeBtweenBalls ||
                _maxTimeBtweenBalls < _minTimeBtweenBalls)
                throw new Exception("ERROR, números min/max no válido");
            if (scoreManager == null) throw new Exception("scoreManager no asignado"); // Programación por eventos.
            if (explosionParticle == null) throw new Exception("ERROR, sin particulas");
            if (_ballPrefabs.Length == 0) throw new Exception("ERROR, sin prefabs asignados");
            if (_playButton == null) throw new Exception("ERROR, no hay boton asignado");



            _groundController.OnGameOverEvent += OnGameOverEvent;

            balls = new List<GameObject>();


            // StartCoroutine(CreateBalls());



        }

        private void OngameOverHandler()
        { 
            foreach(var ballGO in balls)
            {
                ballGO.GetComponent<BallController>().OnBallDestroyedEvent -= OnBallDestroyedHandler;
                Destroy(ballGO);
            }
            balls.Clear();
            
            scoreManager.UpdateHighScore();
            StopAllCoroutines();
            // _MaxNumberOfBalls = 0;
            _playButton.gameObject.SetActive(true);
        }

        IEnumerator CreateBalls()
        {
            // El problema de la creación de varias bolas se debe al tiempo de espera, por eso ponemos el if después.
            var randomTime = Random.Range(_minTimeBtweenBalls, _maxTimeBtweenBalls);

            yield return new WaitForSeconds(randomTime);

            if (balls.Count < _MaxNumberOfBalls)
            {
                // ballsCounter++;
                CreateBall();

                // Recursividad
                StartCoroutine(CreateBalls());
            }

        }

        private void CreateBall()
        {
            // Me suscribo con "+=" al evento Action OnBallDestroyed. Haciendo _ballController.OnBallDestroyed
            // El evento y el manejador(handler) suelen tener el mismo nombre
            // _ballPrefab.OnBallDestroyedEvent += OnBallDestroyedHandler;
            ////////////////////////////////////////////////////////////////
            float HorizontalVariation = Camera.main.orthographicSize * Camera.main.aspect * 0.8f;
            // var sirve para crear variables locales, que solo van a poder ser usadas dentro del método donde se crean.
            var xPosition = _ballPosition.position.x + Random.Range(-HorizontalVariation, HorizontalVariation);
            int randomIndex = Random.Range(0, _ballPrefabs.Length);
            var ballGO = Instantiate(_ballPrefabs[randomIndex]);

            ballGO.transform.position = new Vector2(xPosition, _ballPosition.position.y);

            // Me suscribo con "+=" al evento Action OnBallDestroyed. Haciendo _ballController.OnBallDestroyed
            ballGO.GetComponent<BallController>().OnBallDestroyedEvent += OnBallDestroyedHandler;

            balls.Add(ballGO);
        }

        private void OnBallDestroyedHandler(BallController ballController) // estamos desacoplando objetos
        {
            // desuscribir del canal
            ballController.OnBallDestroyedEvent -= OnBallDestroyedHandler;
            balls.Remove(ballController.gameObject);
            // Debug.Log(ballController.GetBallValue());
            // Debug.Log("Has pinchado la pelota");
            scoreManager.AddScore(ballController.GetBallValue());
            var particle = Instantiate(explosionParticle,
                        ballController.transform.position,
                        Quaternion.identity); // Otro tipo de 
            Destroy(particle.gameObject, particle.main.duration);
            Destroy(ballController.gameObject);
            // ballsCounter--;
            StartCoroutine(CreateBalls());


        }

        public void PlayGame()
        {
            scoreManager.ResetScore();
            StartCoroutine(CreateBalls());
            _playButton.gameObject.SetActive(false);

        }

        private void OnGameOverEvent()
        {
            Debug.Log("Toca el suelo");
            // debemos destruir las bolas
            // parar la corrutina
            StopAllCoroutines();
            // guardar el score total de la partida.
            scoreManager.UpdateHighScore();
            OngameOverHandler();

        }


    }
}
