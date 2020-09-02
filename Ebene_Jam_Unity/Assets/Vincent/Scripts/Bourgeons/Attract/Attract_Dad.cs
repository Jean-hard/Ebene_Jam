using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract_Dad : MonoBehaviour
{
    public float delay;
    public float deathDelay;

    //Père du bourgeon attract, il décide quand activer le bourgeon attract ainsi que sa durée effective.
    void Start()
    {
        transform.GetChild(0).gameObject.GetComponent<Collider2D>().enabled = false; 
        transform.GetChild(0).transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(delay);
        GetComponent<ParticleSystem>().Play();
        transform.GetChild(0).gameObject.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(deathDelay);
        transform.GetChild(0).GetComponent<Attract_Bourgeon>().StartCoroutine("Die");
    }
}
