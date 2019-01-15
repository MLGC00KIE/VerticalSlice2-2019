﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyeAttack : MonoBehaviour {

    public Transform Projectile;
    public int speed = 5;
	
	// Update is called once per frame
	void Update () {
        ShootProjectile();
	}

    public void ShootProjectile()
    {
        Projectile.transform.position += transform.right * speed * Time.deltaTime;
        Debug.Log("Projectile fired");
    }
}