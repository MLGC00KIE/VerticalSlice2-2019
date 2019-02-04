using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeAttack : MonoBehaviour
{

    public Rigidbody2D Projectile;
    public float speed = 7.0f;

    [SerializeField]
    private Transform eyePos;

    public void ShootProjectile()
    {
        
        Rigidbody2D instantiatedProjectile = Instantiate(Projectile, eyePos.position, transform.rotation)as Rigidbody2D;
        instantiatedProjectile.velocity = Vector2.left * speed;
    }    
}
