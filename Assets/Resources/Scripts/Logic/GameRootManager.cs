using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public partial class GameRoot
{
    [BoxGroup("GamePlayerManager")] 
    
    [LabelText("玩家相机 - 预制体")] public GameObject playerCameraRootPrefab;

    private GameObject playerCameraRoot;

    private void OnGameManagerStart()
    {
        InitPlayerCamera();
    }

    private void OnGameManagerUpdate()
    {
    }

    private void OnGameManagerDestroy()
    {
    }

    #region GamePlayerManager

    private void InitPlayerCamera()
    {
        if (!playerCameraRootPrefab)
        {
            return;
        }
        // 资源加载
        playerCameraRoot = Instantiate(playerCameraRootPrefab, transform);
        // system syn
        VCameraProxySystem.vCameraProxy = playerCameraRoot.transform.GetChild(1);           // 第二个是代理点
    }

    #endregion
}
