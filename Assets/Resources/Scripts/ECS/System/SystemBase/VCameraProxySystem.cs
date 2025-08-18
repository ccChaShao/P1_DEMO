using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class VCameraProxySystem : SystemBase
{
    public static Transform vCameraProxy;
    
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity _, in LocalTransform transform, in IPlayer1TagData __) =>
        {
            vCameraProxy.position = transform.Position;
        }).WithoutBurst().Run();
    }
}
