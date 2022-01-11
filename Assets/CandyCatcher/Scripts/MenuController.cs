using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public UserData transferData;
    public GameObject description;
    public GameObject descriptionLifeMode;
    public Text playerNameInput;
    public Dropdown modeSelect;

    void Start() {
        transferData.timeMode = true;
        modeSelect.options.Clear();
        modeSelect.captionText.text = "Modus wählen";
        modeSelect.options.Add(new Dropdown.OptionData() {text = "Zeit Modus"});
        modeSelect.options.Add(new Dropdown.OptionData() {text = "Leben Modus"});
        modeSelect.onValueChanged.AddListener(delegate{DropdownModeSelected(modeSelect);});
    }

    private void DropdownModeSelected(Dropdown dropdown) {
        int index = dropdown.value;
        if(dropdown.options[index].text == "Zeit Modus") {
            transferData.timeMode = true;
            descriptionLifeMode.SetActive(false);
            description.SetActive(true);
        } else {
            transferData.timeMode = false;
            descriptionLifeMode.SetActive(true);
            description.SetActive(false);
        }
    }
    public void PlayGame() {
        transferData.playerName = playerNameInput.text;
        SceneManager.LoadScene("MainScene");
    }
}
