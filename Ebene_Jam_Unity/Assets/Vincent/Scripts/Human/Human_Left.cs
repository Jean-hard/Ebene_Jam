using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Left : MonoBehaviour
{
    Rigidbody2D rb;
    public IntReference NbrHumansDead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 Initialize = new Vector3(3, 0, 0);
        transform.position = transform.position + Initialize * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector3 Initialize = new Vector3(1, 0, 0);
        transform.position = transform.position + Initialize * Time.deltaTime;
    }

    public void Die()
    {
        NbrHumansDead.Variable.Value++;
        Destroy(gameObject);
    }
}
