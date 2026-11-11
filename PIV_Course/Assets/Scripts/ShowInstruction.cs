using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowInstruction : MonoBehaviour
{
    [SerializeField] GameStats gameStats;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject player;
    private InputAction interact;
    private int dayCounter = 0;
    private int dayCounterHolder = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.SetActive(false);
        interact = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        UI.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y, 0);
        if (UI.activeSelf && gameStats.wheatAmount >= 5)
        {
            dayCounter = gameStats.dayCounter;
            if (interact.WasPressedThisFrame() && dayCounter > dayCounterHolder)
            {
                gameStats.wheatAmount -= 5;
                dayCounterHolder = dayCounter;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UI.SetActive(false);
        }
    }
}
