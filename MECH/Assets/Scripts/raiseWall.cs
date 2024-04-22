using UnityEngine;
using System.Collections;

public class raiseWall : MonoBehaviour
{


    public float speed;
    public Transform target;
    public bool raised = false;
    public GameObject bullet;

    // Use this for initialization
    void Start()
    {
        //Vector3 target = new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        void OnCollisionEnter(Collision col)
        {
            if (col.transform.tag == "Bullet")
            {
                if (raised == true)
                {
                    float step = speed * Time.deltaTime;
                    //transform.Translate (0,Time.deltaTime,0,Space.World);
                    transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                }
            }
        }

    }

    public void raiseTheWall()
    {
        raised = true;
    }
}