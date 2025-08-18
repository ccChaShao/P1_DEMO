using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

[RequireComponent(typeof(CharacterAuthoring))]
class WeaponAuthoring : MonoBehaviour
{
    public IWeaponData weaponData;
}

class WeaponAuthoringBaker : Baker<WeaponAuthoring>
{
    public override void Bake(WeaponAuthoring authoring)
    {
        Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
        
        // weapon data
        AddComponent(entity, authoring.weaponData);
        
        // move
        IMoveData moveData = new();
        AddComponent(entity, moveData);
    }
}
