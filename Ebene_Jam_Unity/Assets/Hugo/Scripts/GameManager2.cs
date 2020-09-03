using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{

    public GameObject _panelPause;

    private bool _isPause;


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

            //imgPause.SetActive(false);
            //imgPlay.SetActive(true);

            //MusicAudioSource.Pause();

            Debug.Log("On Pause");
        }
        else
        {
            Time.timeScale = 1;

            //imgPause.SetActive(true);
            //imgPlay.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;

            Debug.Log("On Play");
        }

        _panelPause.SetActive(_isPause);
    }

    //public void StartGame()
    //{
    //    PlayerMovements.hasGameStarted = true;
    //}

}
