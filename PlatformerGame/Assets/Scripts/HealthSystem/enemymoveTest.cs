using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemymoveTest : MonoBehaviour {

    public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += -transform.right * speed * Time.deltaTime;
	}
    private void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
