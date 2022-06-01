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
    private int Turn = 0, Round = 0,  characterCounter = 0;
    private List<Character> characters = new List<Character>();
    private Character CurrentCharacter;

    public event Action<Character> OnChangeTurnCharacter;
    public event Action<int> OnChangeRound;

    public void Init(Player _player1, Player _player2)
    {
        instance = this;

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

    public void ChangeTurn()
    {
        if(CurrentCharacter)
            CurrentCharacter.View.SetCanPlay(false);

        GameStateBehavior.Instance.SwitchState<BaseGameState>();

        Turn++;

        if (Turn != 0)
            characterCounter++;

        if (characterCounter >= characters.Count)
        {
            characterCounter = 0;

            characters.Shuffle();

            ChangeRound();
        }

        if(player1.characters.Count == 0 || player2.characters.Count == 0)
            GameStateBehavior.Instance.SwitchState<EndGameState>();

        ChangeCharacterTurn(characters[characterCounter]);
    }

    public void ChangeCharacterTurn(Character character)
    {
        CurrentCharacter = character;
        CurrentCharacter.View.SetCanPlay(true);
        OnChangeTurnCharacter?.Invoke(character);
    }

    public void ChangeRound()
    {
        Round++;
        OnChangeRound?.Invoke(Round);
    }

    public void ChoiceAttackedEnemy(bool value)
    {
        GameStateBehavior.Instance.SwitchState<ChoiceAttackedEnemyState>();
    }

    public void SetPreparationToAttack(bool value)
    {
        if (CurrentCharacter.NumberPlayer == player1.numberPlayer)
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
        CurrentCharacter.View.SetCanPlay(false);
        GameArea.instance.attackBehavior.StartAttack(CurrentCharacter, _characterAttacked);
        yield return new WaitForSeconds(1.5f);
        CurrentCharacter.Attack(_characterAttacked);
        _characterAttacked.TakeDamage(CurrentCharacter.stats.Damage);
    }

    public void RemoveCharacterList(Character _character)
    {
        if (characters.Exists(x => x == _character))
            characters.Remove(_character);
    }
}