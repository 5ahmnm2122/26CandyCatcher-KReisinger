using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.CandyCatched(Parser.ParseStringToInt(other.name));
        Destroy(other.gameObject);
    }
}
