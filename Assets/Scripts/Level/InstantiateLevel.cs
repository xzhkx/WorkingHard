using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLevel : MonoBehaviour
{
    [SerializeField]
    private Transform levelParent;

    [SerializeField]
    private List<GameObject> levelPrefabs = new List<GameObject>();

    private Queue<GameObject> levelQueue = new Queue<GameObject>();
    private GameObject levelPrefab;

    private void Awake()
    {
        UIStartGame.StartGameAction += OnInstantiateLevel;
    }

    private void OnInstantiateLevel()
    {
        InstantiateObject(4);
    }

    private void InstantiateObject(int amount)
    {
        int random = Random.Range(0, levelPrefabs.Count);
        levelPrefab = levelPrefabs[random];

        for (int i = 0; i < amount; i++)
        {
            Vector3 instantiatePosition = new Vector3(levelPrefab.transform.position.x, 
                levelPrefab.transform.position.y, levelPrefab.transform.position.z 
                + levelPrefab.transform.localScale.z);

            int rand = Random.Range(0, levelPrefabs.Count);

            GameObject obj = Instantiate(levelPrefabs[rand], 
                instantiatePosition, Quaternion.identity, levelParent);
            levelPrefab = obj;

            levelQueue.Enqueue(levelPrefabs[rand]);
            levelPrefabs.Remove(levelPrefabs[rand]);
        }

        int count = levelQueue.Count;

        for (int i = 0; i < count; i++) 
        { 
            levelPrefabs.Add(levelQueue.Dequeue());
        }
    }
}
