using Unity.VisualScripting;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] GameStats dayCounter;

    [SerializeField] float dayTimer = 0f;
    [SerializeField] float dayLength = 100f;
    [SerializeField] float sunStartXRotation = 45f;
    float sunXRotation = 45f;
    new Transform transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform = GetComponent<Transform>();
        DayStart();
    }

    // Update is called once per frame
    void Update()
    {
        dayTimer += Time.fixedDeltaTime * Time.timeScale;

        sunXRotation = (360 * dayTimer)/dayLength + sunStartXRotation;

        transform.eulerAngles = new Vector3(sunXRotation, 0, 0);

        if (dayTimer >= dayLength)
        {
            dayTimer = 0f;
            dayCounter.dayCounter++;
        }
    }

    public void DayStart()
    {
        dayTimer = 0f;
        dayCounter.dayCounter++;
        transform.eulerAngles = new Vector3(sunStartXRotation, 0, 0);
        sunXRotation = sunStartXRotation;
    }
}
