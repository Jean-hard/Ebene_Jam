using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeZoneL : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HumanR")
        {
            collision.gameObject.GetComponent<Human_Right>().Escape();
        }
    }
}
