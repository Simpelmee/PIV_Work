using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class SiloInventory : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    public TMP_Text inventory; 

    public GameStats inventoryStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        inventory.text = $"Current Inventory:\nWheat: {inventoryStats.wheatAmount}\nCarrot: {inventoryStats.carrotAmount}\nRadish: {inventoryStats.radishAmount}";
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
            inventoryStats.dayCounter++;
            EditorUtility.SetDirty(inventoryStats);
        }
    }
}
