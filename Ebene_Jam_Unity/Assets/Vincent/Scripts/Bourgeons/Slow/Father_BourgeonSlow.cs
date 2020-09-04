using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father_BourgeonSlow : MonoBehaviour
{
    public float delay;
    public float deathDelay;
    public GameObject particleSlow;

    public int slowType;

    // Père du Bourgeon Slow, il décide quand l'activer ainsi que sa durée effective. 
    void Start()
    {
        if (slowType == 1)
        {
            StartCoroutine("Wait");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (slowType == 2)
        {
            if (collision.gameObject.tag == "HumanL")
            {
                if (collision.gameObject.GetComponent<Human_Left>().isEcolo)
                {
                    collision.gameObject.GetComponent<Human_Left>().StartCoroutine("Slowed");
                    Destroy(gameObject);
                }
                //GetComponent<Animator>().SetTrigger("Open");
                //transform.GetChild(0).GetComponent<Animator>().SetTrigger("Open");
                //Instantiate(particleSlow, transform.position, transform.rotation);
                return;
            }
            if (collision.gameObject.tag == "HumanR")
            {
                if (collision.gameObject.GetComponent<Human_Right>().isEcolo)
                {
                    collision.gameObject.GetComponent<Human_Right>().StartCoroutine("Slowed");
                    Destroy(gameObject);
                }
                //GetComponent<Animator>().SetTrigger("Open");
                //transform.GetChild(0).GetComponent<Animator>().SetTrigger("Open");
                //Instantiate(particleSlow, transform.position, transform.rotation);
                return;
            }
            if (collision.gameObject.tag == "Ground")
            {
                Destroy(gameObject);
                //GetComponent<Animator>().SetTrigger("Open");
                //transform.GetChild(0).GetComponent<Animator>().SetTrigger("Open");
                //Instantiate(particleSlow, transform.position, transform.rotation);
                return;
            }
        }
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(delay);
        transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
        GetComponent<Animator>().SetTrigger("Open");
        transform.GetChild(0).GetComponent<Animator>().SetTrigger("Open");
        Instantiate(particleSlow, transform.position, transform.rotation);
        yield return new WaitForSeconds(deathDelay);
        transform.GetChild(0).GetComponent<Slow_Bourgeon>().StartCoroutine("Die");
       
    }

    IEnumerator ChildDeath()
    {
        yield return new WaitForSeconds(deathDelay);
        transform.GetChild(0).GetComponent<Slow_Bourgeon>().StartCoroutine("Die");
    }
}
