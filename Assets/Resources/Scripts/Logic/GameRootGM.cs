using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial class GameRoot
{
    private void OnGUI()
    {
        if (GUILayout.Button("添加【汉堡】武器", GUILayout.Height(50)))
        {
            Entity entity = entityManager.CreateEntity();
            IAddWeaponEvent eventData = new()
            {
                weaponId = 1
            };
            entityManager.AddComponent<IAddWeaponEvent>(entity);
            entityManager.SetComponentData(entity, eventData);
        }
    }
}
