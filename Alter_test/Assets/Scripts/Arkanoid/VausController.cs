using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Arkanoid
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class VausController : MonoBehaviour
    {
        [SerializeField, Tooltip("Configura la velocidad"), Range(1f, 10f)] float speed = 2;

        public event Action onBallRelease; // evento!
        new Rigidbody2D rigidbody2D;
        private Vector2 velocity;

        bool isBallReleased;
        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>(); // cacheamos la variable del objeto al que le asignamoes este script
            isBallReleased = false;
        }
        void Update()
        {
            // cogemos el INPUT(*1) GetAxisRaw=valores -1, 0, 1
            velocity = new Vector2(Input.GetAxisRaw(Constants.HORIZONTAL) * speed, 0f); // vector2 = (x, y)
            // Input.GetAxis("Horizontal"); // valores decimales
            if(Input.GetAxisRaw(Constants.FIRE)!= 0)
            {
                isBallReleased = true;
                onBallRelease?.Invoke(); // evento, que necesita un Action para que un método se suscriba
            }
        }

        private void FixedUpdate()
        {
            // usamos el INPUT(*1)
            rigidbody2D.velocity = velocity;
        }

    }
}