using UnityEngine;

public class InteractSnowRoad : MonoBehaviour
{
    private bool playerInRange;
    private int areaID = 3;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        if (!playerInRange) return;
        CleanSnow();
    }

    private void CleanSnow()
    {
        if (PlayerToolInformation.Instance.currentToolID == areaID)
        {
            gameObject.SetActive(false);
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
