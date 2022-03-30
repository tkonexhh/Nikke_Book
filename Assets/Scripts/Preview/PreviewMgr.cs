using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewMgr : MonoBehaviour
{
    public ClickHandle clickHandle;
    public SpineHandle spineHandle;

    private void Awake()
    {
        CharacterMgr.S.Init();
    }
    private void Start()
    {

        clickHandle.onClick += OnClickSpine;
    }

    private void OnDestroy()
    {
        clickHandle.onClick -= OnClickSpine;
    }


    private void OnClickSpine()
    {
        spineHandle.character?.PlayRandomAnimation();
    }
}
