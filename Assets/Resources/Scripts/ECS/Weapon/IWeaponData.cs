using Sirenix.OdinInspector;
using Unity.Entities;

[System.Serializable]
public struct IWeaponData : IComponentData
{
    [LabelText("发射间隔")] public float interval;
}

public struct ILineWeaponData : IComponentData
{
    [LabelText("发射间隔")] public float interval;
}

public struct IAddWeaponEvent : IComponentData
{
    public int weaponId;
}