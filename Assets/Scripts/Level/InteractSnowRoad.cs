using UnityEngine;

public class InteractSnowRoad : MonoBehaviour
{
    private bool playerInRange, enemyInRange;
    private int areaID = 3;

    private void Awake()
    {
        playerInRange = false;
        enemyInRange = false;
    }

    private void Update()
    {
        CleanSnow();
    }

    private void CleanSnow()
    {
        if ((playerInRange && PlayerToolInformation.Instance.currentToolID == areaID) || enemyInRange)
        {
            gameObject.SetActive(false);
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
