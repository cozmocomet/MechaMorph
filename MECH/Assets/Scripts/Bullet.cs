using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f;
    public float timeLeft = 3.0f;



    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        timeLeft = timeLeft - Time.deltaTime;

        if (timeLeft < 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "GroundEnemy")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

}

