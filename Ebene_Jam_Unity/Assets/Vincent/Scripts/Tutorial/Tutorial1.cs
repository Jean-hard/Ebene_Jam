using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1 : MonoBehaviour
{
    public Animator black;
    public Animator title;
    public Animator text;
    public Animator anyKey;

    public GameObject spawns;
    public GameObject tuto2;

    // Start is called before the first frame update
    void Start()
    {
        spawns.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKey)
        {
            black.SetTrigger("Move");
            title.SetTrigger("Move");
            text.SetTrigger("Move");
            anyKey.SetTrigger("Move");
        }

    }

    IEnumerator NextStep()
    {
        yield return new WaitForSeconds(2);
        tuto2.SetActive(true);
        
    }
}
