using UnityEngine;
using UnityEngine.UI;

public class UIToolSelection : MonoBehaviour
{
    private int toolID;
    private Image toolImage;

    private void Awake()
    {
        Button toolButton = GetComponent<Button>();
        toolButton.onClick.AddListener(ChangeTool);

        toolImage = GetComponent<Image>();
    }

    public void SetNewTool(ToolScriptableObject tool)
    {
        toolID = tool.toolID;
        this.toolImage.sprite = tool.toolSprite;
    }

    private void ChangeTool()
    {
        PlayerToolManager.ChangeToolAction(toolID);
    }
}
