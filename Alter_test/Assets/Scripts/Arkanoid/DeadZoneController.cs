using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Arkanoid
{
    public class DeadZoneController : MonoBehaviour
    {
        public event Action<GameObject> OnEnterDeadZoneEvent;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Constants.BALLTAG))
            {
                OnEnterDeadZoneEvent?.Invoke(other.gameObject);
            }
        }




    }
}