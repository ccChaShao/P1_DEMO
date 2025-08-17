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

        // player tag
        switch (authoring.playerType)
        {
            case PlayerType.MainPlayer:
                AddComponent<IMainPlayerTagData>(entity);
                break;
            case PlayerType.SecondaryPlayer:
                AddComponent<ISecondaryPlayerTagData>(entity);
                break;
        }
        
        // input
        IPlayerInputData inputData = new();
        AddComponent(entity, inputData);
        
        // move
        IMoveData moveData = new();
        AddComponent(entity, moveData);
    }
}
