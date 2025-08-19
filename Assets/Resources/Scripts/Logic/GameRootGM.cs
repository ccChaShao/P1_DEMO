using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial class GameRoot
{
    private void OnGUI()
    {
        if (GUILayout.Button("FISH BOID TEST", GUILayout.Height(50)))
        {
            var entity = entityManager.CreateEntity();
            entityManager.AddComponent<IFishSpawnerData>(entity);
            entityManager.SetComponentData(entity, new IFishSpawnerData()
            {
                spawnerCount = 1000,
            });
        }
    }
}
