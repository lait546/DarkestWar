using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCharactersState : GameStates
{
    public AttackCharactersState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
    {

    }

    public override void Start()
    {
        GameArea.instance.SetBringToCharacters(true);
        ActionPanel.instance.SetEnableAllButtons(false);
    }

    public override void Stop()
    {
        GameArea.instance.SetBringToCharacters(false);
    }
}
