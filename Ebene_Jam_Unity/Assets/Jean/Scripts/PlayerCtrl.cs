using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public enum PlayerId
{
    Player0,
    Player1
}

public class PlayerCtrl : MonoBehaviour
{
    [HideInInspector]
    public PlayerId playerId;

    public string rewiredPlayerName = "Player0";
    private Player _rewiredPlayer = null;

    public GameObject eyeBrow;
    public GameObject lip;

    public int maxSpamNb = 20;

    public float lipLimit = 2f;

    [HideInInspector]
    public bool canSpam = false;
    [HideInInspector]
    public bool hasReachedLimit = false;

    [HideInInspector]
    public Vector3 lipFirstPos;

    private void Awake()
    {
        _rewiredPlayer = ReInput.players.GetPlayer(rewiredPlayerName);

        if (rewiredPlayerName == "Player0") playerId = PlayerId.Player0;
        else playerId = PlayerId.Player1;
    }

    // Start is called before the first frame update
    void Start()
    {
        lipFirstPos = lip.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerId)
        {
            case PlayerId.Player0:
                if (canSpam && _rewiredPlayer.GetButtonDown("OpenLip"))
                {
                    lip.transform.position += new Vector3(0f, lipLimit / maxSpamNb, 0f);
                }

                //Si on dépasse la valeur limite
                if (lip.transform.position.y > (lipFirstPos.y + lipLimit))
                {
                    lip.transform.position = new Vector3(lipFirstPos.x, lipFirstPos.y + lipLimit, lipFirstPos.z);
                    hasReachedLimit = true;
                }
                break;

            case PlayerId.Player1:
                if (canSpam && _rewiredPlayer.GetButtonDown("OpenLip"))
                {
                    lip.transform.position -= new Vector3(0f, lipLimit / maxSpamNb, 0f);
                }

                //Si on dépasse la valeur limite
                if (lip.transform.position.y < (lipFirstPos.y - lipLimit))
                {
                    lip.transform.position = new Vector3(lipFirstPos.x, lipFirstPos.y - lipLimit, lipFirstPos.z);
                    hasReachedLimit = true;
                }
                break;
        }
    }
}

