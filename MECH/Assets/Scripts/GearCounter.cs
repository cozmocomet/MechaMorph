using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GearCounter : MonoBehaviour
{
    public static GearCounter instance;

    public TMP_Text gearText;
    public int currentGears = 0;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gearText.text = "COINS: " + currentGears.ToString();
    }

    public void IncreaseGears(int v)
    {
        currentGears += v;
        gearText.text = "COINS: " + currentGears.ToString();
    }

}
// Update is called once per frame
