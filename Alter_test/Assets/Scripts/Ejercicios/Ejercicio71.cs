using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface I2DShape
{
    // Defino el contrato de la interfaz
    float GetArea();
    float GetLength();

}


public class Circle : I2DShape // circle es el firmate del contrato I2DShape
{
    float radio;

    // constructor de clase publico 
    public Circle(float radio)
    {   
        // la palabra clave this hace referencia a uno mismo
        //    Sirve para poder repetir el mismo nombre
        this.radio = radio;
    }

    public float GetArea()
    {
        return Mathf.PI * radio * radio;
    }

    public float GetLength()
    {
        return 2 * Mathf.PI * radio;
    }
}

public class Rectangle : I2DShape // circle es el firmate del contrato I2DShape
{
    float height, width;

    // constructor de clase publico 
    public Rectangle(float width, float height)
    {
        this.width = width;
        this.height = height;
    }

    public float GetArea()
    {
        return width * height;
    }

    public float GetLength()
    {
        return 2 * (height + width) ;
    }
}

public class Ejercicio71 : MonoBehaviour
{

    private void Awake()
    {
        // esto es un constructor. Se crea con New. 
        //      Hace espacio en memoria para ese objeto.
        I2DShape shape = new Circle(radio:4f);
        Debug.Log($"AREA CIR, {shape.GetArea()}");
        Debug.Log($"LONGITUD CIR, {shape.GetLength()}");



        shape = new Rectangle(height:4f, width:2f);
        Debug.Log($"AREA RECT, {shape.GetArea()}");
        Debug.Log($"LONGITUD RECT, {shape.GetLength()}");



    }


}
