using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour
{
    public GameObject topLip;
    public GameObject bottomLip;

    public float offset = 1f;
    public float speed = 0.1f;

    private Vector3 topLipFirstPos;
    private Vector3 bottomLipFirstPos;

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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            topLip.transform.position = topLip.transform.position + new Vector3(0f, offset, 0f);
        }

        if (topLip.transform.position.y < topLipFirstPos.y)
        {
            topLip.transform.position = topLipFirstPos;
        }

        if(topLip.transform.position.y > topLipFirstPos.y)
        {
            Debug.Log("Top Lip should go down");
            topLip.transform.position = topLip.transform.position - new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        //if(topLip.transform.position.y > topLip.transform)


        //----------- BOTTOM LIP MOVE ---------------

        if (Input.GetKeyDown(KeyCode.V))
        {
            bottomLip.transform.position = bottomLip.transform.position - new Vector3(0f, offset, 0f);
        }

        if (bottomLip.transform.position.y > bottomLipFirstPos.y)
        {
            bottomLip.transform.position = bottomLipFirstPos;
        }

        if (bottomLip.transform.position.y < bottomLipFirstPos.y)
        {
            Debug.Log("Bottom Lip should go down");
            bottomLip.transform.position = bottomLip.transform.position + new Vector3(0f, speed * Time.deltaTime, 0f);
        }
    }
}
