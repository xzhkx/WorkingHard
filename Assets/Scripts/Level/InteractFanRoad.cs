using UnityEngine;

public class InteractFanRoad : MonoBehaviour
{
    private GameObject fan, fanBreak;
    private int areaID = 2;
    private bool playerInRange, enemyInRange;

    private void Awake()
    {
        playerInRange = false;
        enemyInRange = false;

        fan = transform.GetChild(0).gameObject;
        fanBreak = transform.GetChild(1).gameObject;

        fan.SetActive(false);
        fanBreak.SetActive(true);
    }

    private void FixedUpdate()
    {
        FixFan();
    }

    private void FixFan()
    {
        if ((playerInRange && PlayerToolInformation.Instance.currentToolID == areaID) ||
            enemyInRange)
        {
            fan.SetActive(true);
            fanBreak.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
        if (collider.gameObject.CompareTag("Enemy"))
        {
            enemyInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
        if (collider.gameObject.CompareTag("Enemy"))
        {
            enemyInRange = false;
        }
    }
}
