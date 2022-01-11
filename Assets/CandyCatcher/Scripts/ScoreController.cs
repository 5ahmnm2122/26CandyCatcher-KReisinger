using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Utility;

public class ScoreController : MonoBehaviour
{


    [Header("References")]
    [Space(10)]

    public UserData transferData;
    public Text nameTxt;
    public Text scoreTxt;

    void Start()
    {
        nameTxt.text = transferData.playerName;
        scoreTxt.text = transferData.score.ToString();    
    }

    public void Restart() {
        SceneManager.LoadScene("MenuScene");
    }
}

