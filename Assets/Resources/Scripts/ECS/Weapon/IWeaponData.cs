using Sirenix.OdinInspector;
using Unity.Entities;

[System.Serializable]
public struct IWeaponData : IComponentData
{
    [LabelText("发射间隔")] public float interval;
    
    [LabelText("发射次数")] public float times;
}

public struct ILineWeaponData : IComponentData
{
    [LabelText("发射间隔")] public float interval;
}