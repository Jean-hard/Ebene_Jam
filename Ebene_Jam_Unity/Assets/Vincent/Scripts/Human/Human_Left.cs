using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Left : MonoBehaviour
{
    Rigidbody2D rb;
    public FloatReference speedRef;
    public float speed;
    
    public bool isEcolo = false;

    public IntReference NbrHumansEscape;
    public IntReference NbrHumansDead;

    public IntReference NbrEcoloEscape;
    public IntReference NbrEcoloDead;

    [HideInInspector]
    public bool slowed;
    [HideInInspector]
    public bool buched;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speedRef.Value + 0.15f, speedRef.Value - 0.15f);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
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
}
