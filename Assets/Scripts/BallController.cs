using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private InputManager inputManager;
    private Rigidbody ballRB;
    private bool isBallLaunched;

    void Start()
    {
        // Grab ref to ball's Rigidbody component
        ballRB = GetComponent<Rigidbody>();

        // Add listener to OnSpacePressed event
        // When space key pressed, the LaunchBall method will be called
        inputManager.OnSpacePressed.AddListener(LaunchBall);

        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;

        ballRB.isKinematic = true;
    }

    private void LaunchBall()
    {
        // if ball already launched, don't launch again
        if (isBallLaunched) return;

        // if ball not launched, set to true and launch it
        isBallLaunched = true;

        // set this obj to the outmost layer of the hierarchy
        transform.parent = null;

        ballRB.isKinematic = false;

        // 1st arg: force direction, 2nd arg: force application method
        // impulse = instant force change
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    void Update()
    {

    }
}
