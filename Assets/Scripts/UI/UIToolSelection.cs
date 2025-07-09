using UnityEngine;
using UnityEngine.UI;

public class UIToolSelection : MonoBehaviour
{
    private int toolID;
    private Image toolImage;

    private void Start()
    {
        Button toolButton = GetComponent<Button>();
        toolButton.onClick.AddListener(ChangeTool);

        toolImage = GetComponent<Image>();
    }

    public void SetNewTool(ToolScriptableObject tool)
    {
        toolID = tool.toolID;

        toolImage.sprite = tool.toolSprite;
    }

    private void ChangeTool()
    {
        PlayerToolManager.ChangeToolAction(toolID);
    }
}
