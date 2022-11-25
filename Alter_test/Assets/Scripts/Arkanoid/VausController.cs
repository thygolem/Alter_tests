using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Arkanoid
{

    enum VausState
    {
        Normal = 0, Mediano = 1, Grande = 2///////////////////////////IMPORTANTE/////////////////////////
    }

    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(BoxCollider2D))]
    public class VausController : MonoBehaviour
    {
        [SerializeField, Tooltip("Configura la velocidad"), Range(1f, 10f)] float speed = 2;

        [SerializeField] Sprite[] sprites;

        public event Action onBallReleaseEvent; // evento!
        new Rigidbody2D rigidbody2D;
        private Vector2 velocity;


        bool isBallReleased;
        private Vector2 initialPosition;
        SpriteRenderer spriteRenderer;
        BoxCollider2D boxCollider;

        VausState state;

        private void Awake()
        {
            if (sprites.Length == 0) throw new Exception("FALTAN IMAGENES");
            spriteRenderer = GetComponent<SpriteRenderer>();
            rigidbody2D = GetComponent<Rigidbody2D>(); // cacheamos la variable del objeto al que le asignamoes este script
            boxCollider = GetComponent<BoxCollider2D>(); // cacheamos la variable del objeto al que le asignamoes este script
            isBallReleased = false;
            initialPosition = transform.position;
            state = VausState.Normal;
            spriteRenderer.sprite = sprites[(int)state]; ///////////////////////////IMPORTANTE/////////////////////////
        }
        void Update()
        {
            // cogemos el INPUT(*1) GetAxisRaw=valores -1, 0, 1
            velocity = new Vector2(Input.GetAxisRaw(Constants.HORIZONTAL) * speed, 0f); // vector2 = (x, y)
            // Input.GetAxis("Horizontal"); // valores decimales
            if (Input.GetAxisRaw(Constants.FIRE) != 0 && !isBallReleased)
            {
                isBallReleased = true;
                onBallReleaseEvent?.Invoke(); // evento, que necesita un Action para que un método se suscriba
            }
        }

        private void FixedUpdate()
        {
            // usamos el INPUT(*1)
            rigidbody2D.velocity = velocity;
        }

        internal void Reset()
        {
            isBallReleased = false;
            transform.position = initialPosition;
        }

        public void Stretch()
        {
            switch (state)
            {
                case VausState.Normal:
                    state = VausState.Mediano;
                    break;
                case VausState.Mediano:
                    state = VausState.Grande;
                    break;
                case VausState.Grande:
                    break;
            }
            UpdateSpriteAndCollider();
        }

        private void UpdateSpriteAndCollider()
        {
            spriteRenderer.sprite = sprites[(int)state]; ///////////////////////////IMPORTANTE/////////////////////////
            boxCollider.size = spriteRenderer.sprite.bounds.size;
        }

        public void Shrink()
        {
            switch (state)
            {
                case VausState.Normal:
                    break;
                case VausState.Mediano:
                    state = VausState.Normal;
                    break;
                case VausState.Grande:
                    state = VausState.Mediano;
                    break;
            }
            UpdateSpriteAndCollider();
        }
    }
}