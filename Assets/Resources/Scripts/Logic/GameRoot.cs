using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// 游戏入口，默认存在
/// </summary>
public partial class GameRoot : MonoSingleton<GameRoot>
{
    public EntityManager entityManager => World.DefaultGameObjectInjectionWorld.EntityManager;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        OnGameManagerStart();
    }

    private void Update()
    {
        OnGameManagerUpdate();
    }

    private void OnDestroy()
    {
        OnGameManagerDestroy();
    }
}
