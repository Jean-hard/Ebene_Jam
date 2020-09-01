using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Spawn_Right : MonoBehaviour
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
            float randomRange = UnityEngine.Random.Range(0.4f, 1.2f);
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
