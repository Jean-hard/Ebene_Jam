using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Spawn_Left : MonoBehaviour
{
    bool canSpawn = true;
    public GameObject human;
    float randomNumber;

    private void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;
            Instantiate(human, transform.position, transform.rotation);
            float randomRange = UnityEngine.Random.Range(1f, 2.5f);
            randomNumber = randomRange;
            StartCoroutine("Wait");
        }

        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(randomNumber);
        canSpawn = true;
    }
}
