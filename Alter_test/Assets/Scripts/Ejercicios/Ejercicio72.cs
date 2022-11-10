using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ISoundMaker
{
    bool MakeSound();

    // bool Crow();
    // bool Owl();
    // bool Duck();
}


public class Crow : ISoundMaker
{
    private bool noise;

    public Crow(bool noise)
    {
        this.noise = noise;
    }

    public bool MakeSound()
    {
        return noise;
    }
}


public class Owl : ISoundMaker
{
    private bool noise;

    public Owl(bool noise)
    {
        this.noise = noise;
    }

    public bool MakeSound()
    {
        return noise;
    }
}


public class Duck : ISoundMaker
{
    private bool noise;

    public Duck(bool noise)
    {
        this.noise = noise;
    }

    public bool MakeSound()
    {
        return noise;
    }
}










public class Ejercicio72 : MonoBehaviour
{
    private void Awake()
    {
        ISoundMaker sound = new Crow(noise:true);
        Debug.Log($"Play crow");
        
        sound = new Owl(noise:true);
        Debug.Log($"Play owl");

        sound = new Duck(noise:true);
        Debug.Log($"Play duck");
    }
}
