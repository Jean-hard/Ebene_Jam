using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EyeBrow
{
    RIGHT, 
    LEFT
}

public class EyeBrowController : MonoBehaviour
{
    public EyeBrow eyeBrowPosition;
    
    public bool canGoAngry = false;
    public bool canGoNice = false;

    float smooth = 5.0f;

    // Update is called once per frame
    void Update()
    {
        if (canGoAngry)
        {
            canGoNice = false;
            if(eyeBrowPosition == EyeBrow.RIGHT)
            {
                Quaternion target = Quaternion.Euler(0, 0, 60f);

                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            }
            else
            {
                Quaternion target = Quaternion.Euler(0, 0, -60f);

                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            }
        }

        if(canGoNice)
        {
            if (eyeBrowPosition == EyeBrow.RIGHT)
            {
                Quaternion target = Quaternion.Euler(0, 0, 0);

                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            }
            else
            {
                Quaternion target = Quaternion.Euler(0, 0, 0);

                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            }
        }
    }
}
