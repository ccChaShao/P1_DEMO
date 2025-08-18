using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Serialization;

class CharacterAuthoring : MonoBehaviour
{
    public ICharacterData characterData;
}

class CharacterAuthoringBaker : Baker<CharacterAuthoring>
{
    public override void Bake(CharacterAuthoring authoring)
    {
        Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
        
        // character data
        AddComponent(entity, authoring.characterData);
    }
}
