using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolManager : MonoBehaviour
{
    public static Action<int> ChangeToolAction;

    [SerializeField]
    private List<GameObject> toolTypes = new List<GameObject>(5);

    private GameObject currentTool;

    private void Awake()
    {
        ChangeToolAction += OnChangeTool;
        currentTool = toolTypes[1];
        currentTool.SetActive(true);
    }

    private void OnChangeTool(int toolID)
    {
        currentTool.SetActive(false);
        currentTool = toolTypes[toolID];
        currentTool.SetActive(true);
    }
}
