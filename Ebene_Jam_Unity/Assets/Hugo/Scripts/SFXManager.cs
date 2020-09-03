using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public AudioClip[] effects = new AudioClip[5];

    public AudioSource As;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager.hasEaten)
        {
            As.PlayOneShot(effects[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
