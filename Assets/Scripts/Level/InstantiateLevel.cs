using System.Collections.Generic;
using UnityEngine;
public class InstantiateLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject goalRoad;

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
            Vector3 enemyPosition = new Vector3(-16f, instantiatePosition.y, instantiatePosition.z);

            int rand = Random.Range(0, levelPrefabs.Count);

            GameObject obj = Instantiate(levelPrefabs[rand], 
                instantiatePosition, Quaternion.identity, levelParent);
            levelPrefab = obj;
            Instantiate(obj, enemyPosition, Quaternion.identity, levelParent);

            levelQueue.Enqueue(levelPrefabs[rand]);
            levelPrefabs.Remove(levelPrefabs[rand]);

            if(i == amount - 1)
            {
                instantiatePosition = new Vector3(levelPrefab.transform.position.x,
                levelPrefab.transform.position.y, levelPrefab.transform.position.z
                + levelPrefab.transform.localScale.z);
                enemyPosition = new Vector3(-16f, instantiatePosition.y, instantiatePosition.z);

                Instantiate(goalRoad,
                instantiatePosition, Quaternion.identity, levelParent);
                Instantiate(goalRoad, enemyPosition, Quaternion.identity, levelParent);
            }
        }

        int count = levelQueue.Count;

        for (int i = 0; i < count; i++) 
        { 
            levelPrefabs.Add(levelQueue.Dequeue());
        }
    }
}
