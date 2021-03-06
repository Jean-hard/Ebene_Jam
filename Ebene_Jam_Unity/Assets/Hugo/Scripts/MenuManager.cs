﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ParsecOverlay;
using Rewired;


public class MenuManager : MonoBehaviour
{
    public UIParsecOverlay parsec;
    
    public int sceneId;

    public GameObject menu;
    public GameObject settings;
    public GameObject controls;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        controls.SetActive(false);
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (parsec.connected)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);
        }
    }

    public void MyLoadScene(int sceneId)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);
    }

    public void Settings()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void Menu()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        controls.SetActive(false);
    }

    public void Controls()
    {
        controls.SetActive(true);
        menu.SetActive(false);
    }


    public void _Quit()
    {
        Application.Quit();
    }

    //IEnumerator
}
