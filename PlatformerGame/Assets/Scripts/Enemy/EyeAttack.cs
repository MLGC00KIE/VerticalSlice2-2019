using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeAttack : MonoBehaviour
{

    public Rigidbody2D Projectile;
    public Transform target;
    public float speed = 7.0f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void ShootProjectile()
    {
        
        Rigidbody2D instantiatedProjectile = Instantiate(Projectile, transform.position, transform.rotation)as Rigidbody2D;
        instantiatedProjectile.velocity = (target.position - transform.position).normalized * speed;
        Debug.Log("That's a lot of damage");
    }    
}
