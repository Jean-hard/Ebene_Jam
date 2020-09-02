using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_AttractBourgeon : MonoBehaviour
{
    // Enfant du bourgeon Attract, il a pour rôle de stopper les humains au contact de son trigger.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HumanR")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if (collision.gameObject.tag == "HumanL")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
