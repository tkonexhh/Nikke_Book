using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
using Animation = Spine.Animation;

public class SpineHelper
{
    public static ExposedList<Animation> GetAllAnimation(SkeletonAnimation skeletonAnimation)
    {
        return skeletonAnimation.skeleton.Data.Animations;
    }

    // public static 
}
