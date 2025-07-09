using UnityEngine;

public class InteractDirtRoad : MonoBehaviour
{
    private bool playerInRange;
    private int areaID = 1;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        if (!playerInRange) return;
        CleanDirt();
    }

    private void CleanDirt()
    {
        if(PlayerToolInformation.Instance.currentToolID == areaID)
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
