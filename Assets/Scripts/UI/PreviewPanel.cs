using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewPanel : MonoBehaviour
{
    [SerializeField] private Button m_BtnNext;
    [SerializeField] private Button m_BtnPrevious;

    private void Awake()
    {
        m_BtnNext.onClick.AddListener(OnClickNext);
        m_BtnPrevious.onClick.AddListener(OnClickPrevious);
    }

    private void OnClickNext()
    {
        EventSystem.S.Send(EventID.OnClickNextCharacter);
    }

    private void OnClickPrevious()
    {
        EventSystem.S.Send(EventID.OnClickPreviousCharacter);
    }
}
