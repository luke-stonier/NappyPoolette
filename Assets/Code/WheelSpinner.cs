using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WheelSpinner : MonoBehaviour
{
    public Clacker clacker;
    public float spinSpeed = 0.5f;
    public bool spinning;
    private bool hasSpun;
    private Rigidbody2D rb;
    private GameManager gameManager;
    public AnimationCurve SlowDownCurve;
    public float slowDownConst;

    public float wheelSpeed
    {
        get { return rb.angularVelocity; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = Camera.main.GetComponent<GameManager>();
    }

    void Update()
    {
        if (spinning && rb.angularVelocity > -35 && rb.angularVelocity < 0)
        {
            rb.angularVelocity += 0.1f;
        }

        if (rb.angularVelocity > 0)
        {
            endSpinCheck();
        }
    }

    private void endSpinCheck()
    {
        if (!spinning || !hasSpun) { return; }
        clacker.DetectWinner();
        spinning = false;
        hasSpun = true;
        rb.angularVelocity = 0;
    }

    public void Spin()
    {
        gameManager.hideSpinButton();
        gameManager.hideMenu();
        hasSpun = true;
        spinning = true;
        var thisSpin = spinSpeed * Random.Range(1f, 2f);
        rb.angularDrag = 0.2f * Random.Range(0.5f, 2f);
        rb.AddTorque(thisSpin, ForceMode2D.Force);
    }

    public void slowSpinner()
    {
        rb.angularVelocity = 1;
    }

    public void hit()
    {
        var coef = (1 / rb.angularVelocity) * 100;
        print(coef);
        var toReduce = SlowDownCurve.Evaluate(Mathf.Abs(coef)) * slowDownConst;
        print($"{rb.angularVelocity} reduced by {toReduce}");
        rb.AddTorque(-toReduce * Time.deltaTime, ForceMode2D.Force);
    }
}
