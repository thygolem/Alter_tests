using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Scripts.Dislexia
{

    public class catchHit : MonoBehaviour
    {

        [SerializeField] TMP_Text _textoTMP;
        // use text mesh pro text

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Debug.Log("Mouse is down");

                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {
                    Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                    // Debug.Log("Hit " + hitInfo.transform.GetComponent<Text>().text);


                    // _textoTMP.text = hitInfo.transform.GetComponent<Text>().text;

                    if (hitInfo.transform.gameObject.tag == "BAT")
                    {
                        Debug.Log ("CATCH!");
                    }
                    else
                    {
                        Debug.Log ("nopz");
                    }
                }
                else
                {
                    //  Debug.Log("No hit");
                }
                // Debug.Log("Mouse is down");
            }
        }
    }
}