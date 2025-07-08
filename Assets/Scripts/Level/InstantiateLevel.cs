using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject levelPrefab;

    [SerializeField]
    private Transform levelParent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstantiateObject(4);
        }
    }

    private void InstantiateObject(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 instantiatePosition = new Vector3(levelPrefab.transform.position.x, levelPrefab.transform.position.y, levelPrefab.transform.position.z + levelPrefab.transform.localScale.z);
            GameObject obj = Instantiate(levelPrefab, instantiatePosition, Quaternion.identity);
            levelPrefab = obj;

        }
    }
}
