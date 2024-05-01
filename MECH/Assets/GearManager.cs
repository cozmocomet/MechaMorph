
using TMPro;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    public static GearManager instance;

    private int gears;
    [SerializeField] private TMP_Text gearDisplay;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnGUI()
    {
        gearDisplay.text = gears.ToString();
    }

    public void ChangeGears(int amount)
    {
        gears += amount;
    }
}
