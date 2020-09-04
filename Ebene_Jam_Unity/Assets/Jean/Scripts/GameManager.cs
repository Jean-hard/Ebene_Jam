using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EndType
{
    GOOD,
    MIDDLE,
    BAD
}
public class GameManager : MonoBehaviour
{
    public List<GameObject> humansInMouth = new List<GameObject>();
    private List<GameObject> humansToDestroy = new List<GameObject>();

    private int eatenHumansCounter = 0;
    private int eatenEcoloCounter = 0;
    private int globalEcoloCnt = 0;

    public bool hasEaten;

    public int score = 0;
    public int maxScore = 100;
    public int highValueOfEcolo = 30;

    public float timeRemaining = 70f;
    private bool timerIsRunning = false;
    public Text timeText;
    public Image scoreBar;

    public GameObject finishedText;
    public GameObject goodEnd;
    public GameObject middleEnd;
    public GameObject badEnd;
    private EndType end;
    public float timeBeforeReplay = 13f;
    public bool gameFinished = false;

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        hasEaten = false;
        scoreBar.fillAmount += score/maxScore;
        Physics2D.IgnoreLayerCollision(8, 8);

    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timerIsRunning = false;
                timeRemaining = 0;
                LooseGame();
            }
        }
        
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddScore(float instantScore)
    {
        score += (int)(instantScore);
        scoreBar.fillAmount += instantScore / maxScore;

        if(score >= maxScore)
        {
            WinGame();
        }
    }

    public void EatHumans()
    {
        hasEaten = true;
        eatenEcoloCounter = 0;
        eatenHumansCounter = 0;

        float instantScore = 0;

        foreach(GameObject human in humansInMouth)
        {
            bool isEcolo = false;

            if (human.CompareTag("HumanL"))
                isEcolo = human.GetComponent<Human_Left>().isEcolo;
            
            else if (human.CompareTag("HumanR"))
                isEcolo = human.GetComponent<Human_Right>().isEcolo;
            
            else Debug.Log("A human has no tag");

            if (isEcolo) eatenEcoloCounter++;
            else eatenHumansCounter++;

            humansToDestroy.Add(human);
        }

        foreach(GameObject human in humansToDestroy)
        {
            Destroy(human);
        }

        instantScore += eatenHumansCounter;
        instantScore -= eatenEcoloCounter;

        globalEcoloCnt += eatenEcoloCounter;

        if (score < 0) score = 0;

        AddScore(instantScore);

        humansInMouth.Clear();
        humansToDestroy.Clear();
        hasEaten = false;
    }

    public void WinGame()
    {
        timerIsRunning = false;
        gameFinished = true;

        if (globalEcoloCnt >= highValueOfEcolo)
        {
            //Fin moyenne
            Debug.Log("Fin moyenne");
            end = EndType.MIDDLE;
        }
        else
        {
            //Fin bonne
            Debug.Log("Fin bonne");
            end = EndType.GOOD;
        }

        StartCoroutine(DisplayEndScreen());
    }

    public void LooseGame()
    {
        gameFinished = true;

        //Fin mauvaise
        Debug.Log("Fin mauvaise");
        end = EndType.BAD;

        StartCoroutine(DisplayEndScreen());
    }

    IEnumerator DisplayEndScreen()
    {
        finishedText.SetActive(true);

        yield return new WaitForSeconds(3f);
        
        finishedText.SetActive(false);

        switch(end)
        {
            case EndType.GOOD:
                goodEnd.SetActive(true);
                break;
            case EndType.MIDDLE:
                middleEnd.SetActive(true);
                break;
            case EndType.BAD:
                badEnd.SetActive(true);
                break;
        }

        yield return new WaitForSeconds(timeBeforeReplay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
