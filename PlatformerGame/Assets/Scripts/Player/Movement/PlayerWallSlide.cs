using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlide : MonoBehaviour {

    private bool isWallSliding = false;

    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }


    // Update is called once per frame
    void Update () {
            CheckWallSlide();
	}

    public void WallSlide(bool input)
    {
        isWallSliding = input;
    }

    void CheckWallSlide()
    {
        
    }
}
