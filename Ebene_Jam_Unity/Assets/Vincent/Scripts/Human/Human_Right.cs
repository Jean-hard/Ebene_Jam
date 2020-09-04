using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Right : MonoBehaviour
{
    Rigidbody2D rb;
    public FloatReference speedRef;
    public float speed;
    private Vector2 oldVelocity;

    public bool isEcolo = false;

    public IntReference NbrHumansEscape;
    public IntReference NbrHumansDead;

    public IntReference NbrEcoloEscape;
    public IntReference NbrEcoloDead;

    [HideInInspector]
    public bool slowed;
    public int nbrSlowed =0;
    public FloatReference coefSlow;
    public float timeSlowed;
    [HideInInspector]
    public bool buched;



    // Start is called before the first frame update
    void Start()
    {
        speed = -Random.Range(speedRef.Value + 0.15f, speedRef.Value - 0.15f);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        oldVelocity = rb.velocity;
        GetComponent<SpriteRenderer>().flipX = true;


    }

    void Update()
    {

        if (rb.velocity.x != oldVelocity.x)
        {
            if (rb.velocity.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            if (rb.velocity.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        oldVelocity = rb.velocity;
    }


    public void Escape()
    {
        if (!isEcolo)
        {
            NbrHumansEscape.Variable.Value++;
            Destroy(gameObject);
        }

        if (isEcolo)
        {
            NbrEcoloEscape.Variable.Value++;
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        if (!isEcolo)
        {
            NbrHumansDead.Variable.Value++;
            Destroy(gameObject);
        }

        if (isEcolo)
        {
            NbrEcoloDead.Variable.Value++;
            Destroy(gameObject);
        }
    }

    IEnumerator Slowed()
    {
        if (!slowed)
        {
            slowed = true;
            nbrSlowed++;
            rb.velocity *= coefSlow.Value;
            yield return new WaitForSeconds(timeSlowed);
            rb.velocity /= coefSlow.Value;
            nbrSlowed--;
            slowed = false;
        }
        
    }
}
