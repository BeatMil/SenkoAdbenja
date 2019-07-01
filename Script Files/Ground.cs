using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    SenkoController senko;

    // Start is called before the first frame update
    void Start()
    {
        senko = FindObjectOfType<SenkoController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Jumpable")
        {
            senko.isGrounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (tag == "Jumpable")
        {
            senko.isGrounded = false;
        }
    }
}
