﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BourgeonKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(transform.parent.gameObject);
        }
        if (collision.gameObject.tag == "HumanR")
        {
            collision.gameObject.GetComponent<Human_Right>().Die();
            Destroy(transform.parent.gameObject);
        }

        if (collision.gameObject.tag == "HumanL")
        {
            collision.gameObject.GetComponent<Human_Left>().Die();
            Destroy(transform.parent.gameObject);
        }
    }
}