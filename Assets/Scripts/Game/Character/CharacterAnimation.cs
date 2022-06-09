using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterAnimation : MonoBehaviour
{
    public Character character;
    public SkeletonAnimation skeletonAnimation;
    [SerializeField] private Animator animator;
    private AnimationType currentState, previousState;
    private Spine.TrackEntry currentAnimation;
    private Coroutine lastCoroutine;

    //public Action OnAttackHit;

    //public void OnEnable()
    //{
    //    skeletonAnimation.state.Event += OnEvent;
    //}

    //public void OnDisable()
    //{
    //    skeletonAnimation.state.Event -= OnEvent;
    //}

    public void StartAnimation(AnimationType type)
    {
        ChangeAnimation(type);
    }

    public void StartAnimationWithComplete(AnimationType type, Action onEndAnimation)
    {
        ChangeAnimation(type);

        if (lastCoroutine != null)
            StopCoroutine(lastCoroutine);

        lastCoroutine = StartCoroutine(IChangeAnimation(onEndAnimation));
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
                case AnimationType.Attack:
                    int rnd = UnityEngine.Random.Range(0, 3);

                    if(rnd == 0)
                        currentAnimation = skeletonAnimation.state.SetAnimation(0, "DoubleShift", false);
                    else if (rnd == 1)
                        currentAnimation = skeletonAnimation.state.SetAnimation(0, "Miner_1", false);
                    else if (rnd == 2)
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

    public void Attack(Action callback)
    {
        StartCoroutine(IAttackRecoil(callback));
    }

    private IEnumerator IAttackRecoil(Action callback)
    {
        StartAnimation(AnimationType.Attack);
        yield return new WaitForSpineEvent(skeletonAnimation.state, "Hit");
        callback?.Invoke();
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
    Attack,
    Death
}