using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetValue : MonoBehaviour
{

    [SerializeField] Text GearDisplay;

    public void LoadSceneAndKeepValue()
    {
        string dataToKeep = GearDisplay.text;
        SceneManager.LoadScene("Upgrades_01")
    }
}
