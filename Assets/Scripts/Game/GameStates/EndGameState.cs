using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : GameStates
{
    public EndGameState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
    {

    }

    public override void Start()
    {
        GameArea.instance.endGameWindow.EndGame();
    }

    public override void Stop()
    {

    }
}
