using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Bourgeon : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HumanL")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= 0.5f ;
        }
        if (collision.gameObject.tag == "HumanR")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= 0.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HumanL")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= 2;
        }
        if (collision.gameObject.tag == "HumanR")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= 2;
        }
    }

    IEnumerator Die()
    {
        GetComponent<Animator>().SetTrigger("Die");
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        yield return new WaitForSeconds(2);
        Destroy(transform.parent.gameObject);

    }
}
