using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct IFishSchool : IComponentData
{
    public Entity prefab;
}

public class FishSchoolAuthoring : MonoBehaviour
{
    public GameObject fishPrefab;

    class Baker : Baker<FishSchoolAuthoring>
    {
        public override void Bake(FishSchoolAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new IFishSchool
            {
                prefab = GetEntity(authoring.fishPrefab, TransformUsageFlags.Dynamic),
            });
        }
    }
}
