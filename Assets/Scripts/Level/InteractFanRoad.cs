using UnityEngine;

public class InteractFanRoad : MonoBehaviour
{
    private GameObject fan, fanBreak;
    private int areaID = 2;
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;

        fan = transform.GetChild(0).gameObject;
        fanBreak = transform.GetChild(1).gameObject;

        fan.SetActive(false);
        fanBreak.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (!playerInRange) return;
        FixFan();
    }

    private void FixFan()
    {
        if (PlayerToolInformation.Instance.currentToolID == areaID)
        {
            fan.SetActive(true);
            fanBreak.SetActive(false);
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
