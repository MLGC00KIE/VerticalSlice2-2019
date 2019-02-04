using UnityEngine;
using System.Collections;

public class LegAttackScript : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    EnemyAttacks enemyAttacks;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    bool up = true, move = false;

    void Start()
    {
        enemyAttacks = FindObjectOfType<EnemyAttacks>();
        setUp();
    }

    void setUp()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

        if(up && move)
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        else if (!up && move)
            transform.position = Vector3.Lerp(endMarker.position, startMarker.position, fracJourney); 

        if (Vector3.Distance(transform.position, endMarker.position) == 0)
        {
            StartCoroutine(Wait());
        } else if (Vector3.Distance(transform.position, startMarker.position) == 0 && !up) {
            move = false;
            up = true;
            enemyAttacks.StartTimer();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.5f / 2f);
        up = false;
        setUp();
    }

    public void StartAttack()
    {
        move = true;
    }
}