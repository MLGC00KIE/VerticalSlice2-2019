using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour {

    public EyeAttack eyeAttack;
    public EnemyLegAttack enemyLegAttack;

    public int GetRandomNumber(int lowestNumber, int highestNumber)
    {
        return Random.Range(lowestNumber, highestNumber);
       
    }
  
    private void Update()
    {
        int randomNumber = GetRandomNumber(0,20);
        if (randomNumber < 0 && randomNumber < 11)
        {
            
        } else
        {

        }
    }

}
