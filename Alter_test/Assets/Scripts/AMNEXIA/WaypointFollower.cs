using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;
// using UnityEngine.AI;


namespace Scripts.Dislexia
{
    public class WaypointFollower : MonoBehaviour
    {
        // [SerializeField, Tooltip("Ease method to use")] Ease ease = Ease.InSine;
        // [SerializeField, Range(0.1f, 2f)] float duration = 0.5f;

        // [SerializeField, Tooltip("Must wait previous animation to end?")] bool mustWaitUntilEnd = true;

        [SerializeField] Transform[] waypoints;
        int waypointIndex = 0;
        Transform myTransform;

        bool isAnimationOver;

        [SerializeField] float moveSpeed = 2f;



        private void Awake()
        {
            // isAnimationOver = true;
            // if (waypoints == null) throw new System.Exception("No se han indicado los puntos a seguir");
            // Debug.Log($"Primera posición{waypoints[0]}");
            // myTransform = transform;
            // myTransform = waypoints[0].transform;
            if (waypoints.Length != 0)
            {
                transform.position = waypoints[waypointIndex].transform.position;
            }
            else
            {
                
            }
        }


        private void Start()
        {
            // GetComponent<NavMeshAgent> ().SetDestination(waypoints[0].position);
            // GetComponent<NavMeshAgent> ().SetDestination(waypoints[0].transform.position);

        }
        private void Update()
        {
            // StartCoroutine(Tracker());
            StartCoroutine(Move());
        }

        IEnumerator Move()
        {
            transform.position = Vector2.MoveTowards(transform.position,
                                                    waypoints[waypointIndex].transform.position,
                                                    moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1; // make it random
                yield return new WaitForSeconds(2);
            }
            if (waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
                yield return new WaitForSeconds(2);

            }
            yield return new WaitForSeconds(2);
        }

        // IEnumerator Tracker()
        // {



        //     if ((isAnimationOver && mustWaitUntilEnd) || !mustWaitUntilEnd)
        //     {
        //         foreach (Transform wp in waypoints)
        //         {
        //             Debug.Log($"Siguientes posiciones {wp.transform.position}");

        //             myTransform.DOMove(waypoints[0].transform.position, duration)
        //                 .SetEase(ease)
        //                 .OnComplete(() => {isAnimationOver = true;} );
        //         }
        //     }
        //     yield return new WaitForSeconds(2);
        // }
        // private void theEnd()
        // {
        //     isAnimationOver = true;
        // }

    }
}