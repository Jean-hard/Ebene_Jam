using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Spawn_Left : MonoBehaviour
{
    bool canSpawn = true;
    public GameObject human;
    public FloatReference minRateHuman;
    public FloatReference maxRateHuman;
    float randomNumber;

    bool goodSpawn = false;
    public GameObject ecolo;
    public FloatReference minRateEcolo;
    public FloatReference maxRateEcolo;

    float randomNumberEcolo;

    void Start()
    {
        StartCoroutine("StartEcolo");
    }


    private void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;
            Instantiate(human, transform.position, transform.rotation);
            float randomRange = UnityEngine.Random.Range(minRateHuman.Value, maxRateHuman.Value);
            randomNumber = randomRange;
            StartCoroutine("Wait");
        }

        if (goodSpawn)
        {
            goodSpawn = false;
            Instantiate(ecolo, transform.position, transform.rotation);
            float randomRange = UnityEngine.Random.Range(minRateEcolo.Value, maxRateEcolo.Value);
            randomNumberEcolo = randomRange;
            StartCoroutine("WaitForEcolo");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(randomNumber);
        canSpawn = true;
    }

    IEnumerator WaitForEcolo()
    {
        yield return new WaitForSeconds(randomNumberEcolo);
        goodSpawn = true;
    }

    IEnumerator StartEcolo()
    {
        float randomRange = UnityEngine.Random.Range(3, 6);
        yield return new WaitForSeconds(randomRange);
        goodSpawn = true;
    }
}
