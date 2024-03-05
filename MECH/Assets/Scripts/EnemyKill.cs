using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKill : MonoBehaviour
{
    private bool loadingScene = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (loadingScene == false)
            {
                loadingScene = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


    }

}