using System.Collections;
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
