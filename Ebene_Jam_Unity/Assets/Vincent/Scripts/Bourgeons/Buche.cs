using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buche : MonoBehaviour
{

    public float duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject, duration);
        }

        // Inverser la vitesse 
        if(collision.gameObject.tag == "HumanR")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = -collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            collision.gameObject.GetComponent<Human_Right>().buched = !collision.gameObject.GetComponent<Human_Right>().buched;
            print(collision.gameObject.GetComponent<Human_Right>().buched);
        }
        if (collision.gameObject.tag == "HumanL")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = -collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            collision.gameObject.GetComponent<Human_Left>().buched = !collision.gameObject.GetComponent<Human_Left>().buched;
        }
    }
}
