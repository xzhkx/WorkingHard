using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonEnable : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToEnable;
    private Button thisButton;

    private void Awake()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(EnableObject);

        objectToEnable.SetActive(false);
    }

    private void EnableObject()
    {
        objectToEnable.SetActive(true);
        Time.timeScale = 0;
    }
}
