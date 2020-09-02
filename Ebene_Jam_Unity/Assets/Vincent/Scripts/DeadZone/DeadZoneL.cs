using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneL : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HumanR")
        {
            collision.gameObject.GetComponent<Human_Right>().Die();
        }
    }
}
