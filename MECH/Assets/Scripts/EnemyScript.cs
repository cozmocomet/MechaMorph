using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;

        if (Player.transform.position.x > transform.position.x)
            scale.x = Mathf.Abs(scale.x) * -1;
        {
            transform.localScale = scale;
        }
    }
}
