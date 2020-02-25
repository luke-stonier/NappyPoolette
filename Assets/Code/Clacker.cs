using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Clacker : MonoBehaviour
{
    public float clackerForce;
    private Rigidbody2D rb;
    private GameObject lastHit;
    private GameObject lastSegment;
    private GameManager gameManager;
    public WheelCreator builder;
    public AudioSource audio;
    public AudioClip audioClip;
    public float minimumStoppingForce;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = Camera.main.GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Clicker")
        {
            lastSegment = collider.gameObject;
            return;
        }
        if (collider.gameObject == lastHit)
            return;

        lastHit = collider.gameObject;
        var wheel = collider.gameObject.transform.parent.parent;
        var spinner = wheel.GetComponent<WheelSpinner>();
        if (!spinner.spinning) { return; }
        audio.PlayOneShot(audioClip);
        if (spinner.wheelSpeed < -minimumStoppingForce)
        {
            ApplyForce();
            spinner.hit();
        }
        else
        {
            lastHit = null;
            spinner.slowSpinner();
        }
    }

    void ApplyForce()
    {
        rb.AddTorque(clackerForce, ForceMode2D.Impulse);
    }

    public void DetectWinner()
    {
        var segment = lastSegment.GetComponent<WheelSegment>();
        gameManager.ShowSplat(segment.name);
    }
}
