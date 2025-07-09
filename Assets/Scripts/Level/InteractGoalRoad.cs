using UnityEngine;

public class InteractGoalRoad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerToolManager.ChangeToolAction?.Invoke(1);
            other.gameObject.GetComponent<PlayerMovement>().StopPlayer();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyToolManager.EnemyChangeTool?.Invoke(1);
            other.gameObject.GetComponent<EnemyMovement>().StopEnemy();
        }
    }
}
