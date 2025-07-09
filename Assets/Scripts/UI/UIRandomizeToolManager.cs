using System.Collections.Generic;
using UnityEngine;

public class UIRandomizeToolManager : MonoBehaviour
{
    public static UIRandomizeToolManager Instance;

    [SerializeField]
    private List<ToolScriptableObject> toolScriptableObjects = new List<ToolScriptableObject>(6);

    [SerializeField]
    private List<GameObject> toolUI = new List<GameObject>(3);

    private List<int> toolIDS;
    private List<int> selectedToolIDS = new List<int>(3);

    private void Awake()
    {
        Instance = this;
        toolIDS = new List<int>(toolScriptableObjects.Count);

        for(int i = 0; i < toolScriptableObjects.Count; i++)
        {
            toolIDS.Add(i);
        }      
    }

    public void RandomizeTool(int matchToolID)
    {
        toolIDS.Remove(matchToolID);
        selectedToolIDS.Add(matchToolID);
        
        for(int i = 0; i < 2; i++) 
        {
            int randomToolID = toolIDS[Random.Range(0, toolIDS.Count)];
            toolIDS.Remove(randomToolID);
            selectedToolIDS.Add(randomToolID);
        }

        int randIndex = Random.Range(0, 2);
        int a = selectedToolIDS[randIndex];
        int b = selectedToolIDS[0];
        selectedToolIDS[0] = a;
        selectedToolIDS[randIndex] = b;

        for (int i = 0; i < 3; i++)
        {
            toolUI[i].GetComponent<UIToolSelection>().SetNewTool(toolScriptableObjects[selectedToolIDS[i]]);
        }

        toolIDS.Clear();
        selectedToolIDS.Clear();

        for (int i = 0; i < toolScriptableObjects.Count; i++)
        {
            toolIDS.Add(i);
        }
    }
}
