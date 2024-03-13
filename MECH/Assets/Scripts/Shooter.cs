using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    bool isFacingRight = true;
    bool facingRight = true;

    float inputHorizontal;
    float inputVertical;

    public Transform bulletTransform;
    public bool canFire = true;
    private float timer = 1.0f;
    public float timeBetweenFiring;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        {
            if (isFacingRight == false)
            {
                rotZ = Mathf.Atan2(rotation.y, -rotation.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, -rotZ);

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (canFire)
            {
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
                canFire = false;

            }
        }

        Timer();
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    void Timer()
    {
        Debug.Log("Timer");

        timer += Time.deltaTime;
        if (timer > timeBetweenFiring)
        {
            canFire = true;
            timer = 1.0f;
        }
    }

    private void FixedUpdate()
    {
        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }
}
