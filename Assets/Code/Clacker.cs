using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Clacker : MonoBehaviour
{
    public float clackerForce;
    private Rigidbody2D rb;
    private GameObject lastHit;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            ApplyForce();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == lastHit)
            return;

        lastHit = collider.gameObject;
        var wheel = collider.gameObject.transform.parent.parent;
        // var spinner = wheel.GetComponent<WheelSpinner>();
        ApplyForce();
    }

    void ApplyForce()
    {
        // rb.angularVelocity = 0;
        rb.AddTorque(clackerForce, ForceMode2D.Impulse);
    }
}
