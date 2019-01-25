using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballMovement : MonoBehaviour {
    
    public float Speed;
    Vector3 movement;

    private void Start()
    {
        movement = -transform.right;
    }
    void Update()
    {
        transform.position += movement * Speed * Time.deltaTime;
        
    }

    public void InverseMovement()
    {
        movement = new Vector3(transform.position.x * -1, 0, 0);
    }

}
    
        
    

    

