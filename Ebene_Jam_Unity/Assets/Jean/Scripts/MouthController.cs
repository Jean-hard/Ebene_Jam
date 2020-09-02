using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour
{
    public GameObject rightEyeBrow;
    public GameObject leftEyeBrow;

    public int nbMaxSpam = 20;
    private float countDown = 5f;
    private float speed = 0.1f;
    private bool countIsDown = false;

    public float topLipOffset = 0.2f;
    public float bottomLipOffset = 0.1f;
    public float topLipSpeed = 0.1f;
    public float bottomLipSpeed = 0.07f;
    public float topEatSpeed = 1.2f;
    public float bottomEatSpeed = 1f;
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

    }

    // Update is called once per frame
    void Update()
    {
        //---------- COUNTDOWN -------------
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
            countIsDown = false;
            Debug.Log(countDown);
        }

        if (countDown < 0)
        {
            SetAngryEyeBrow();
            countIsDown = true;
            countDown = 0;
        }
        //------------------------------------  



        // ----------- BOTH MOVE --------------

        if(hasReachedMax && hasReachedMin)
        {
            StartCoroutine(LaunchEatAction());
            isEating = true;
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
        //Debug.Log("CAMERA SHAKE");
        Camera.main.GetComponent<CameraShake>().shakeDuration = 0.5f;
    }

    private void SetAngryEyeBrow()
    {
        if(rightEyeBrow.transform.rotation.z == -45f)   //Protection pour lancer une seule fois
        {
            rightEyeBrow.GetComponent<EyeBrowController>().canGoAngry = true;
            leftEyeBrow.GetComponent<EyeBrowController>().canGoAngry = true;
        }
    }

    IEnumerator ResetEyeBrow()
    {
        yield return new WaitForSeconds(1f);
        rightEyeBrow.GetComponent<EyeBrowController>().canGoAngry = false;
        leftEyeBrow.GetComponent<EyeBrowController>().canGoAngry = false;
        rightEyeBrow.GetComponent<EyeBrowController>().canGoNice = true;
        leftEyeBrow.GetComponent<EyeBrowController>().canGoNice = true;
    }
}
