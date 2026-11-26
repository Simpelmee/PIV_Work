using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Windmill : MonoBehaviour
{
    MeshCollider mill;
    Rigidbody rb;

    [SerializeField] float rotationSpeed = 1.0f;

    [SerializeField] float collisionCheckDistance;
    bool aboutToCollide = false;
    //public float distanceToCollision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mill = GetComponent<MeshCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!aboutToCollide)
        {
            this.transform.Rotate(0, 0, rotationSpeed, Space.Self);
        }

        RaycastHit hit;
        Debug.DrawRay(transform.position ,transform.forward, Color.red);
        if (!rb.SweepTest(transform.forward, out hit, collisionCheckDistance))
        {
            aboutToCollide = false;
            //distanceToCollision = hit.distance;
        }
        else
        {
            aboutToCollide = true;
        }
    }
}
