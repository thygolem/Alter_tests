using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;






namespace Scripts.TrainDixa
{
    public class PlayerTracker : MonoBehaviour
    {

        [SerializeField, Tooltip("Ease method to use")] Ease ease = Ease.InSine;

        [SerializeField, Range(0.1f, 2f)] float duration = 0.5f;

        [SerializeField, Tooltip("Must wait previous animation to end?")] bool mustWaitUntilEnd = true;

        Transform myTransform;

        new Camera camera;

        bool isAnimationOver;

        private void Awake()
        {
            isAnimationOver = true;

            myTransform = transform;

            camera = Camera.main;

        }

        private void Update() {

            // Se crea un rayo desde la cámara al punto donde está el ratón.
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            // Comprueba si el botón izquierdo del ratón es pulsado
            if (Input.GetMouseButtonDown(0))
            {
                // Recoge la información del choque, si existe.
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 25);
                // Se recomienda hacer tablas de verdad para diseñar la lógica.
                // Debemos ejecutar la animación:
                //         Si bien el usuario divce que no espere
                //         Si bien el usuario dice que espere y ha terminado la anterior

                if (hit && ((isAnimationOver && mustWaitUntilEnd) || !mustWaitUntilEnd))
                {
                    isAnimationOver = false;
                    myTransform.DOMove(hit.point, duration)
                                .SetEase(ease)
                                .OnComplete(() => {isAnimationOver = true;} ); // función lambda (anónimas)
                                // se usan a veces para hacer consultas.
                }
            }
            // Pinta un rayo para depurar
            Debug.DrawRay(ray.origin, ray.direction, Color.green, 2);
        }

        private void theEnd()
        {
            isAnimationOver = true;
        }
    }

}