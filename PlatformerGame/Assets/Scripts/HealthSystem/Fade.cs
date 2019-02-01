using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
    public GameObject fade;
    public float flashTime = 0.1f;

    void Start()
    {
       
    }

    void OnCollisionEnter(Collision playerHitBox)
    {
        if (playerHitBox.gameObject.tag == "EnemyAttack")
        {
            StartCoroutine(HitFlash());
        }
    }

    IEnumerator HitFlash()
    {
        fade.transform.position = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(flashTime);

        fade.transform.position = new Vector3(0, 15, 10);
    }
    /*
    private void OnCollisionExit(Collision playerHitBox)
    {
        if (playerHitBox.gameObject.tag == "EnemyAttack")
        {
            fade.transform.position = new Vector3(0, 15, 0);
        }
    }
    */
}
