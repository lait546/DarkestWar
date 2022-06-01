using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStates
{
    protected readonly IStateSwitcher stateSwitcher;
    protected GameStates(IStateSwitcher _stateSwitcher)
    {
        stateSwitcher = _stateSwitcher;
    }

    public abstract void Start();

    public abstract void Stop();
}
