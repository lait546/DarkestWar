using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] public SkeletonAnimation skeletonAnimation;
    [SerializeField] private Animator animator;
    private AnimationType currentState, previousState;
    private Spine.TrackEntry currentAnimation;

    public void StartAnimation(AnimationType type)
    {
        ChangeAnimation(type);
    }

    public void StartAnimationWithComplete(AnimationType type, Action onEndAnimation)
    {
        ChangeAnimation(type);
        StartCoroutine(IChangeAnimation(onEndAnimation));
    }

    private IEnumerator IChangeAnimation(Action onEndAnimation)
    {
        yield return new WaitForSpineAnimationComplete(currentAnimation);
        onEndAnimation?.Invoke();
    }

    private void ChangeAnimation(AnimationType type)
    {
        currentState = type;
        if (previousState != currentState)
            switch (type)
            {
                case AnimationType.Idle:
                    currentAnimation = skeletonAnimation.state.SetAnimation(0, "Idle", true);
                    break;
                case AnimationType.Attack1:
                    currentAnimation = skeletonAnimation.state.SetAnimation(0, "DoubleShift", false);
                    break;
                case AnimationType.Attack2:
                    currentAnimation = skeletonAnimation.state.SetAnimation(0, "Miner_1", false);
                    break;
                case AnimationType.Attack3:
                    currentAnimation = skeletonAnimation.state.SetAnimation(0, "PickaxeCharge", false);
                    break;
                case AnimationType.Death:
                    currentAnimation = skeletonAnimation.state.SetAnimation(0, "Pull", false);
                    break;
                case AnimationType.TakeDamage:
                    currentAnimation = skeletonAnimation.state.SetAnimation(0, "Damage", false);
                    break;
            }
        StartCoroutine(IBackToIdle());
        previousState = currentState;
    }

    private IEnumerator IBackToIdle()
    {
        yield return new WaitForSpineAnimationComplete(currentAnimation);
        ChangeAnimation(AnimationType.Idle);
    }

    public void SetBacklight(bool value)
    {
        animator.SetBool("Backlight", value);
    }
}
public enum AnimationType
{
    Idle,
    TakeDamage,
    Attack1,
    Attack2,
    Attack3,
    Death
}