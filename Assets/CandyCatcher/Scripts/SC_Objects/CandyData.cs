using UnityEngine;

[CreateAssetMenu(fileName = "Candy", menuName = "CandyCatcher/Candy", order = 1)]
public class CandyData : ScriptableObject
{
    public bool goodCandy;
    public GameObject candyPref;
    public float value;

}