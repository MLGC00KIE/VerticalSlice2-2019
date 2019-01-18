using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLegAttack : MonoBehaviour {

    public GameObject EnemyLeg;   
    
    [SerializeField]
    private float speed;
    private float startTime;
    private float attackLength;
    private Vector3 travelSpeed;

    public void LegAttack()
    {
        travelSpeed = EnemyLeg.transform.up * 3;
        startTime = Time.time;
        attackLength = Vector3.Distance(EnemyLeg.transform.position, travelSpeed * speed);
        float distanceCovered = (Time.time - startTime) * speed;
        float fracLength = distanceCovered / attackLength;
        EnemyLeg.transform.position = Vector3.Lerp(EnemyLeg.transform.position, EnemyLeg.transform.position + EnemyLeg.transform.up * 0.5f, fracLength);
        Debug.Log("attacked");
    }

    public void LegRetreat()
    {
        startTime = Time.time;
        attackLength = Vector3.Distance(EnemyLeg.transform.position, travelSpeed * speed);
        float distanceCovered = (Time.time - startTime) * speed;
        float fracLength = distanceCovered / attackLength;
        EnemyLeg.transform.position = -Vector3.Lerp(EnemyLeg.transform.position, EnemyLeg.transform.position + EnemyLeg.transform.up * 0.5f, fracLength);
        Debug.Log("Retreaded");
    }
}
