using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;

[RequireComponent(typeof(Rigidbody2D))]
public class WheelSpinner : MonoBehaviour
{
    public float spinSpeed = 0.5f;
    private Rigidbody2D rb;

    public float wheelSpeed
    {
        get { return rb.angularVelocity; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var thisSpin = spinSpeed * Random.Range(1f, 1.5f);
            print(thisSpin);
            rb.AddTorque(thisSpin, ForceMode2D.Force);
        }
    }

    public void slowSpinner()
    {
        rb.angularVelocity = 1;
    }
}
