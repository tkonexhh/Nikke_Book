using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
using Animation = Spine.Animation;


public class Character
{
    public CharacterDataSO dataSO;
    public GameObject gameObject { get; private set; }
    public Transform transform { get; private set; }
    public SkeletonAnimation spine { get; private set; }
    public CharacterHandle characterHandle { get; private set; }

    private ExposedList<Animation> m_AllAnimation = new ExposedList<Animation>();

    public Character(CharacterDataSO dataSO)
    {
        this.dataSO = dataSO;
    }

    public void LoadPrefab(System.Action<Character> callback)
    {
        var request = Resources.LoadAsync(CharacterMgr.S.GetPreviewPath(dataSO.ResID));
        request.completed += (s) =>
        {
            gameObject = GameObject.Instantiate(request.asset as GameObject);
            transform = gameObject.transform;
            callback?.Invoke(this);
            spine = gameObject.GetComponent<SkeletonAnimation>();
            InitSpine();
        };
    }

    public void InitSpine()
    {
        GetAllAnimation(spine);
        characterHandle?.Handle(this);
        PlayAnimation("idle", true);
    }

    private void GetAllAnimation(SkeletonAnimation skeletonAnimation)
    {
        m_AllAnimation.Clear();
        m_AllAnimation = SpineHelper.GetAllAnimation(skeletonAnimation);
        // Debug.LogError("Get Animations:" + m_AllAnimation.Count);
    }

    public void PlayRandomAnimation()
    {
        if (gameObject == null) return;
        if (spine == null) return;
        if (m_AllAnimation.Count == 0) return;
        spine.AnimationState.SetAnimation(0, m_AllAnimation.Items[Random.Range(0, m_AllAnimation.Count)], true);
    }

    public void PlayAnimation(string animationName, bool loop)
    {
        if (gameObject == null) return;
        if (spine == null) return;
        spine.AnimationState.SetAnimation(0, animationName, loop);
    }

    public void Release()
    {
        GameObject.Destroy(gameObject);
        transform = null;
        spine = null;
        // m_AllAnimation.Clear();
    }
}
