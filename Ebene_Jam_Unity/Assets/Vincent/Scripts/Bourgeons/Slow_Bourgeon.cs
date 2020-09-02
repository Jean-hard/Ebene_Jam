using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Bourgeon : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HumanL")
        {
            Vector2 collisionVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            Vector2 newVelocity = new Vector2(0.5f, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = newVelocity;
        }
        if (collision.gameObject.tag == "HumanR")
        {
            Vector2 collisionVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            Vector2 newVelocity = new Vector2(-0.5f, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = newVelocity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HumanL")
        {
            Vector2 collisionVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            Vector2 newVelocity = new Vector2(1, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = newVelocity;
        }
        if (collision.gameObject.tag == "HumanR")
        {
            Vector2 collisionVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            Vector2 newVelocity = new Vector2(-1, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = newVelocity;
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
