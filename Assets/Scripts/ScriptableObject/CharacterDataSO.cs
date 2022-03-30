using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Nikke/CharacterSpineData", fileName = "CharacterSpineData")]
public class CharacterDataSO : SerializedScriptableObject
{
    public string Name;
    public string ResID;
    public RareType RareType;


    [Button("Save")]
    public void Save()
    {
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
        UnityEditor.AssetDatabase.SaveAssets();
#endif
    }
}

public enum RareType
{
    N,
    R,
    SR,
    SSR,
}
