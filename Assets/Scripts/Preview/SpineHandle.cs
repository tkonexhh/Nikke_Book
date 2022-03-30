using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpineHandle : MonoBehaviour
{
    public Transform spineRoot;

    private CharacterDataSO m_CurCharacterData;
    private CharacterBookDataSO m_BookData;
    private int m_CurCharacterIndex = 0;
    private Character m_CurCharacter;

    public Character character => m_CurCharacter;

    private void Awake()
    {
        EventSystem.S.Register(EventID.OnClickNextCharacter, OnClickNextCharacter);
        EventSystem.S.Register(EventID.OnClickPreviousCharacter, OnClickPreviousCharacter);
    }

    private void Start()
    {
        m_BookData = CharacterMgr.S.BookDataSO;
        RefeshCharacter(m_CurCharacterIndex);
    }

    private void OnDestroy()
    {
        EventSystem.S.UnRegister(EventID.OnClickNextCharacter, OnClickNextCharacter);
        EventSystem.S.UnRegister(EventID.OnClickPreviousCharacter, OnClickPreviousCharacter);
    }

    private void OnClickPreviousCharacter(int key, object[] param)
    {
        m_CurCharacterIndex--;
        if (m_CurCharacterIndex < 0)
        {
            m_CurCharacterIndex = m_BookData.characterDatas.Count - 1;
        }

        RefeshCharacter(m_CurCharacterIndex);
    }

    private void OnClickNextCharacter(int key, object[] param)
    {
        m_CurCharacterIndex++;
        if (m_CurCharacterIndex >= m_BookData.characterDatas.Count)
        {
            m_CurCharacterIndex = 0;
        }
        RefeshCharacter(m_CurCharacterIndex);
    }

    private void RefeshCharacter(int index)
    {
        // if (index == m_CurCharacterIndex)
        //     return;
        if (m_CurCharacter != null)
        {
            m_CurCharacter.Release();
            m_CurCharacter = null;
        }
        m_CurCharacterData = m_BookData.characterDatas[m_CurCharacterIndex];
        m_CurCharacter = CharacterFactory.CreateCharacter(m_CurCharacterData);
        m_CurCharacter.LoadPrefab(OnCharacterLoadComplete);

    }

    private void OnCharacterLoadComplete(Character character)
    {
        character.transform.SetParent(spineRoot);
        character.gameObject.Reset();
    }

}
