using Rewired;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace ParsecOverlaySample
{
    public enum PlayerId
    {
        Player0,
        Player1
    }

    public class SliderController : MonoBehaviour
    {
        public string rewiredPlayerName = "Player0";
        private Player _rewiredPlayer = null;

        public float speed = 5f;

        public float minX;
        public float maxX;
        public float distanceY;
        
        public GameObject[] buds = new GameObject[4];

        public List<GameObject> futureBuds = new List<GameObject>();

        public GameObject bud1List;
        public GameObject bud2List;

        public Image actualBudUI;
        public Image futureBudUI;

        private int idBud;

        //--------------- JEAN ---------------
        [HideInInspector]
        public PlayerId playerId;

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


        void Start()
        {
            idBud = Random.Range(0, 4);
            futureBuds.Add(buds[idBud]);
            bud1List = futureBuds[0];
            actualBudUI.sprite = bud1List.GetComponent<SpriteRenderer>().sprite;

            idBud = Random.Range(0, 4);
            futureBuds.Add(buds[idBud]);
            bud2List = futureBuds[1];
            futureBudUI.sprite = bud2List.GetComponent<SpriteRenderer>().sprite;

            lipFirstPos = lip.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 dir = _rewiredPlayer.GetAxis2D("MoveLeftRight", "MoveUpDown");
            
            Vector3 newPosition = transform.position;
            newPosition.x += dir.x * speed * Time.deltaTime;

            if(newPosition.x <= minX)
            {
                newPosition.x = minX;
            }
            else if (newPosition.x >= maxX)
            {
                newPosition.x = maxX;
            }
            transform.position = newPosition;
            
            if (_rewiredPlayer.GetButtonDown("Instantiate"))
            {
                Instantiate(bud1List, new Vector2(newPosition.x, newPosition.y - distanceY), Quaternion.identity);

                futureBuds.Remove(futureBuds[0]);
                bud1List = futureBuds[0];
                actualBudUI.sprite = bud1List.GetComponent<SpriteRenderer>().sprite;


                idBud = Random.Range(0, 4);
                futureBuds.Add(buds[idBud]);
                bud2List = futureBuds[1];
                futureBudUI.sprite = bud2List.GetComponent<SpriteRenderer>().sprite;


                //Debug.Log("Instantiate");
            }

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
}


