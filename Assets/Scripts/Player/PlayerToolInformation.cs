using UnityEngine;

public class PlayerToolInformation : MonoBehaviour
{
    public static PlayerToolInformation Instance;
    public int currentToolID { get; private set; }

    private PlayerMovement playerMovement;

    private void Awake()
    {
        Instance = this;
        currentToolID = 1;

        PlayerToolManager.ChangeToolAction += ChangeToolID;
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void SlowDownPlayer()
    {
        playerMovement.SlowDownPlayer();
    }

    public void SpeedUpPlayer()
    {
        playerMovement.SpeedUpPlayer();
    }

    private void ChangeToolID(int toolID)
    {
        currentToolID = toolID;
    }
}
