using Unity.VisualScripting;
using UnityEngine;

public class ShowInstruction : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UI.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y, 0);
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
