using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

class CharacterAuthoring : MonoBehaviour
{
    [Title("角色属性")] 
    [LabelText("生命值")] public float health;
    
    [LabelText("移动速度")] public float moveSpeed;
}

class CharacterBaker : Baker<CharacterAuthoring>
{
    public override void Bake(CharacterAuthoring authoring)
    {
        Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
        
        // 基本角色数据
        ICharacterData characterData = new ()
        {
            health = authoring.health,
            moveSpeed = authoring.moveSpeed,
        };
        AddComponent(entity, characterData);
    }
}
