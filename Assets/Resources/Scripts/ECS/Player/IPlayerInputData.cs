using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// 用于信号处理
/// </summary>
public struct IPlayerInputData : IComponentData
{
    public float2 inputValue;
}
