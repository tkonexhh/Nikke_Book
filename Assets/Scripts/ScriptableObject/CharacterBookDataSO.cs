using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Nikke/CharacterBookDataSO", fileName = "CharacterBookDataSO")]
public class CharacterBookDataSO : SerializedScriptableObject
{
    public List<CharacterDataSO> characterDatas = new List<CharacterDataSO>();


#if UNITY_EDITOR
    [Button("CollectCharacterData")]
    public void CollectCharacterData()
    {
        characterDatas.AddRange(GetAllCharacterData());
    }


    public static List<CharacterDataSO> GetAllCharacterData()
    {
        string[] guids1 = AssetDatabase.FindAssets("t:CharacterDataSO");
        List<CharacterDataSO> contents = new List<CharacterDataSO>();
        foreach (string guid1 in guids1)
        {
            string targetPath = AssetDatabase.GUIDToAssetPath(guid1);
            CharacterDataSO t = AssetDatabase.LoadAssetAtPath<CharacterDataSO>(targetPath);
            contents.Add(t);
        }
        return contents;
    }

    [Button("Save")]
    public void Save()
    {
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
        UnityEditor.AssetDatabase.SaveAssets();
#endif
    }
#endif

}
