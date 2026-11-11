using Unity.VisualScripting;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] GameStats dayCounter;

    [SerializeField] float dayTimer = 0f;
    [SerializeField] float dayLength = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dayTimer += Time.fixedDeltaTime;

        if (dayTimer >= dayLength)
        {
            dayTimer = 0f;
            dayCounter.dayCounter++;
        }
    }
}
