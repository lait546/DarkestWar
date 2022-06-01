using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacteristicsPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NameCharacter, HP, Damage;
    [SerializeField] private HealthBar characterHealthBar;

    public void Init()
    {
        GameArea.instance.fightBehavior.OnChangeTurnCharacter += ChangeCharacteristics;
    }

    public void ChangeCharacteristics(Character character)
    {
        Debug.Log("ChangeCharacteristics");
        NameCharacter.text = character.gameObject.name;
        HP.text = "Health: " + character.stats.Health.ToString() + "/" + character.stats.MAX_HEALTH.ToString();
        Damage.text = "Damage: " + character.stats.Damage.ToString();
        characterHealthBar.ChangeHPScale(character.stats.Health, character.stats.MAX_HEALTH);
    }

    public void OnDisable()
    {
        GameArea.instance.fightBehavior.OnChangeTurnCharacter -= ChangeCharacteristics;
    }
}
