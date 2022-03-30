using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UnityEditorHelper
{
    public static List<T> GetSelectDirectoryMat<T>() where T : Object
    {
        string[] guids1 = AssetDatabase.FindAssets("t:material");
        List<T> contents = new List<T>();
        foreach (string guid1 in guids1)
        {
            string targetPath = AssetDatabase.GUIDToAssetPath(guid1);
            T t = AssetDatabase.LoadAssetAtPath<T>(targetPath);
            contents.Add(t);
        }
        return contents;
    }
}
