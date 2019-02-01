using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlide : MonoBehaviour {

    private bool isWallSliding = false;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update () {
        if (isWallSliding == true)
            DoWallSlide();
	}

    public void WallSlide(bool input)
    {
        isWallSliding = input;
    }

    void DoWallSlide()
    {
        anim.Play("WallSlide");
        Debug.Log("sliding animation...");
    }
}
