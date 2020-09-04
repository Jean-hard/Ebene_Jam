using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial4 : MonoBehaviour
{

    public GameObject eatTXT;
    public GameObject space;
    public GameObject space2;
    public GameObject imageSpace;
    public GameObject imageSpace2;

    public GameObject anyKey;
    private bool anykey;

    // Start is called before the first frame update
    void Start()
    {
        eatTXT.SetActive(true);
        space.SetActive(true);
        space2.SetActive(true);
        imageSpace.SetActive(true);
        imageSpace2.SetActive(true);
        StartCoroutine("NextStep");

    }

    // Update is called once per frame
    void Update()
    {
        
        if(anykey && Input.anyKey)
        {
            //NextScene
        }

    }

    IEnumerator NextStep()
    {
        yield return new WaitForSeconds(2);
        anykey = true;
        anyKey.SetActive(true);
    }
}
