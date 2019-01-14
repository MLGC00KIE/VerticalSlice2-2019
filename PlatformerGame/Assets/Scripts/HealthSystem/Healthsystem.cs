using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthsystem : MonoBehaviour {
    private int Health;

	// Use this for initialization
	void Start () {
        Health = 3;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision PlayerHitBox)
    {
       if(PlayerHitBox.gameObject.tag == "EnemyAttack")
        {

        }        
    }
}
