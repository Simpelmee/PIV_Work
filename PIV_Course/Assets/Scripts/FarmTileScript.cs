using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class FarmTileScript : MonoBehaviour
{
    public GameStats inventoryStats;
    private bool canWater = false;
    private bool isWatered = false;

    [SerializeField] GameObject unwateredTile;
    [SerializeField] GameObject wateredTile;
    [SerializeField] GameObject cropFolder;
    [SerializeField] CropScript cropScript;

    private InputAction interact;

    enum selectCropType {Wheat, Carrot, Radish}
    [SerializeField] selectCropType cropType; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
        ChangeDefualtState();
    }

    // Update is called once per frame
    void Update()
    {
        if (canWater && interact.WasPressedThisFrame() && !cropScript.isHarvestable && !isWatered)
        {
            ChangeDefualtState(true);
        }
        if (cropScript.isHarvestable && canWater && interact.WasPressedThisFrame() && isWatered)
        {
            ChangeDefualtState();
            AddSelectedCrop(cropScript.harvestAmount);
            EditorUtility.SetDirty(inventoryStats);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canWater = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canWater= false;
        }
    }

    private void ChangeDefualtState(bool change = false)
    {
        unwateredTile.SetActive(!change);
        wateredTile.SetActive(change);
        cropFolder.SetActive(change);
        isWatered = change;
    }

    private void AddSelectedCrop(int cropAmount)
    {
        switch (cropType)
        {
            case selectCropType.Wheat:
                inventoryStats.wheatAmount += cropAmount;
                break;
            case selectCropType.Carrot:
                inventoryStats.carrotAmount += cropAmount;
                break;
            case selectCropType.Radish:
                inventoryStats.radishAmount += cropAmount;
                break;
        }
    }
}
