using UnityEngine;

public class HingeControl : MonoBehaviour
{
    [SerializeField] float rotationThreshold = 0.01f;
    [SerializeField] float targetVelocity = 10f;
    new HingeJoint hingeJoint;
    JointMotor jointMotor;
    new Transform transform;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        transform = GetComponent<Transform>();
        jointMotor = hingeJoint.motor;
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(transform.rotation.y) < rotationThreshold)
        {
            jointMotor.targetVelocity = 0;

            hingeJoint.motor = jointMotor;

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.rotation.y > rotationThreshold)
        {
            jointMotor.targetVelocity = -targetVelocity;

            hingeJoint.motor = jointMotor;
        }
        else if (transform.rotation.y < -rotationThreshold)
        {
            jointMotor.targetVelocity = targetVelocity;

            hingeJoint.motor = jointMotor;
        }
    }
}
