using UnityEngine;

public class InteractFlowerTypeRoad : MonoBehaviour
{
    private Vector3 originalScale = new Vector3(1f, 1, 1f) * 0.35f;
    private Vector3 growScale = Vector3.one;

    private int areaID = 4;

    private bool playerInRange, enemyInRange;
    private bool isWatering;

    private float growTime = 0.75f;
    private float elapsedTime;

    private void Awake()
    {
        playerInRange = false;
        enemyInRange = false;

        isWatering = false;
        transform.localScale = originalScale;
    }

    private void Update()
    {
        if (isWatering)
        {
            WateringFlower();
            return;
        }
        WateringFlower();
    }

    private void WateringFlower()
    {
        if ((playerInRange && PlayerToolInformation.Instance.currentToolID == areaID) || 
            enemyInRange)
        {
            isWatering = true;

            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / growTime;

            transform.localScale = Vector3.Lerp(originalScale, growScale, percentageComplete);
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
