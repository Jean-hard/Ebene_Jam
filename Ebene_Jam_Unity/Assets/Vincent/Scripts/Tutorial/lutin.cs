using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lutin : MonoBehaviour
{
    public Rigidbody2D rb;
    bool move;
    bool coroutine;

    public GameObject bud1;
    public GameObject bud2;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine("Move");
        StartCoroutine("Drop");
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position += new Vector3(0.007f, 0);
        }
        if (!move)
        {
            
            transform.position += new Vector3(-0.007f, 0);
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(1);
        move = !move;
        StartCoroutine("Move");
    }

    IEnumerator Drop()
    {
        yield return new WaitForSeconds(2.6f);
        Instantiate(bud1, transform.position, transform.rotation);
        yield return new WaitForSeconds(2.6f);
        Instantiate(bud2, transform.position, transform.rotation);
        StartCoroutine("Drop");

    }
}
