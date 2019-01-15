using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLegAttack : MonoBehaviour {

    public GameObject EnemyLeg;//reference to the leg
    public float LegAttackHeight;//the speed at wich the leg goes up


    private void Start()
    {
        StartCoroutine(AttackTimer(EnemyLeg));
    }

    private IEnumerator AttackTimer(GameObject EnemyLeg)
    {
        LegAttack();  Debug.Log("Attacked");
        yield return new WaitForSeconds(3.5f);//wait certain amount of time before retreating the leg
        LegRetreat(); Debug.Log("Retreaded");
    }

    void LegAttack()
    {
        EnemyLeg.transform.position += transform.up * LegAttackHeight * Time.deltaTime;
    }

    void LegRetreat()
    {
        EnemyLeg.transform.position += -transform.up * LegAttackHeight * Time.deltaTime;
    }
}
