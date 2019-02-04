using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour {

    public EyeAttack eyeAttack;
    LegAttackScript legAttackScript;
    public GameObject EnemyLeg;
    public GameObject TempEnemy;

    private void Start()
    {
        legAttackScript = FindObjectOfType<LegAttackScript>();
        legAttackScript.StartAttack();
    }

    public void StartTimer()
    {
        StartCoroutine(EyeAttackTimer(TempEnemy));
    }

    public IEnumerator EyeAttackTimer(GameObject TempEnemy)
    {
        yield return new WaitForSeconds(1.5f);
        eyeAttack.ShootProjectile();
    }
     
  

}
