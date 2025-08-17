using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 用于公开单例玩家entity
/// </summary>
public partial class PlayerRegistrationSystem : SystemBase
{
    public static Entity playerEntity_1 { get; private set; }           
    
    public static Entity playerEntity_2 { get; private set; }           //TODO 预留本地联机

    protected override void OnUpdate()
    {
        Entities.WithAll<IMainPlayerTagData>().ForEach((Entity entity) =>
            {
                playerEntity_1 = entity;
            }
        ).WithoutBurst().Run();

        Entities.WithAll<IMainPlayerTagData>().ForEach((Entity entity) =>
            {
                playerEntity_2 = entity;
            }
        ).WithoutBurst().Run();
    }
}
