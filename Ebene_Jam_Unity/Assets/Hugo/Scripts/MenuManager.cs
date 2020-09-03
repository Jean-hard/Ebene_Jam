using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ParsecOverlay;
using Rewired;


public class MenuManager : MonoBehaviour
{
    public UIParsecOverlay parsec;

    //public string player2 = "Player1";
    //private Player _rewiredPlayer2 = null;

    public string gameScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        //_rewiredPlayer2 = ReInput.players.GetPlayer(player2);
    }

    // Update is called once per frame
    void Update()
    {
        //if (_rewiredPlayer2.isPlaying)
        //{
        //    UnityEngine.SceneManagement.SceneManager.LoadScene(gameScene);
        //}

        //if (parsec.connected)
        //{
        //    UnityEngine.SceneManagement.SceneManager.LoadScene(gameScene);
        //}
    }

    public void MyLoadScene(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
    }

    public void _Quit()
    {
        Application.Quit();
    }

    //IEnumerator
}
