using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour
{
    public GameObject topLip;
    public GameObject bottomLip;

    public float offset = 1f;
    public float speed = 0.1f;
    public float eatSpeed = 1f;
    public float maxTopLip = 5f;
    public float minBottomLip = 5f;
    public float timeBeforeShaking = 0.4f;


    private Vector3 topLipFirstPos;
    private Vector3 bottomLipFirstPos;

    private bool hasReachedMax = false;
    private bool hasReachedMin = false;
    private bool isEating = false;
    private bool canEat;


    // Start is called before the first frame update
    void Start()
    {
        if (topLip == null || bottomLip == null)
        {
            Debug.Log("No lips object in mouth");
            return;
        }

        topLipFirstPos = topLip.transform.position;
        bottomLipFirstPos = bottomLip.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //------------ TOP LIP MOVE ---------------

        if(Input.GetKeyDown(KeyCode.Space) && !isEating)
        {
            topLip.transform.position = topLip.transform.position + new Vector3(0f, offset, 0f);
        }

        if (topLip.transform.position.y < topLipFirstPos.y)
        {
            topLip.transform.position = topLipFirstPos;
            canEat = false;
        }

        if(topLip.transform.position.y > topLipFirstPos.y && !hasReachedMax)
        {
            //Debug.Log("Top Lip should go down");
            topLip.transform.position = topLip.transform.position - new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        if(topLip.transform.position.y > (topLipFirstPos.y + maxTopLip))
        {
            topLip.transform.position = new Vector3(0, topLipFirstPos.y + maxTopLip, 0);
            hasReachedMax = true;
            //Fronce le sourcil
        }


        //----------- BOTTOM LIP MOVE ---------------

        if (Input.GetKeyDown(KeyCode.V) && !isEating)
        {
            bottomLip.transform.position = bottomLip.transform.position - new Vector3(0f, offset, 0f);
        }

        if (bottomLip.transform.position.y > bottomLipFirstPos.y)
        {
            bottomLip.transform.position = bottomLipFirstPos;
            canEat = false;
        }

        if (bottomLip.transform.position.y < bottomLipFirstPos.y && !hasReachedMin)
        {
            //Debug.Log("Bottom Lip should go down");
            bottomLip.transform.position = bottomLip.transform.position + new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        if (bottomLip.transform.position.y < (bottomLipFirstPos.y - minBottomLip))
        {
            bottomLip.transform.position = new Vector3(0, bottomLipFirstPos.y - minBottomLip, 0);
            hasReachedMin = true;
            //Fronce le sourcil
        }


        // ----------- BOTH MOVE --------------

        if(hasReachedMax && hasReachedMin)
        {
            StartCoroutine(LaunchEatAction());
            isEating = true;
        }

        if(canEat)
        {
            topLip.transform.position = topLip.transform.position - new Vector3(0f, eatSpeed * Time.deltaTime, 0f);
            bottomLip.transform.position = bottomLip.transform.position + new Vector3(0f, eatSpeed * Time.deltaTime, 0f);
            hasReachedMax = false;
            hasReachedMin = false;
        }

    }

    IEnumerator LaunchEatAction()
    {
        canEat = true;
        yield return new WaitForSeconds(timeBeforeShaking);
        isEating = false;
        ShakeCamera();
    }

    private void ShakeCamera()
    {
        Debug.Log("CAMERA SHAKE");
    }
}
