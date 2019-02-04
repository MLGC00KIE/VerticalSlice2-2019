using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflect : MonoBehaviour
{
    GameObject DeflectableObject;
    [SerializeField]
    private float deflectSpeed;

    [SerializeField]
    private Healthsystem HS;
    [SerializeField]
    private Fade fade;

    Animator anim;

    Rigidbody2D projectile;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        HS = GetComponent<Healthsystem>();
        fade = GetComponent<Fade>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "projectile" && Input.GetMouseButton(0))
        {
            anim.SetTrigger("doAirDeflect");
            projectile = col.gameObject.GetComponent<Rigidbody2D>();
            projectile.velocity = Vector2.zero;
            projectile.velocity = Vector2.right * deflectSpeed;
            col.gameObject.tag = "reflectedProjectile";

        } else if(col.gameObject.tag == "projectile" || col.gameObject.tag == "leg")
        {
            HS.GetHit();
            fade.DoHitFlash();
            Destroy(col.gameObject);
        }
    }
}
