using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public struct IFishData : IComponentData {
    public float speed;                 // 移动速度
    public float perceptionRadius;      // 感知半径（邻居检测范围）
}

public struct IFishMovementData : IComponentData {
    public float2 velocity;      // 当前速度方向
}

public struct IFishTag : IComponentData { }

// 鱼群生成指令
public struct IFishSpawnerData : IComponentData
{
    public int spawnerCount;

    public float leaderWeight;
    
    public float separationWeight;
    public float alignmentWeight;
    public float cohesionWeight;
}

// 鱼群销毁指令
public struct IFishClearData : IComponentData { }

public class FishAuthoring : MonoBehaviour
{
    public IFishData fishData;

    class Baker : Baker<FishAuthoring>
    {
        public override void Bake(FishAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, authoring.fishData);
            AddComponent(entity, new IFishTag());
            AddComponent(entity, new IFishMovementData());
        }
    } 
}
