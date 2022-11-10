using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ISoundMaker
{
    // defino el contrato de la interfaz
    void MakeSound();

}


public class Crow : ISoundMaker
{
    private int numberOfAaaaarghs;

    public Crow(int number)
    {
        this.numberOfAaaaarghs = number;
    }

    public void MakeSound()
    {
        for (int i = 0; i < numberOfAaaaarghs; i++)
        {
            Debug.Log("Aaaargh");
        }
    }

}


public class Owl : ISoundMaker
{

    public void MakeSound()
    {
            Debug.Log("Uhhhh");
    }

}


public class Duck : ISoundMaker
{

    public void MakeSound()
    {
            Debug.Log("Cuac cuac");
    }

}


public class Ejercicio72 : MonoBehaviour
{
    private void Awake()
    {
        ISoundMaker soundMaker = new Crow(3);
        soundMaker.MakeSound();


        soundMaker = new Owl();
        soundMaker.MakeSound();


        soundMaker = new Duck();
        soundMaker.MakeSound();

    }
}
