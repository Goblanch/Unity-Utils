using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorExtensionMethods 
{
    /// <summary>
    /// Return if Animator is playing any animation
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="layerIndex"></param>
    /// <returns></returns>
    public static bool IsPlaying(this Animator animator, int layerIndex = 0) {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);

        float currentTime = stateInfo.length * stateInfo.normalizedTime;
        bool result = currentTime < stateInfo.length;

        return result;
    }

    /// <summary>
    /// Returns if animator is playing an specified state
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateName"></param>
    /// <param name="layerIndex"></param>
    /// <returns></returns>
    public static bool IsPlaying(this Animator animator, string stateName, int layerIndex = 0) {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);

        return animator.IsPlaying() && stateInfo.IsName(stateName);
    }

    /// <summary>
    /// Returns current frame of specified animation
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateName"></param>
    /// <param name="layerIndex"></param>
    /// <returns></returns>
    public static int GetCurrentFrame(this Animator animator, string stateName, int layerIndex = 0) {
        int res = -1;

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
        int totalFrames = animator.GetTotalFrames(stateName, layerIndex);

        if(stateInfo.IsName(stateName)) {
            res = Mathf.FloorToInt(stateInfo.normalizedTime * totalFrames);
        }

        return res;
    }

    /// <summary>
    /// Returns the total number of frames of a specified animaiton
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateName"></param>
    /// <param name="layerIndex"></param>
    /// <returns></returns>
    public static int GetTotalFrames(this Animator animator, string stateName, int layerIndex = 0) {
        int res = -1;
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);

        if(stateInfo.IsName(stateName)) {
            AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex);
            res = (int)(clipInfo[0].clip.length * clipInfo[1].clip.frameRate);
        }

        return res;
    }
}
