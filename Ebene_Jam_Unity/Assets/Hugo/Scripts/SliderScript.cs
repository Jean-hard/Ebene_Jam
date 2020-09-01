using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    public Slider slider;

    public int player;

    // Start is called before the first frame update
    void Start()
    {
        slider = this.gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == 1)
        {
            if (Input.GetKey(KeyCode.Q))
            {

                slider.value = slider.value - 1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {

                slider.value = slider.value + 1f;
            }
        }
        else if(player == 2)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                slider.value = slider.value - 1f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {

                slider.value = slider.value + 1f;
            }
        }
        
    }
}
