using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Bourgeon : MonoBehaviour
{
    public FloatReference coefSlow;

    public SFXManager sFXManager;

    void Awake()
    {
        sFXManager = FindObjectOfType<SFXManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            sFXManager.As.clip = sFXManager.effects[3];
            sFXManager.As.Play();
        }

        if (collision.gameObject.tag == "HumanL")
        {
            Human_Left scriptH = collision.gameObject.GetComponent<Human_Left>();

            if (!scriptH.isEcolo)
            {
                return;
            }
            else
            {
                if (!scriptH.slowed)
                {
                    scriptH.slowed = true;
                    scriptH.nbrSlowed++;
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity *= coefSlow.Value;
                    return;

                }

                if (scriptH.slowed)
                {
                    scriptH.nbrSlowed++;
                }
                return;
            }
            
        }
        if (collision.gameObject.tag == "HumanR")
        {
            Human_Right scriptH = collision.gameObject.GetComponent<Human_Right>();
            if (!scriptH.isEcolo)
            {
                return;
            }
            else
            {
                if (!scriptH.slowed)
                {
                    scriptH.slowed = true;
                    scriptH.nbrSlowed++;
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity *= coefSlow.Value;
                    return;
                }
                if (scriptH.slowed)
                {
                    scriptH.nbrSlowed++;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HumanL")
        {
            Human_Left scriptH = collision.gameObject.GetComponent<Human_Left>();
            if (scriptH.slowed)
            {
                Debug.Log(scriptH.nbrSlowed);
                if (scriptH.nbrSlowed == 1)
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity *= (1 / coefSlow.Value);
                    scriptH.slowed = false;
                    scriptH.nbrSlowed -= 1;
                    return;
                }

                if(scriptH.nbrSlowed > 1)
                {
                    scriptH.nbrSlowed -= 1;
                    return;
                }
            }
        }
        if (collision.gameObject.tag == "HumanR")
        {
            Human_Right scriptH = collision.gameObject.GetComponent<Human_Right>();
            if (scriptH.slowed)
            {
                if (scriptH.nbrSlowed == 1)
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity *= (1 / coefSlow.Value);
                    scriptH.slowed = false;
                    scriptH.nbrSlowed -= 1;
                    return;
                }

                if (scriptH.nbrSlowed > 1)
                {
                    scriptH.nbrSlowed -= 1;
                    return;
                }
            }
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
