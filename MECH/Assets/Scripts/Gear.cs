
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private GearManager gearManager;

    private void Start()
    {
        gearManager = GearManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            gearManager.ChangeGears(value);
            Destroy(gameObject);
        }
    }
}
