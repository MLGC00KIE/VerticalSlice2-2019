using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflect : MonoBehaviour
{
    GameObject DeflectableObject;
    public int deflectedSpeed;

    void Update()
    {


    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Deflect")
            {
                GameObject disableScript = GameObject.Find("DeflectableObject");
                disableScript.GetComponent<tempMove>().enabled = false;
                transform.position += transform.right * deflectedSpeed * Time.deltaTime;
                Debug.Log("collide");
            }
        }
    }
