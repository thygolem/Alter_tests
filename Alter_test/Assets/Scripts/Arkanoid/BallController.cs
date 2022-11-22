using System;
using UnityEngine;

namespace Scripts.Arkanoid
{
    internal class BallController : MonoBehaviour
    {
        new Rigidbody2D rigidbody2D;

        [SerializeField, Tooltip("Velocidad de la pelota")] Vector2 velocity = new Vector2 (3f, 4f);

        private void Awake() {
            if(velocity.magnitude == 0) throw new Exception("La velocidad no puede ser 0");
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.isKinematic = true;
        }
        internal void BeFree()
        {
            rigidbody2D.isKinematic = false; // cambia de cinematico a dinámico
            transform.parent = null; // no le afecta el transform del padre
            rigidbody2D.velocity = velocity;
        }
    }
}