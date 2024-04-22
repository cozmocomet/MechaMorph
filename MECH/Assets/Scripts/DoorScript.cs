using UnityEngine;
using System.Collections;

public class doorTriggerScript : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //this is all I need to call the method
            GameObject go = GameObject.Find("verticalWall_1");
            go.GetComponent<raiseWall>().raiseTheWall();
            Debug.Log("The button clicked, raising the wall");

        }
    }
}
