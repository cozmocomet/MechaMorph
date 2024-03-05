using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSCript : MonoBehaviour
{

    [SerializeField] float health, maxHEalth = 3f;

    // Start is called before the first frame update
    private void Start()
    {
        health = maxHEalth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
