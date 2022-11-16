using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------------------------------------------------------------

    // Este script se encarga de manejar la interfaz que representa la mirada/mano del jugador. 
    
    // Será el responsable de seleccionar el objeto requerido.

// ----------------------------------------------------------------

public class InputAxis : MonoBehaviour
{

    [SerializeField] int speed = 5; // Cambiar speed cuando el jugador tenga mejor nivel.
    private void Update()
    {
    //     var horizontal = Input.GetAxis("Horizontal");
    //     var vertical = Input.GetAxis("Vertical");

        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        transform.position = new Vector3(horizontal * speed, vertical * speed, 0);
        // En el INPUT MANAGER:
            // El tiempo que tarda en moverse es Sensitivity 
            // El tiempo que tarda en pararse es Gravity 
    }
}
