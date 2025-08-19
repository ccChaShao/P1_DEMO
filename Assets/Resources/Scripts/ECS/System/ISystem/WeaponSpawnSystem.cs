using Unity.Burst;
using Unity.Entities;
using Unity.Scenes;
using Unity.Collections;
using Unity.Entities.Serialization;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UIElements;

[BurstCompile]
partial struct WeaponSpawnSystem : ISystem
{
    private float timer;
    
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<IPrefabSchool>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        timer -= SystemAPI.Time.DeltaTime;
        if (timer > 0)
        {
            return;
        }

        timer = 1;
        
        IPrefabSchool prefabSchool = SystemAPI.GetSingleton<IPrefabSchool>();
        Entity entity = state.EntityManager.Instantiate(prefabSchool.weaponPrefab);
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
