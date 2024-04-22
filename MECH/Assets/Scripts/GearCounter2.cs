using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearCounter2 : MonoBehaviour
{
    public int gearCount;

    // Start is called before the first frame update
    void Start()
    {
        gearCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
    }
}
