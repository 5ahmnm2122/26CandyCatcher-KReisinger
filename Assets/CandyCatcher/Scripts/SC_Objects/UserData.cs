using UnityEngine;

[CreateAssetMenu(fileName = "TransferData", menuName = "CandyCatcher/TransferData", order = 1)]
public class UserData : ScriptableObject
{
    public string playerName;
    public bool timeMode;
}