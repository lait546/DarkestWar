using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = System.Random;

public class FightBehavior : MonoBehaviour
{
    public static FightBehavior instance;
    public Player player1, player2;
    private int Turn = 0, Round = 0, numberPlayer = 0, characterCounter = 0;
    private List<Character> characters = new List<Character>();

    public void Init(Player _player1, Player _player2)
    {
        instance = this;

        numberPlayer = UnityEngine.Random.Range(0, 2); //каким по счету будет ходить игрок
        player1 = _player1;
        player2 = _player2;

        for (int i = 0; i < player1.characters.Count; i++)
        {
            characters.Add(player1.characters[i]);
            player1.characters[i].OnDeath += RemoveCharacterList;
        }
        for (int i = 0; i < player2.characters.Count; i++)
        {
            characters.Add(player2.characters[i]);
            player2.characters[i].OnDeath += RemoveCharacterList;
        }

        characters.Shuffle();

        ChangeTurn();
    }

    public void SwitchTurnPlayer()
    {
        player1.canPlay = false;
        player2.canPlay = false;

        if (Turn % 2 == numberPlayer)
            player1.canPlay = true;
        else
            player2.canPlay = true;
    }

    public void ChangeTurn()
    {
        characters[characterCounter].View.SetCanPlay(false);
        GameStateBehavior.Instance.SwitchState<BaseGameState>();

        Turn++;
        SwitchTurnPlayer();

        if (Turn != 0)
            characterCounter++;

        if (characterCounter >= characters.Count)
            characterCounter = 0;

        CharacteristicsPanel.instance.ChangeCharacteristics(characters[characterCounter].gameObject.name, characters[characterCounter].stats.Health, characters[characterCounter].stats.MAX_HEALTH, characters[characterCounter].stats.Damage);

        characters[characterCounter].View.SetCanPlay(true);
    }

    public void ChoiceAttackedEnemy(bool value)
    {
        GameStateBehavior.Instance.SwitchState<ChoiceAttackedEnemyState>();
    }

    public void SetPreparationToAttack(bool value)
    {
        if (characters[characterCounter].NumberPlayer == player1.numberPlayer)
            foreach(var character in player2.characters)
                character.View.SetCanBeAttacked(value);
        else
            foreach (var character in player1.characters)
                character.View.SetCanBeAttacked(value);
    }

    public void StartAttack(Character _characterAttacked)
    {
        StartCoroutine(IStartAttack(_characterAttacked));
    }

    private IEnumerator IStartAttack(Character _characterAttacked)
    {
        characters[characterCounter].View.SetCanPlay(false);
        AttackBehavior.instance.StartAttack(characters[characterCounter], _characterAttacked);
        yield return new WaitForSeconds(1.5f);
        characters[characterCounter].Attack(_characterAttacked);
        _characterAttacked.TakeDamage(characters[characterCounter].stats.Damage);
    }

    public void RemoveCharacterList(Character _character)
    {
        if (characters.Exists(x => x == _character))
            characters.Remove(_character);
    }

    public void EndFight()
    {
        
    }
}