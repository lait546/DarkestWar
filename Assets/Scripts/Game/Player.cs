using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterType[] SelectedCharacters;
    public List<Character> characters = new List<Character>();
    public bool canPlay = false;
    public int numberPlayer; // сделать свойством

    public void Init()
    {
        SpawnCharacters();
    }

    public virtual void SpawnCharacters()
    {
        for (int i = 0; i < SelectedCharacters.Length; i++)
        {
            Character character = GameArea.instance.characterFactory.Get(SelectedCharacters[i], GameArea.instance.spawnPoints[0].transform.position - new Vector3((GameArea.instance.SpaceBetweenSpawnCharacter * i), 0, 0), numberPlayer);
            AddCharacter(character);
        }
    }

    public void AddCharacter(Character _character)
    {
        characters.Add(_character);
        _character.OnDeath += RemoveCharacter;
    }

    public void RemoveCharacter(Character _character)
    {
        if (characters.Exists(x => x == _character))
            characters.Remove(_character);

        _character.OnDeath -= RemoveCharacter;
    }
}
