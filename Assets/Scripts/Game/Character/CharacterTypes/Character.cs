using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterAnimation))]
[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterView))]
public abstract class Character : MonoBehaviour, IPointerClickHandler
{
    public CharacterStats stats;
    public CharacterMovement Movement;
    public CharacterAnimation Animation;
    public CharacterView View;
    public bool CanAttacked = false;

    public event Action<Character> OnDeath;
    public event Action<int> OnChangeHealth;

    public int NumberPlayer { get; private set; }

    public void Init(int numberPlayer)
    {
        NumberPlayer = numberPlayer;
        View.Init();
    }

    public virtual void Attack(Character toAttack)
    {
        Animation.StartAnimation(AnimationType.Attack1);
    }

    public virtual void TakeDamage(int value)
    {
        stats.Health -= value;
        OnChangeHealth?.Invoke(stats.Health);

        Animation.StartAnimation(AnimationType.TakeDamage);
        
        if (stats.Health <= 0)
            Death();
    }

    protected void Death()
    {
        OnDeath?.Invoke(this);
        Animation.StartAnimationWithComplete(AnimationType.Death, () => Destroy(gameObject, 1f));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (CanAttacked)
            FightBehavior.instance.StartAttack(this);
    }

    private void OnDisable()
    {
        OnDeath = null;
        OnChangeHealth = null;
    }
}