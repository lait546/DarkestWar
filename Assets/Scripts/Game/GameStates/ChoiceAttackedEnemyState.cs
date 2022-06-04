using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceAttackedEnemyState : GameStates
{
    public ChoiceAttackedEnemyState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
    {

    }

    public override void Start()
    {
        FightBehavior.instance.SetPreparationToAttack(true);
        ActionPanel.instance.SetEnableActionButtons(false);
    }

    public override void Stop()
    {
        FightBehavior.instance.SetPreparationToAttack(false);
    }
}
