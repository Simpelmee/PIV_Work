using Unity.VisualScripting;
using UnityEngine;

public class GoToSleep : MonoBehaviour
{
    [SerializeField] GameObject UI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            UI.SetActive(true);
            other.transform.position -= new Vector3(0, 0, -5);
        }
    }

    public void DeactivateUI()
    {
        UI.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
