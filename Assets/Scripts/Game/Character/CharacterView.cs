using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Character character;
    public CharacterAnimation Animation;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private SpriteRenderer backlightImage;
    [SerializeField] private Color colorIsPlaying, colorCanAttack;
    [SerializeField] private MeshRenderer meshRenderer;

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
        Animation.SetBacklight(value);
    }

    public void SetCanBeAttacked(bool value)
    {
        character.CanAttacked = value;
        backlightImage.color = colorCanAttack;
        Animation.SetBacklight(value);
    }

    public void SetAttackState(bool value)
    {
        if(value)
            meshRenderer.sortingOrder = 4;
        else
            meshRenderer.sortingOrder = 0;
    }
}
