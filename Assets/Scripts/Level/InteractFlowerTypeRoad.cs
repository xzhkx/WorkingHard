using UnityEngine;

public class InteractFlowerTypeRoad : MonoBehaviour
{
    private Vector3 originalScale = new Vector3(1f, 1, 1f) * 0.35f;
    private Vector3 growScale = Vector3.one;

    private int areaID = 4;

    private bool playerInRange;
    private bool isWatering;

    private float growTime = 0.75f;
    private float elapsedTime;

    private void Awake()
    {
        playerInRange = false;
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
        if (!playerInRange) return;
        WateringFlower();
    }

    private void WateringFlower()
    {
        if (PlayerToolInformation.Instance.currentToolID == areaID)
        {
            isWatering = true;

            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / growTime;

            transform.localScale = Vector3.Lerp(originalScale, growScale, percentageComplete);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Player")) return;
        playerInRange = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Player")) return;
        playerInRange = false;
    }
}
