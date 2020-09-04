using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDad : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 shot = new Vector2(0, -20);
        rb.AddForce(shot, ForceMode2D.Impulse);
    }


}
