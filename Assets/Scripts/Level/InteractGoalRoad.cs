using UnityEngine;

public class InteractGoalRoad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerToolManager.ChangeToolAction?.Invoke(1);
            PlayerToolInformation.Instance.StopPlayer();
        }
    }
}
