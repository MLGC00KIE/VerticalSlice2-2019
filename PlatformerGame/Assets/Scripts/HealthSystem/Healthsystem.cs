using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthsystem : MonoBehaviour {
    public int Health;

    public GameObject upperLeft;
    public GameObject upperRight;
  

    // Use this for initialization
    void Start () {
        Health = 3;	
	}

    private void OnCollisionEnter(Collision PlayerHitBox)
    {
        if (PlayerHitBox.gameObject.tag == "EnemyAttack")
        {
            Health = Health - 1;
        }
    }

// Update is called once per frame
    void Update () {
        if(Health == 2)
        {
            upperLeft.transform.position = new Vector3(-9.23f, 5, 0.1000408f);
            upperRight.transform.position = new Vector3(9.23f, 5, 0.1000408f);
        }

        if(Health == 1)
        {
            upperLeft.transform.position = new Vector3(7.5f, 3, 0.1000408f);
            upperRight.transform.position = new Vector3(-7.5f, 3, 0.1000408f);
        }

        if (Health == 0)
        {
            //Play death animation
            //Switch scene
        }
	}

      
    
}
