using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

/// <summary>
/// 鱼群单例数据
/// </summary>
public struct IFishSchool : IComponentData
{
    public Entity prefab;
    
    public float leaderWeight;
    
    public float separationWeight;
    public float alignmentWeight;
    public float cohesionWeight;
}

public class FishSchoolAuthoring : MonoBehaviour
{
    public GameObject fishPrefab;

    public float leaderWeight = 10.0f;
    
    public float separationWeight = 4.0f;
    public float alignmentWeight = 1.0f;
    public float cohesionWeight = 0.5f;

    class Baker : Baker<FishSchoolAuthoring>
    {
        public override void Bake(FishSchoolAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new IFishSchool
            {
                prefab = GetEntity(authoring.fishPrefab, TransformUsageFlags.Dynamic),
                leaderWeight = authoring.leaderWeight,
                separationWeight = authoring.separationWeight,
                alignmentWeight = authoring.alignmentWeight,
                cohesionWeight = authoring.cohesionWeight,
            });
        }
    }
}
