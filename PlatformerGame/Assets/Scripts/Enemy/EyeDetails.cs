using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeDetails : MonoBehaviour {

    private Transform target;
    public int speed = 10;
	
    private void Awake()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            //Destroy(GameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceToTarget = speed * Time.deltaTime;

        if (dir.magnitude <= distanceToTarget)
        {
            TargetHit();
        }
	}

    void TargetHit()
    {
        Debug.Log(" fired");

    }
}
