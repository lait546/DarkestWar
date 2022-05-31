using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacteristicsPanel : MonoBehaviour
{
    public static CharacteristicsPanel instance;
    [SerializeField] private TextMeshProUGUI NameCharacter, HP, Damage;
    [SerializeField] private HealthBar characterHealthBar;

    public void Init()
    {
        instance = this;
    }

    public void ChangeCharacteristics(string name, int hp, int maxHp, int damage)
    {
        NameCharacter.text = name;
        HP.text = "Health: " + hp.ToString() + "/" + maxHp.ToString();
        Damage.text = "Damage: " + damage.ToString();
        characterHealthBar.ChangeHPScale(hp, maxHp);
    }
}
