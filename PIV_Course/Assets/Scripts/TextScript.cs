using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class TextScript : MonoBehaviour
{
    private TMP_Text textField;
    [SerializeField] GameStats gameStats;
    [SerializeField] string successText = "Press 'E' To Deposit 5 Wheat";
    [SerializeField] string failureText = "You Don't Have Enough Wheat";
    [SerializeField] string completionText = "You Have Already Feed The Animals";

    private int wheatAmount;
    private int dayCounter = 0;
    private int dayCounterHolder = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        textField = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        dayCounter = gameStats.dayCounter;
        if (dayCounterHolder < dayCounter)
        {
            dayCounterHolder = dayCounter;
            wheatAmount = gameStats.wheatAmount;
        }
        if (gameStats.wheatAmount >= 5)
        {
            textField.text = successText;
        }
        else
        {
            textField.text = failureText;
        }
    }

    private void Update()
    {
        if (wheatAmount != gameStats.wheatAmount)
        {
            textField.text = completionText;
        }
    }
}
