using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField]
    private int lives = 2;

    private EyeAttack eye;
    [SerializeField]
    private GameObject leg;

    Collider2D bossColl;

    Animator anim;

    Transform bossEye;

    bool shot = false;
    bool didLegAttack = false;

    bool isLastShot = false;

    IEnumerator missedAttackTimer;


    // idle 2 sec
    // shoot low
    // if shot back lives-1 else shoot again till shot back
    // transform
    // idle 2 sec
    // leg attack
    // idle 2 sec
    // shoot high
    // if shot back lives-1
    // die


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        eye = GetComponent<EyeAttack>();
        bossColl = GetComponent<Collider2D>();
        StartCoroutine(Shoot());
        missedAttackTimer = RestartTimer();
    }

    private void Update()
    {
        if (lives == 2 && !shot)
        {
            StartCoroutine(Shoot());
        } else if(lives == 1 && !shot && !didLegAttack)
        {
            StartCoroutine(LegAttack());
        } else if (lives == 1 && !shot && didLegAttack)
        {
            isLastShot = true;
            StartCoroutine(Shoot());
        } else if(lives == 0)
        {
            SceneManager.LoadSceneAsync("MainMenu");
        }

        if (bossEye != null)
        {
            if (bossEye.position.x >= 0.35f && shot && bossEye.tag == "reflectedProjectile")
            {
                shot = false;
                lives -= 1;
                Destroy(bossEye.gameObject);
                StopCoroutine(missedAttackTimer);
            }
        }
        Debug.Log(lives);

    }

    public IEnumerator Shoot()
    {
        shot = true;
        yield return new WaitForSeconds(2);
        anim.SetTrigger("doShoot");
        yield return new WaitForSeconds(2);
        eye.ShootProjectile();
        bossEye = GameObject.FindGameObjectWithTag("projectile").transform;
        if(isLastShot)
        {
            anim.SetTrigger("doTransform");
            yield return new WaitForSeconds(2.5f);
            anim.speed = 0;
        }
        StartCoroutine(missedAttackTimer);
    }

    public IEnumerator LegAttack()
    {
        anim.SetTrigger("doAttack");
        didLegAttack = true;
        leg.SetActive(true);
        leg.GetComponent<Animator>().SetTrigger("doAttack");
        yield return new WaitForSeconds(1.5f);
        if (leg != null)
            leg.SetActive(false);
    }


    private IEnumerator RestartTimer()
    {
        yield return new WaitForSeconds(4);
        shot = false;
        Destroy(bossEye.gameObject);
    }
}
