using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{

    public GameObject _panelPause;
    public GameObject mainPause;
    public GameObject settings;
    public GameObject controls;

    private bool _isPause;

    public AudioSource mainMusic;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        _panelPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DoPause();
        }
    }

    public void MyLoadScene(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
    }

    public void DoPause()
    {
        Pause(!_isPause);
    }

    private void Pause(bool pause)
    {
        _isPause = pause;

        if (pause)
        {
            Time.timeScale = 0;

            mainPause.SetActive(true);
            settings.SetActive(false);
            controls.SetActive(false);

            mainMusic.Pause();

            Debug.Log("On Pause");
        }
        else
        {
            Time.timeScale = 1;

            mainMusic.UnPause();

            Debug.Log("On Play");
        }

        _panelPause.SetActive(_isPause);
    }

    public void GameSettings()
    {
        settings.SetActive(true);
        mainPause.SetActive(false);
    }

    public void GameControls()
    {
        controls.SetActive(true);
        mainPause.SetActive(false);
    }

    public void MainPause()
    {
        mainPause.SetActive(true);
        settings.SetActive(false);
        controls.SetActive(false);
    }

}
