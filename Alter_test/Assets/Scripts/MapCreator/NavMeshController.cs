using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.RayCast
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavMeshController : MonoBehaviour
    {

        Camera _camera;
        NavMeshAgent navMeshAgent;

        private void Awake()
        {
            _camera = Camera.main;
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                // La información del rayo la guarda en la variable Hit, que es una variable de tipo raycasthit.
                if (Physics.Raycast(ray.origin, ray.direction, out var hit, 25))
                {
                    Vector3 finalDestination = new Vector3(hit.point.x,
                                                            navMeshAgent.transform.position.y, 
                                                            hit.point.z);
                    navMeshAgent.SetDestination(finalDestination);
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.green);
        }

    }
}