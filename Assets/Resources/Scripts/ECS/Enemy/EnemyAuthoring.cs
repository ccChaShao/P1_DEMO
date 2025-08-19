using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

// 仅作为 enemy tag 使用
public struct IEnemyTagData : IComponentData { }

[RequireComponent(typeof(CharacterAuthoring))]
class EnemyAuthoring : MonoBehaviour
{
    public WeaponType weaponType;

    class EnemyAuthoringBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
        
            // tag
            IEnemyTagData enemyTag = new();
            AddComponent(entity, enemyTag);
        
            // move 
            IMoveData moveData = new();
            AddComponent(entity, moveData);
        }
    }
}
