using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[System.Serializable]
public class CharacterSOData
{
    public uint key;
    public string path;
}

[CreateAssetMenu(fileName = "CharacterResSO", menuName = "Game Config SO/CharacterResSO")]
public class CharacterResSO : ScriptableObject
{
    [LabelText("角色资源配置SO")]
    public Dictionary<uint, CharacterSOData> CharacterSoDatas = new ();
}
