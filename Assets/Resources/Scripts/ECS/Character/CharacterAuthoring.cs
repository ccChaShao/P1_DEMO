using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public struct ICharacterData : IComponentData
{
    [Title("角色属性")] 
    [LabelText("角色类型")] public CharacterType characterType;
    
    [LabelText("生命值")] public float health;

    [LabelText("伤害值")] public float damge;
    
    [LabelText("速度")] public float speed;
}

class CharacterAuthoring : MonoBehaviour
{
    public ICharacterData characterData;

    class CharacterAuthoringBaker : Baker<CharacterAuthoring>
    {
        public override void Bake(CharacterAuthoring authoring)
        {
            Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
        
            // character data
            AddComponent(entity, authoring.characterData);
        }
    }
}
