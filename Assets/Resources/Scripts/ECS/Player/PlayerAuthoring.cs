using System;
using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

[RequireComponent(typeof(CharacterAuthoring))]
class PlayerAuthoring : MonoBehaviour
{
    public PlayerType playerType;
}

class PlayerAuthoringBaker : Baker<PlayerAuthoring>
{
    public override void Bake(PlayerAuthoring authoring)
    {
        Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);

        // tag
        switch (authoring.playerType)
        {
            case PlayerType.MainPlayer:
                AddComponent<IPlayer1TagData>(entity);
                break;
            case PlayerType.SecondaryPlayer:
                AddComponent<IPlayer2TagData>(entity);
                break;
        }
        
        // move
        IMoveData moveData = new();
        AddComponent(entity, moveData);
        
        // input
        IPlayerInputData inputData = new();
        AddComponent(entity, inputData);
    }
}
