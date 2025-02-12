using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // make sure it's actually the ball that's here, not some other game object
        {
            // 1. get ref to ball rigidbody and store in local var
            Rigidbody ballRigidBody = other.GetComponent<Rigidbody>();

            // 2. store velocity mangnitude
            float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

            // 3. reset both linear AND angular velocity
            // improtant because ball is rotating on ground when moving
            ballRigidBody.linearVelocity = Vector3.zero;
            ballRigidBody.angularVelocity = Vector3.zero;

            // 4. add force in the forward direction of the gutter
            // use cached velocity magnitude to keep it a little realistic
            ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
        }
    }
}
