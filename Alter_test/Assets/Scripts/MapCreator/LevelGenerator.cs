// code: https://www.youtube.com/watch?v=xbHOuq0RuhI&ab_channel=GeekerEN


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] Texture2D texture;
    [SerializeField] GameObject blackPrefab; 
    [SerializeField] GameObject redPrefab; 

    private void Start()
    {
        // Texture2D texture = Resources.Load<Texture2D>("Map/"+mapIndex);
        Color color;
        Debug.Log(texture);
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                color = texture.GetPixel(x, y);

                switch(color.ToString())
                {
                    case "RGBA(0.000, 0.000, 0.000, 1.000)": // cuanto mas alfa más alto.
                        // Debug.Log("Black");
                        Instantiate(blackPrefab, new Vector3(x + 0.5f, y + 0.5f), Quaternion.identity);
                        break;
                    case "RGBA(0.000, 0.000, 0.000, 0.000)":
                        Debug.Log("Transparent");
                        break;
                    // case "RGBA(0.000, 0.000, 0.000, 1.000)":
                    //     break;
                    // case "RGBA(0.000, 0.000, 0.000, 1.000)":
                    //     break;
                    // case "RGBA(0.000, 0.000, 0.000, 1.000)":
                    //     break;
                    // case "RGBA(0.000, 0.000, 0.000, 1.000)":
                    //     break;
                }

                
            }
        }

    }




}
