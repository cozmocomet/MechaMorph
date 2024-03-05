using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public TMP_Text gearText;
    public int gear = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("gear"))
        {

            gear += 1;
            gearText.text = "Gears : " + gear;
            other.gameObject.SetActive(false);

        }

    }
}