using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class CharacterSOData
{
    public uint speed;
    public uint damge;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Game SO/Character SO")]
public class CharacterSO : ScriptableObject
{
    public List<CharacterSOData> characterSoDatas = new();
}
