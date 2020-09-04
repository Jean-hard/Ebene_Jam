using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucheDad2 : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 shot = new Vector2(0, -20);
        rb.AddForce(shot, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            //sFXManager.As.clip = sFXManager.effects[2];
            //sFXManager.As.Play();
        }

        // Inverser la vitesse 
        if (collision.gameObject.tag == "HumanR")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = -collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            collision.gameObject.GetComponent<Human_Right>().buched = !collision.gameObject.GetComponent<Human_Right>().buched;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "HumanL")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = -collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            collision.gameObject.GetComponent<Human_Left>().buched = !collision.gameObject.GetComponent<Human_Left>().buched;
            Destroy(gameObject);
        }
    }
}
