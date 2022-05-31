using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    [SerializeField] private Character WarriorBase, WarriorElite;

    public Character Get(CharacterType type, Vector3 pos, int numberPlayer)
    {
        Character character = Instantiate(GetPrefabByType(type), pos, Quaternion.identity, GameArea.instance.CharacterContainer);
        character.Init(numberPlayer);
        return character;
    }

    private Character GetPrefabByType(CharacterType type)
    {
        Character character = WarriorBase;

        switch(type)
        {
            case CharacterType.WarriorBase:
                character = WarriorBase;
                break;
            case CharacterType.WarriorElite:
                character = WarriorElite;
                break;
        }
        return character;
    }
}

public enum CharacterType
{
    WarriorBase,
    WarriorElite
}
