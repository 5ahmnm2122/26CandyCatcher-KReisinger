using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake() {
        current = this;   
    }


    public event Action<string> onDebugEvent;
    public void DebugEvent(string name) {
        if(onDebugEvent != null) {
            onDebugEvent(name);
        }
    }


    
    public event Action<int> onCandyCatched;
    public void CandyCatched(int ID) {
        if(onCandyCatched != null) {
            onCandyCatched(ID);
        }
    }

}