using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Healthsystem : MonoBehaviour {
    public int Health;

    public GameObject upperLeft;
    public GameObject upperRight;

    Animator anim;
  

    // Use this for initialization
    void Start () {
        Health = 3;
        anim = GetComponentInChildren<Animator>();
	}

    //private void OnCollisionEnter(Collision PlayerHitBox)
    //{
    //    if (PlayerHitBox.gameObject.tag == "EnemyAttack")
    //    {
    //        Health = Health - 1;
    //    }
    //}

    public void GetHit()
    {
        Health = Health - 1;
    }

// Update is called once per frame
    void Update () {
        if(Health == 2)
        {
            upperLeft.transform.position = new Vector3(-7.78f, 3.17f, -0.1f);
            upperRight.transform.position = new Vector3(7.78f, 3.17f, -0.1f);
        }

        if(Health == 1)
        {
            upperLeft.transform.position = new Vector3(-5.4f, 1.81f, -0.1f);
            upperRight.transform.position = new Vector3(5.4f, 1.81f, -0.1f);
        }

        if (Health == 0)
        {
            StartCoroutine(Die());
        }
	}

    IEnumerator Die()
    {
        anim.SetTrigger("doDie");
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync("MainMenu");
    }

      
    
}
