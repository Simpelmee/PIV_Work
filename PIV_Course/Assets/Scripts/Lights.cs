using UnityEngine;

public class Lights : MonoBehaviour
{
    [SerializeField] float lightSwitchTimer = 10f;
    float lightTimeCounter = 0;
    [SerializeField] int startIndex = 0;
    [SerializeField] Material[] material;
    Light colorLight;
    Color color;
    Renderer objectRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //material = GetComponent<Material>();
        colorLight = GetComponent<Light>();
        objectRenderer = GetComponent<Renderer>();
        ChangeLightColor(startIndex);
    }

    // Update is called once per frame
    void Update()
    {
        lightTimeCounter += Time.fixedDeltaTime * Time.timeScale;
        if (lightTimeCounter >= lightSwitchTimer)
        {
            lightTimeCounter = 0;
            UpdateLight();
        }
    }

    void UpdateLight()
    {
        switch (startIndex)
        {
            case 0:
                startIndex++;
                ChangeLightColor(startIndex);
                break;
            case 1:
                startIndex++;
                ChangeLightColor(startIndex);
                break;
            case 2:
                startIndex++;
                ChangeLightColor(startIndex);
                break;
            case 3:
                startIndex = 0;
                ChangeLightColor(startIndex);
                break;
        }
    }

    void ChangeLightColor(int index)
    {
        objectRenderer.material = material[index];
        color = material[index].GetColor("_Color");
        colorLight.color = color;
    }
}
