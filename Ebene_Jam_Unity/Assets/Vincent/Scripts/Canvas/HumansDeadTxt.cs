using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumansDeadTxt : MonoBehaviour
{
    public IntReference NbrHumansDead;
    private Text text;

    void Start()
    {
        NbrHumansDead.Variable.SetValue(0);
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = NbrHumansDead.Variable.Value.ToString();
    }
}
