﻿using Rewired;
using UnityEngine;

namespace ParsecOverlaySample
{
    public class SliderController : MonoBehaviour
    {
        public string rewiredPlayerName = "Player0";
        private Player _rewiredPlayer = null;

        public float speed = 5f;

        public float minX;
        public float maxX;
        public float distanceY = 150;

        public GameObject ownPlayer;
        public GameObject bud;

        private void Awake()
        {
            _rewiredPlayer = ReInput.players.GetPlayer(rewiredPlayerName);
            //ReInput.players.get
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

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Instantiate(bud, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - distanceY), Quaternion.identity);
                //Debug.Log("Instantiate");
            }
        }
    }
}


