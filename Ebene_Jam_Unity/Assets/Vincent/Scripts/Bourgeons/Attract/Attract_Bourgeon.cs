using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract_Bourgeon : MonoBehaviour
{
    private List<GameObject> humans ;

    private void Start()
    {
        humans = new List<GameObject>();
    }

    /* Ce script représente l'effet du bourgeon Attract. Au contact, l'humain se déplacera lentement vers le bourgeon (puis s'arretera au contact du trigger de son enfant).
     * Lorsque le bourgeon meurt, il redonne la vitesse initiale des humains ayant été attirés.     */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HumanR")
        {
            humans.Add(collision.gameObject);
            GameObject human = collision.gameObject;
            if (human.transform.position.x > transform.position.x)
            {
                human.GetComponent<Rigidbody2D>().velocity = human.GetComponent<Rigidbody2D>().velocity;
            }

            if (human.transform.position.x < transform.position.x)
            {
                human.GetComponent<Rigidbody2D>().velocity = -human.GetComponent<Rigidbody2D>().velocity;
            }

        }

        if (collision.gameObject.tag == "HumanL")
        {
            humans.Add(collision.gameObject);
            GameObject human = collision.gameObject;
            if (human.transform.position.x > transform.position.x)
            {     
                human.GetComponent<Rigidbody2D>().velocity = -human.GetComponent<Rigidbody2D>().velocity;
            }

            if (human.transform.position.x < transform.position.x)
            {
                human.GetComponent<Rigidbody2D>().velocity = human.GetComponent<Rigidbody2D>().velocity;
            }

        }
    }

    IEnumerator Die()
    {
        GetComponent<Collider2D>().enabled = false;
        transform.GetChild(0).gameObject.GetComponent<Collider2D>().enabled = false;
        foreach (GameObject human in humans)
        {
            if(human.gameObject.tag == ("HumanR"))
            {
                human.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
            }

            if (human.gameObject.tag == ("HumanL"))
            {
                human.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
            }
        }
        transform.parent.gameObject.GetComponent<ParticleSystem>().Stop();
        Color color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(2);

        Destroy(transform.parent.gameObject);
    }
}
