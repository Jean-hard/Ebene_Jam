using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> humansInMouth = new List<GameObject>();
    public List<GameObject> humansToDestroy = new List<GameObject>();

    private int eatenHumansCounter = 0;
    private int eatenEcoloCounter = 0;
    public int score = 0;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EatHumans()
    {
        eatenEcoloCounter = 0;
        eatenHumansCounter = 0;

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

        score += eatenHumansCounter;
        score -= eatenEcoloCounter;

        humansInMouth.Clear();
        humansToDestroy.Clear();

        if (score < 0) score = 0;
    }
}
