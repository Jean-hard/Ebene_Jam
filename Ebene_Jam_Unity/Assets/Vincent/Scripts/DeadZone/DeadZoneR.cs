﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneR : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HumanL")
        {
            collision.gameObject.GetComponent<Human_Left>().Die();
        }
    }
}
