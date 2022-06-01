using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Player
{
    public override void SpawnCharacters()
    {
        for (int i = 0; i < SelectedCharacters.Length; i++)
        {
            Character character = GameArea.instance.characterFactory.Get(SelectedCharacters[i], GameArea.instance.spawnPoints[1].transform.position + new Vector3((GameArea.instance.SpaceBetweenSpawnCharacter * i), 0, 0), numberPlayer);
            AddCharacter(character);
            character.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
