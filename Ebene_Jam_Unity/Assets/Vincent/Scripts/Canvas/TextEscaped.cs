using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEscaped : MonoBehaviour
{
    public IntReference NbrHumansEscaped;
    private Text text;

    void Start()
    {
        NbrHumansEscaped.Variable.SetValue(0);
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = NbrHumansEscaped.Variable.Value.ToString();
    }
}
