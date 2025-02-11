using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
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
    }

    private void LaunchBall()
    {
        // if ball already launched, don't launch again
        if (isBallLaunched) return;

        // if ball not launched, set to true and launch it
        isBallLaunched = true;

        // 1st arg: force direction, 2nd arg: force application method
        // impulse = instant force change
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    void Update()
    {

    }
}
