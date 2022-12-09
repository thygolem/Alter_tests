using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



namespace Scripts.Amnexia
{

    public enum BatState
    {
        Idle, Lamp
    }
    public class BatMovement : MonoBehaviour
    {
        // [SerializeField, Tooltip("Ease method to use")] Ease ease = Ease.InSine;

        // [SerializeField, Tooltip("Must wait previous animation to end?")] bool mustWaitUntilEnd = true;
        [SerializeField, Range(0.1f, 2f)] float duration = 0.5f;
        [SerializeField] private LayerMask _back;
        new Camera camera;
        BatState CurrentBatState;

        RaycastHit hitInfo = new RaycastHit();

        Transform myTransform;

        // bool isAnimationOver;


        // Start is called before the first frame update

        private void Awake()
        {
            CurrentBatState = BatState.Idle;

            // isAnimationOver = true;

            myTransform = transform;

            camera = Camera.main;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Constants.LAMP))
            {
                // OnVausTriggerEvent?.Invoke(this);
                CurrentBatState = BatState.Idle;
                Debug.Log($"He tocado la lampara{CurrentBatState.ToString()}");
                // Ponr a bat la posicion de la lampara
            }
            if (other.gameObject.CompareTag(Constants.BACK))
            {
                CurrentBatState = BatState.Lamp;
                Debug.Log($"He tocado fondo{CurrentBatState.ToString()}");
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Se crea un rayo desde la cámara al punto donde está el ratón.
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            // Comprueba si el botón izquierdo del ratón es pulsado
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 25);
                myTransform.DOMove(hit.point, duration);
                // RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.08f, _back.value);
                // Debug.Log("Hit " + hitInfo.transform.tag);
                // bool hitBool = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                // if (hitBool)
                // {

                //     Debug.Log("Hit " + hitInfo.transform.tag);

                //     // if (hitInfo.transform.tag == "Back")
                //     // {
                //     //     Debug.Log("RAY fondo");
                //     // }
                // }
            }
            // Pinta un rayo para depurar
            // Debug.DrawRay(ray.origin, ray.direction, Color.green, 2);
        }
        // private void theEnd()
        // {
        //     isAnimationOver = true;
        // }
    }
}