using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {
    private int Health;
    public bool Dead;
	// Use this for initialization
	void Start () {
        Health = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health = Health - 1;
            Debug.Log("hit");
        }
        

	}
}
