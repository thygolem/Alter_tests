using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Hover : MonoBehaviour
{

    // public Material MainMaterial;
    Color color;

    private Renderer Cube;




    void Start()
    {
        Cube = GetComponent<Renderer>();


    }

    void OnMouseEnter()
    {
        color = Cube.material.color;
        Cube.material.color = Color.red;
    }

    void OnMouseExit()
    {
        Cube.material.color = color;
        // Cube.material = MainMaterial;
    }
}
