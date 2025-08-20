using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial class GameRoot
{
    #region 鱼群GM
    
    private string spawnCount = "1000";

    public string leaderWeight = "10";
    
    private string separationWeight = "4";
    private string alignmentWeight = "1";
    private string cohesionWeight = "0.5";

    #endregion
    
    private void OnGUI()
    {
        #region 鱼群GM
        
        GUILayout.Label("FISH BOIDS SPAWER COUNT");
        spawnCount = GUILayout.TextField(spawnCount);
        
        GUILayout.Label("FISH BOIDS LEADER WEIGHT");
        leaderWeight = GUILayout.TextField(leaderWeight);
        
        GUILayout.Label("FISH BOIDS SEPARATION WEIGHT");
        separationWeight = GUILayout.TextField(separationWeight);
        
        GUILayout.Label("FISH BOIDS ALIGNMENT WEIGHT");
        alignmentWeight = GUILayout.TextField(alignmentWeight);
        
        GUILayout.Label("FISH BOIDS COHESION WEIGHT");
        cohesionWeight = GUILayout.TextField(cohesionWeight);
        
        if (GUILayout.Button("FISH BOIDS SPAWER", GUILayout.Height(50)))
        {
            var entity = entityManager.CreateEntity();
            
            entityManager.AddComponent<IFishSpawnerData>(entity);
            entityManager.SetComponentData(entity, new IFishSpawnerData()
            {
                // 注意：这里并没有拆箱（因为没进行装箱）
                spawnerCount = int.Parse(spawnCount),
                leaderWeight = float.Parse(leaderWeight),
                separationWeight = float.Parse(separationWeight),
                alignmentWeight = float.Parse(alignmentWeight),
                cohesionWeight = float.Parse(cohesionWeight),
            });
        }

        if (GUILayout.Button("FISH BOIDS CLEAR", GUILayout.Height(50)))
        {
            var entity = entityManager.CreateEntity();
            entityManager.AddComponent<IFishClearData>(entity);
            entityManager.SetComponentData(entity, new IFishClearData());
        }

        #endregion
    }
}
