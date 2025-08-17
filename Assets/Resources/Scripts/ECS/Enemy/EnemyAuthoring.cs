using Unity.Entities;
using UnityEngine;

[RequireComponent(typeof(CharacterAuthoring))]
class EnemyAuthoring : MonoBehaviour
{
    
}

class EnemyAuthoringBaker : Baker<EnemyAuthoring>
{
    public override void Bake(EnemyAuthoring authoring)
    {
        Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
        
        // enemy tag
        IEnemyTagData enemyTag = new();
        AddComponent(entity, enemyTag);
        
        // move 
        IMoveData moveData = new();
        AddComponent(entity, moveData);
    }
}
