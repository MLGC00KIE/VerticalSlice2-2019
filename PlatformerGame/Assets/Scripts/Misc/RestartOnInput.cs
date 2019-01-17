using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnInput : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		
        if(Input.anyKeyDown)
        {
            // replace number with scene number
            SceneManager.LoadSceneAsync("");
        }

	}
}
