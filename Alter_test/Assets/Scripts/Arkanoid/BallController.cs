using System;
using UnityEngine;

namespace Scripts.Arkanoid
{
    internal class BallController : MonoBehaviour
    {
        new Rigidbody2D rigidbody2D;

        [SerializeField, Tooltip("Velocidad de la pelota")] Vector2 velocity = new Vector2(3f, 4f);
        private Vector2 initalPosition;

        private void Awake()
        {
            if (velocity.magnitude == 0) throw new Exception("La velocidad no puede ser 0");
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.isKinematic = true;
            initalPosition = transform.position;
        }
        internal void BeFree()
        {
            rigidbody2D.isKinematic = false; // cambia de cinematico a dinámico
            transform.parent = null; // no le afecta el transform del padre
            rigidbody2D.velocity = velocity;
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(Constants.VAUS))
            {
                var VausPosition = other.transform.position;
                var BallPosition = transform.position;
                var vectorFromVausToBall = BallPosition - VausPosition;
                // un vector normalizado es un vector de longitud=1
                var newVelocity = vectorFromVausToBall.normalized * velocity.magnitude;
                rigidbody2D.velocity = newVelocity;

                // Debug.DrawRay(VausPosition, vectorFromVausToBall, Color.red, 2);
            }
        }

        internal void Reset(Transform newParent)
        {
            transform.SetParent(newParent);
            rigidbody2D.isKinematic = true;
            rigidbody2D.velocity = Vector2.zero;
            transform.position = initalPosition;

        }
    }
}