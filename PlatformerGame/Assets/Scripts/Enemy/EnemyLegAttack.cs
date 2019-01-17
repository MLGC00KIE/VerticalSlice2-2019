using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLegAttack : MonoBehaviour {

    public GameObject EnemyLeg;//reference to the leg
    public float LegAttackHeight;//the speed at wich the leg goes up
    public float LegAttackSpeed;

    public void LegAttack()
    {
        EnemyLeg.transform.position += transform.up * LegAttackHeight * LegAttackSpeed;
        Debug.Log("attacked");
    }

    public void LegRetreat()
    {
        EnemyLeg.transform.position += -transform.up * LegAttackHeight * LegAttackSpeed;
        Debug.Log("Retreaded");
    }
}
