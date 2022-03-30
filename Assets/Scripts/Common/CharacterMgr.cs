using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CharacterMgr : TMonoSingleton<CharacterMgr>
{
    private CharacterBookDataSO m_BookData;


    [ShowInInspector]
    public CharacterBookDataSO BookDataSO => m_BookData;

    private void Start()
    {
        // var request = Resources.LoadAsync("SO/CharacterBookDataSO");
        // request.completed += (s) =>
        // {
        //     m_BookData = request.asset as CharacterBookDataSO;
        // };

        m_BookData = Resources.Load("SO/CharacterBookDataSO") as CharacterBookDataSO;
    }

    public void Init()
    {

    }


    public string GetPreviewPath(string resID)
    {
        return $"Prefab/Prepare/{resID}_00";
    }
}
