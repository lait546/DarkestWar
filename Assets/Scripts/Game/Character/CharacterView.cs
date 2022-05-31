using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private SpriteRenderer backlightImage;
    [SerializeField] private Color colorIsPlaying, colorCanAttack;

    public void Init()
    {
        character.OnChangeHealth += ChangeHealth;
    }

    public void ChangeHealth(int newValue)
    {
        healthBar.ChangeHPScale(newValue, character.stats.MAX_HEALTH);
    }

    public void SetCanPlay(bool value)
    {
        backlightImage.color = colorIsPlaying;
        character.Animation.SetBacklight(value);
    }

    public void SetCanBeAttacked(bool value)
    {
        character.CanAttacked = value;
        backlightImage.color = colorCanAttack;
        character.Animation.SetBacklight(value);
    }
}
