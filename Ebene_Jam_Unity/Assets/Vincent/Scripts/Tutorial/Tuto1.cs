using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto1 : MonoBehaviour
{
    public Animator black;
    public Animator title;
    public Animator text;
    public Animator press;

    public GameObject tutorial2;
    public GameObject spawns;

    // Start is called before the first frame update
    void Start()
    {
        spawns.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            black.SetTrigger("Move");
            title.SetTrigger("Move");
            text.SetTrigger("Move");
            press.SetTrigger("Move");

            Destroy(black.gameObject, 2);
            Destroy(title.gameObject, 2);
            Destroy(text.gameObject, 2);
            Destroy(press.gameObject, 2);

            StartCoroutine("NextStep");
        }
    }

    IEnumerator NextStep()
    {
        yield return new WaitForSeconds(2);
        tutorial2.SetActive(true);
        Destroy(gameObject);
    }
}
