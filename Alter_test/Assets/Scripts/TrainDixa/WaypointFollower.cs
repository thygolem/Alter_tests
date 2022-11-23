using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.TrainDixa
{
    public class WaypointFollower : MonoBehaviour
    {
        [SerializeField] Transform[] waypoints;


        private void Awake()
        {
            if(waypoints == null) throw new System.Exception("No se han indicado los puntos a seguir");
        }


        private void Update()
        {
            StartCoroutine(Tracker());
        }

        IEnumerator Tracker()
        {
            foreach (Transform wp in waypoints)
            {
                Debug.Log(wp.transform.position);
            }
            yield return new WaitForSeconds(2);
        }

    }
}