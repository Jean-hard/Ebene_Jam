using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowParticles : MonoBehaviour
{
    public float duration;

    void Start()
    {
        StartCoroutine("Die");
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(2.5f);
        GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
