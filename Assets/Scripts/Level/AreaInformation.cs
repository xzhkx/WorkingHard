using UnityEngine;

public class AreaInformation : MonoBehaviour
{
    [SerializeField]
    private int areaID;

    private PlayerToolInformation playerToolInformation;
    private bool playerInRange;

    private void Awake()
    {
        playerToolInformation = PlayerToolInformation.Instance;
        playerInRange = false;
    }

    private void FixedUpdate()
    {
        if (!playerInRange) return;

        if (playerToolInformation.currentToolID == areaID)
        {
            playerToolInformation.SpeedUpPlayer();
        }
        else
        {
            playerToolInformation.SlowDownPlayer();
        }
    }

    public int GetAreaID()
    {
        return areaID;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            UIRandomizeToolManager.Instance.RandomizeTool(areaID);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyToolManager.EnemyChangeTool?.Invoke(areaID);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        playerInRange = false;
    }
}
