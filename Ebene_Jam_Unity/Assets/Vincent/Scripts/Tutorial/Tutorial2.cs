﻿using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tutorial2 : MonoBehaviour
{

    public GameObject bourgeon2;
    public GameObject Text2;
    private bool bool2;

    public GameObject bourgeon4;
    public GameObject Text4;
    private bool bool4;

    public GameObject anyKey;
    private bool isAnyKey;

    public GameObject tuto3;

    // Start is called before the first frame update
    void Start()
    {

        bourgeon2.SetActive(true);
        Text2.SetActive(true);
        bool2 = true;
        StartCoroutine("Wait");
        return;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bool2 && Input.anyKey && isAnyKey)
        {
            print("yo");
            bool2 = false;
            bourgeon4.SetActive(true);
            Text4.SetActive(true);
            bool4 = true;
            StartCoroutine("Wait");
            return;
        }

        if(bool4 && Input.anyKey && isAnyKey)
        {
            bool4 = false;
            Text2.SetActive(false);
            Text4.SetActive(false);
            bourgeon2.SetActive(false);
            bourgeon4.SetActive(false);
            tuto3.SetActive(true);
            gameObject.SetActive(false);

        }


    }

    IEnumerator Wait()
    {
        isAnyKey = false;
        anyKey.SetActive(false);
        yield return new WaitForSeconds(1);
        anyKey.SetActive(true);
        isAnyKey = true;

    }
}
