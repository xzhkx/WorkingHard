using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Create New Tool")]
public class ToolScriptableObject : ScriptableObject
{
    public int toolID;
    public string toolName;
    public Sprite toolSprite;
}
