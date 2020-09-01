using Rewired;
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

        private void Awake()
        {
            _rewiredPlayer = ReInput.players.GetPlayer(rewiredPlayerName);
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
            Debug.Log(newPosition.x);
        }
    }
}


