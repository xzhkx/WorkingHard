using UnityEngine;

public class InteractFireRoad : MonoBehaviour
{
    private bool playerInRange, enemyInRange;
    private int areaID = 0;

    private void Awake()
    {
        playerInRange = false;
        enemyInRange = false;
    }

    private void Update()
    {
        PutOutFire();
    }

    private void PutOutFire()
    {
        if (playerInRange && PlayerToolInformation.Instance.currentToolID == areaID)
        {
            gameObject.SetActive(false);
        }
        if (enemyInRange)
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
