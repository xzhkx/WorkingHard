using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class EnemyToolManager : MonoBehaviour
{
    public static Action<int> EnemyChangeTool;

    [SerializeField]
    private EnemyMovement enemyMovement;

    [SerializeField]
    private List<GameObject> toolTypes = new List<GameObject>(5);

    [SerializeField]
    private float timeToChangeTool;

    private GameObject currentTool;
    private WaitForSeconds waitForTool;
    private void Awake()
    {
        EnemyChangeTool += OnChangeTool;

        currentTool = toolTypes[1];
        waitForTool = new WaitForSeconds(timeToChangeTool);
    }

    public void OnChangeTool(int toolID)
    {
        currentTool.SetActive(false);
        currentTool = toolTypes[toolID];
        currentTool.SetActive(true);
        StartCoroutine(WaitForChangingTool());
    }

    IEnumerator WaitForChangingTool()
    {
        enemyMovement.SlowDownEnemy();
        yield return waitForTool;
        enemyMovement.SpeedUpEnemy();
    }
}
