using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public UserData transferData;
    
    public Text playerNameInput;

    public void PlayGame() {
        transferData.playerName = playerNameInput.text;
        SceneManager.LoadScene("MainScene");
    }
}
