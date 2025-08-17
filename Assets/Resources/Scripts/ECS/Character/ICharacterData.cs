using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

public struct ICharacterData : IComponentData
{
    [Title("角色属性")] 
    [LabelText("生命值")] public float health;
    
    [LabelText("移动速度")] public float moveSpeed;
}
