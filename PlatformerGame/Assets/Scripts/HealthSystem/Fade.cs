using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
    public GameObject fade;
    

    void Start()
    {
       
    }
    
    void OnCollisionEnter(Collision PlayerHitBox)
    {
        if (PlayerHitBox.gameObject.tag == "EnemyAttack")
        {
            fade.transform.position = new Vector3(0, 0, 0);
        }
        else  {
            fade.transform.position = new Vector3(0, 15, 0);
        }
    }
    
        
    }
