using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BourgeonSpawner : MonoBehaviour
{
    public GameObject bourgeon;
    public bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;
            StartCoroutine("Spawn");
        }
    }

    IEnumerator Spawn()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(2);
        GetComponent<SpriteRenderer>().color = Color.black;
        Instantiate(bourgeon, transform.position, transform.rotation);
        yield return new WaitForSeconds(5);
        canSpawn = true;
    }
}
