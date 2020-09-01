using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father_Bourgeon : MonoBehaviour
{
    public float delay;

    // Start is called before the first frame update
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
        transform.GetChild(0).GetComponent<Slow_Bourgeon>().StartCoroutine("Die");
       
    }
}
