using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Tool")]
public class ToolClass : ItemClass
{
    [Header("Tool")]
    public ToolType toolType;
    public enum ToolType
    {
        letter
    }

    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return this; }
}
