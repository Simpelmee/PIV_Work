using UnityEngine;

[CreateAssetMenu(fileName = "GameStats", menuName = "Scriptable Objects/GameStats")]
public class GameStats : ScriptableObject
{
    public int wheatAmount = 0;
    public int carrotAmount = 0;
    public int radishAmount = 0;
    
    public int dayCounter = 0;
}
