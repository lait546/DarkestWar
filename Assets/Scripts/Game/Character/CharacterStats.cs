using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CharacterStats
{
    [SerializeField] private int max_health, health, damage;

    public int MAX_HEALTH { get => max_health; private set => max_health = value; }
    public int Health { get => health; set => health = Mathf.Clamp(value, 0, MAX_HEALTH); }

    public int Damage { get => damage; private set => damage = value; }
}
