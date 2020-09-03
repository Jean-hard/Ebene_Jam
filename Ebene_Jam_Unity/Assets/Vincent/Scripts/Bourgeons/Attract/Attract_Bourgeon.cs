using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract_Bourgeon : MonoBehaviour
{
    private List<GameObject> humans ;
    public FloatReference coefSlow;
    public FloatReference speed;

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
            if (human != null)
            {
                human.GetComponent<Human_Right>();
                if (human.GetComponent<Human_Right>() != null)
                {
                    //-------------------------------------------------- REDONNE VITESSE HUMAIN DROITE -------------------
                    Human_Right scriptHuman = human.GetComponent<Human_Right>();
                    bool isSlowed = scriptHuman.slowed;
                    bool isBuched = scriptHuman.buched;

                    if (!isSlowed)
                    {
                        if (!isBuched)
                        {
                            human.GetComponent<Rigidbody2D>().velocity = new Vector2(scriptHuman.speed, 0);
                        }
                        if (isBuched)
                        {
                            human.GetComponent<Rigidbody2D>().velocity = new Vector2(-scriptHuman.speed, 0);
                        }
                    }
                    if (isSlowed)
                    {
                        if (!isBuched)
                        {
                            human.GetComponent<Rigidbody2D>().velocity = new Vector2(scriptHuman.speed * coefSlow.Value, 0);
                        }
                        if (isBuched)
                        {
                            human.GetComponent<Rigidbody2D>().velocity = new Vector2(-scriptHuman.speed * coefSlow.Value, 0);
                        }
                    }
                }


                human.GetComponent<Human_Left>();
                if (human.GetComponent<Human_Left>() != null)
                {
                    //-------------------------------------------------- REDONNE VITESSE HUMAIN GAUCHE -------------------
                    Human_Left scriptHuman = human.GetComponent<Human_Left>();
                    bool isSlowed = scriptHuman.slowed;
                    bool isBuched = scriptHuman.buched;

                    if (!isSlowed)
                    {
                        if (!isBuched)
                        {
                            human.GetComponent<Rigidbody2D>().velocity = new Vector2(scriptHuman.speed, 0);
                        }
                        if (isBuched)
                        {
                            human.GetComponent<Rigidbody2D>().velocity = new Vector2(-scriptHuman.speed, 0);
                        }
                    }
                    if (isSlowed)
                    {
                        if (!isBuched)
                        {
                            human.GetComponent<Rigidbody2D>().velocity = new Vector2(scriptHuman.speed * coefSlow.Value, 0);
                        }
                        if (isBuched)
                        {
                            human.GetComponent<Rigidbody2D>().velocity = new Vector2(-scriptHuman.speed * coefSlow.Value, 0);
                        }
                    }
                }
            }

            //if(human.gameObject.tag == ("HumanR"))
            //{
            //    if (human.GetComponent<Human_Right>().slowed == false)
            //    {
            //        human.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
            //    }
            //}

            //if (human.gameObject.tag == ("HumanL"))
            //{
            //    human.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
            //}
        }
        transform.parent.gameObject.GetComponent<ParticleSystem>().Stop();
        Color color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(2);

        Destroy(transform.parent.gameObject);
    }
}
