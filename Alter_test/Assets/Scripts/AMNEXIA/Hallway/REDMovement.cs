using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Amnexia
{
    public class REDMovement : MonoBehaviour
    {

        [SerializeField] float Speed = 1f;
        // Transform mainREDPos;

        Rigidbody2D REDRigidbody2D;


        private void Awake()
        {
            REDRigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Start is called before the first frame update
        void Start()
        {

            // transform.position = new Vector3(transform.position.x * Speed * Time.deltaTime,
            //                                     mainREDPos.position.y,
            //                                     mainREDPos.position.z);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            REDRigidbody2D.AddForce(transform.right * Speed * Time.deltaTime );
        }
    }
}