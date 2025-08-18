using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;
using InputAction = UnityEngine.InputSystem.InputAction;

public class PlayerInputController : MonoBehaviour
{
    [Title("player_state")] 
    [ShowInInspector] private bool isMoveDirty_1;
    
    private EntityManager entityManager;

    private void Awake()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

    private void Update()
    {
        UpdateEntityMove(PlayerRegistrationSystem.playerEntity_1, isMoveDirty_1?InputService.Instance.moveValue:Vector2.zero);
    }

    private void OnEnable()
    {
        InputService.Instance.onMovePerformed.AddListener(OnMovePerformed);
        InputService.Instance.onMoveCanceled.AddListener(OnMoveCanceled);
    }

    private void OnDisable()
    {
        if (InputService.Instance)
        {
            InputService.Instance.onMovePerformed.RemoveListener(OnMovePerformed);
            InputService.Instance.onMoveCanceled.RemoveListener(OnMoveCanceled);
        }
    }

    #region Entity状态更新

    private void UpdateEntityMove(Entity entity, Vector2 inputValue)
    {
        if (!entityManager.Exists(entity))
        {
            return;
        }
        IPlayerInputData inputData = new()
        {
            inputValue = inputValue
        };
        entityManager.SetComponentData(entity, inputData);
    }

    #endregion

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        isMoveDirty_1 = true;
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        isMoveDirty_1 = false;
    }
}
