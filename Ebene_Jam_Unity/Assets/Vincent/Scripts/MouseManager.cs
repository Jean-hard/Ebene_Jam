using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GameObject Slow;
    public GameObject Attract;
    public GameObject Buche;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(Slow, point, transform.rotation);
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(Buche, point, transform.rotation);

        }
    }
}
