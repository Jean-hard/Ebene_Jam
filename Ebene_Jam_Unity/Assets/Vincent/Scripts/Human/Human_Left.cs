using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Left : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    public IntReference NbrHumansEscape;
    public IntReference NbrHumansDead;
    [HideInInspector]
    public bool slowed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }


    public void Escape()
    {
        NbrHumansEscape.Variable.Value++;
        Destroy(gameObject);
    }

    public void Die()
    {
        NbrHumansDead.Variable.Value++;
        Destroy(gameObject);
    }
}
