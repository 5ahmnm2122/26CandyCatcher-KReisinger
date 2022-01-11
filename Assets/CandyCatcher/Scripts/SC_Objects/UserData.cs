using UnityEngine;

[CreateAssetMenu(fileName = "TransferData", menuName = "CandyCatcher/TransferData", order = 2)]
public class UserData : ScriptableObject
{
    public string playerName;
    public bool timeMode;
    public int score;
}