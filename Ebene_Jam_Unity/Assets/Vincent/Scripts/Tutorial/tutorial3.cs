using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial3 : MonoBehaviour
{
    public GameObject D;
    public GameObject Q;
    public GameObject drop;
    public GameObject s;
    public GameObject lutin;

    bool anykey;
    public GameObject anyKey;

    public GameObject tuto4;

    // Start is called before the first frame update
    void Start()
    {
        D.SetActive(true);
        Q.SetActive(true);
        drop.SetActive(true);
        s.SetActive(true);
        lutin.SetActive(true);
        StartCoroutine("NextStep");
    }

    private void Update()
    {
        if(anykey && Input.anyKey)
        {
            anykey = false;
            anyKey.SetActive(false);
            tuto4.SetActive(true);
            D.SetActive(false);
            Q.SetActive(false);
            drop.SetActive(false);
            s.SetActive(false);
            lutin.SetActive(false);
        }
    }

    IEnumerator NextStep()
    {
        yield return new WaitForSeconds(2);
        anykey = true;
        anyKey.SetActive(true);
    }
}
