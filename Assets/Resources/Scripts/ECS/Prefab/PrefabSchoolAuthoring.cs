using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

public struct IPrefabSchool : IComponentData
{
    public Entity playerPrefab;
     
    public Entity weaponPrefab;
}

public class PrefabSchoolAuthoring : MonoBehaviour
{
    [TitleGroup("玩家 - 预制体")]
    public GameObject playerPrefab;

    [TitleGroup("武器 - 预制体")] 
    public GameObject weaponPrefabs;

    class Baker : Baker<PrefabSchoolAuthoring>
    {
        public override void Bake(PrefabSchoolAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new IPrefabSchool
            {
                playerPrefab = GetEntity(authoring.playerPrefab, TransformUsageFlags.Dynamic),
                weaponPrefab = GetEntity(authoring.weaponPrefabs, TransformUsageFlags.Dynamic)
            });
        }
    }
}
