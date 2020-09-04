using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tuto5 : MonoBehaviour
{
    public GameObject vert;
    public GameObject noir;
    public GameObject dont;
    public GameObject doo;

    private bool anykey;
    public GameObject anyKey;

    public GameObject blackScreen;
    // Start is called before the first frame update
    void Start()
    {
        vert.SetActive(true);
        noir.SetActive(true);
        dont.SetActive(true);
        doo.SetActive(true);
        StartCoroutine("NextStep");
    }

    // Update is called once per frame
    void Update()
    {
        if (anykey && Input.anyKey)
        {
            StartCoroutine("NextScene");
        }
    }

    IEnumerator NextStep()
    {
        yield return new WaitForSeconds(2);
        anykey = true;
        anyKey.SetActive(true);
    }

    IEnumerator NextScene()
    {
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
}
