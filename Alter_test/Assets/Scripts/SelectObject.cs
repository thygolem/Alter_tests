using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class SelectObject : MonoBehaviour
{


    [SerializeField] Text _Object_text;

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
                // Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                Debug.Log("Hit " + hitInfo.transform.GetComponent<Text>().text);


                _Object_text.text = hitInfo.transform.GetComponent<Text>().text;

                if (hitInfo.transform.gameObject.tag == "Construction")
                {
                    // Debug.Log ("It's working!");
                }
                else
                {
                    // Debug.Log ("nopz");
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
