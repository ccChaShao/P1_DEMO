using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

class PrefabAuthoring : MonoBehaviour
{
    [LabelText("关联预制体")] public GameObject prefab;
}

class PrefabAuthoringBaker : Baker<PrefabAuthoring>
{
    public override void Bake(PrefabAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);
        // 标记为预制件实体
        AddComponent<Prefab>(entity);
        // 添加LinkedEntityGroup管理子实体
        AddBuffer<LinkedEntityGroup>(entity);
    }
}
