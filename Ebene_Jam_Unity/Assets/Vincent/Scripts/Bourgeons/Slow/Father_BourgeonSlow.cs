using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father_BourgeonSlow : MonoBehaviour
{
    public float delay;
    public float deathDelay;
    public GameObject particleSlow;

    // Père du Bourgeon Slow, il décide quand l'activer ainsi que sa durée effective. 
    void Start()
    {
        StartCoroutine("Wait");
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(delay);
        transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Animator>().SetTrigger("Open");
        transform.GetChild(0).GetComponent<Animator>().SetTrigger("Open");
        Instantiate(particleSlow, transform.position, transform.rotation);
        yield return new WaitForSeconds(deathDelay);
        transform.GetChild(0).GetComponent<Slow_Bourgeon>().StartCoroutine("Die");
       
    }
}
