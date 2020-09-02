using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParsecOverlaySample
{
    public class TreeManager : MonoBehaviour
    {
        public SliderController player0;
        public SliderController player1;

        public GameObject rightEyeBrow;
        public GameObject leftEyeBrow;

        public int nbMaxSpam = 20;

        public float topEatSpeed = 1.2f;
        public float bottomEatSpeed = 1f;
        public float timeBeforeShaking = 0.4f;
        public float spamCoolDown = 5f;

        private float counter = 0f;

        private bool countIsDown = false;
        private bool isEating;

        //Singleton
        private static TreeManager _instance;
        private void Awake()
        {
            _instance = this;
        }


        private void Start()
        {
            counter = spamCoolDown;
        }

        // Update is called once per frame
        void Update()
        {
            //---------- COUNTDOWN -------------
            if (counter > 0)
            {
                counter -= Time.deltaTime;
                countIsDown = false;
            }

            if (counter < 0)
            {
                ActiveSpamMoment();
                countIsDown = true;
                counter = 0;
            }

            if (!countIsDown)
            {
                player0.canSpam = false;
                player1.canSpam = false;
            }


            // ----------- CHECK LIP POSITION --------------

            if (player0.hasReachedLimit && player1.hasReachedLimit)
            {
                StartCoroutine(LaunchEatAction());
            }

            if (isEating)
            {
                player0.lip.transform.position -= new Vector3(0f, topEatSpeed * Time.deltaTime, 0f);
                player1.lip.transform.position += new Vector3(0f, bottomEatSpeed * Time.deltaTime, 0f);
                player0.hasReachedLimit = false;
                player1.hasReachedLimit = false;
            }


            //------------ TOP LIP (player 0) ---------------

            //Si passe en dessous de la position de départ
            if (player0.lip.transform.position.y < player0.lipFirstPos.y)
            {
                player0.lip.transform.position = player0.lipFirstPos;
            }


            //----------- BOTTOM LIP (player 1) ---------------

            //Si passe au dessus de la position de départ
            if (player1.lip.transform.position.y > player1.lipFirstPos.y)
            {
                player1.lip.transform.position = player1.lipFirstPos;
            }

        }

        IEnumerator LaunchEatAction()
        {
            isEating = true;
            yield return new WaitForSeconds(timeBeforeShaking);
            isEating = false;

            ShakeCamera();
            StartCoroutine(ResetEyeBrow());
            counter = spamCoolDown;
        }

        private void ActiveSpamMoment()
        {
            player0.canSpam = true;
            player1.canSpam = true;
            Debug.Log("CAN SPAM");
            rightEyeBrow.GetComponent<EyeBrowController>().canGoAngry = true;
            leftEyeBrow.GetComponent<EyeBrowController>().canGoAngry = true;
        }

        IEnumerator ResetEyeBrow()
        {
            yield return new WaitForSeconds(1f);

            rightEyeBrow.GetComponent<EyeBrowController>().canGoAngry = false;
            leftEyeBrow.GetComponent<EyeBrowController>().canGoAngry = false;

            rightEyeBrow.GetComponent<EyeBrowController>().canGoNice = true;
            leftEyeBrow.GetComponent<EyeBrowController>().canGoNice = true;
        }

        private void ShakeCamera()
        {
            Camera.main.GetComponent<CameraShake>().shakeDuration = 0.5f;
        }
    }
}
