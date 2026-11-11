using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CropScript : MonoBehaviour
{
    [SerializeField] GameStats dayStat;

    [SerializeField] float maxCropSize = 1f;
    public int harvestAmount = 25;

    public bool isHarvestable = false;

    [SerializeField] int daysToGrow = 5;
    int currentDay = 0;
    int daysGrowing = 0;


    private void Start()
    {
        //gameObject.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        daysGrowing = 0;
        transform.localScale = new Vector3(1, maxCropSize/daysToGrow*daysGrowing, 1);
        currentDay = dayStat.dayCounter;
        isHarvestable = false;
    }
    private void OnDisable()
    {
        transform.localScale = new Vector3(1, 0, 1);
        isHarvestable = false;
    }

    // Update is called once per frame
    void Update()
    {
        daysGrowing = dayStat.dayCounter - currentDay;

        if (transform.localScale.y >= maxCropSize)
        {
            isHarvestable = true;
        }
        else
        {
            transform.localScale = new Vector3(1, maxCropSize / daysToGrow * daysGrowing, 1);
        }
    }

}
