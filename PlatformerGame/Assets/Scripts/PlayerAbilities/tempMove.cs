using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempMove : MonoBehaviour {
    
    public float Speed;
    void Update()
    {
        transform.position += -transform.right * Speed * Time.deltaTime;
        
    }

}
    
        
    

    

