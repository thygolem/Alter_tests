using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.RayCast
{
    public class RayCastController : MonoBehaviour
    {
        Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }


        private void Update() {

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                // La información del rayo la guarda en la variable Hit, que es una variable de tipo raycasthit.
                if(Physics.Raycast(ray.origin, ray.direction, out var hit, 25))
                {
                    if (hit.collider.gameObject.name == "Agent"){
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.green);

        }
    }
}