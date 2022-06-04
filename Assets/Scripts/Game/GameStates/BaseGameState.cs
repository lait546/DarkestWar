using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGameState : GameStates
{
    public BaseGameState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
    {

    }

    public override void Start()
    {
        ActionPanel.instance.SetEnableActionButtons(true);
    }

    public override void Stop()
    {
        
    }
}
