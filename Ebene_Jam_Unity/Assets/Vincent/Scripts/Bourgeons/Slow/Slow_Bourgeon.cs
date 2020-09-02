using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Bourgeon : MonoBehaviour
{
   public FloatReference coefSlow;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HumanL")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= coefSlow.Value;
            collision.gameObject.GetComponent<Human_Left>().slowed = true;
        }
        if (collision.gameObject.tag == "HumanR")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= coefSlow.Value;
            collision.gameObject.GetComponent<Human_Right>().slowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HumanL")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= (1/ coefSlow.Value);
            collision.gameObject.GetComponent<Human_Left>().slowed = false;
        }
        if (collision.gameObject.tag == "HumanR")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= (1/ coefSlow.Value);
            collision.gameObject.GetComponent<Human_Right>().slowed = false;
        }
    }

    IEnumerator Die()
    {
        //GetComponent<Animator>().SetTrigger("Die");
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        yield return new WaitForSeconds(2);
        Destroy(transform.parent.gameObject);

    }
}
