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
    public CharacterView View;
    public bool CanAttacked = false;
    [HideInInspector] public Character currentTarget;

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
        View.Animation.StartAnimation(AnimationType.Attack);
        View.Animation.Attack(() => toAttack.TakeDamage(stats.Damage));
    }

    public virtual void TakeDamage(int value)
    {
        stats.Health -= value;
        OnChangeHealth?.Invoke(stats.Health);

        View.Animation.StartAnimation(AnimationType.TakeDamage);
        DamagePopup.Create(transform.position + new Vector3(0.5f, 3f, 0f), value);

        if (stats.Health <= 0)
            Death();
    }

    protected void Death()
    {
        OnDeath?.Invoke(this);
        View.Animation.StartAnimationWithComplete(AnimationType.Death, () => Destroy(gameObject, 1f));
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