using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int bulletDamage;
    GameObject Bullet;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().damageEnemy(bulletDamage);
            Destroy(gameObject);
            Debug.Log("Enemy Hit!)");
        }
    }
}
