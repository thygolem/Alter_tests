using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Scripts.Arkanoid
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PowerUpController : MonoBehaviour
    {

        [SerializeField] PowerUpType powerUpType;
        [SerializeField, Tooltip("Velocidad de caida")] float velocityY = -1f;
        new Rigidbody2D rigidbody2D;

        public event Action<PowerUpController> OnVausTriggerEvent;
        private void Awake()
        {
            if (velocityY >= 0) throw new Exception("ERROR velocidad no valida");
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = new Vector2(0, velocityY);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Constants.VAUS))
            {
                OnVausTriggerEvent?.Invoke(this);
                Debug.Log("He atravesado la VAUS");
            }
            if (other.gameObject.CompareTag(Constants.DEADZONE))
            {
                Destroy(gameObject);

                Debug.Log("He atravesado la DEADZONE");
            }
        }
        public PowerUpType GetPowerUpType()
        {
            return powerUpType;
        }
    }
}