using UnityEngine;
using UnityEngine.InputSystem;

public class WateringCan : MonoBehaviour
{
    new Animator animation;
    private InputAction interact;
    private float testCounter = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interact.WasPressedThisFrame())
        {
            animation.SetBool("IsWatering", true);
            testCounter = 0.25f;
        }
        testCounter -= Time.deltaTime;
        if (testCounter < 0f)
        {
            animation.SetBool("IsWatering", false); 
        }
    }
}
