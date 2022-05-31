using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceAttackedEnemyState : GameStates
{
    //private Coroutine lastCoroutine;
    public ChoiceAttackedEnemyState(IStateSwitcher stateSwitcher) : base(stateSwitcher)
    {

    }

    public override void Start()
    {
        FightBehavior.instance.SetPreparationToAttack(true);
        ActionPanel.instance.SetEnableActionButtons(false);

        //GameMenu.instance.canOpenMenu = false;
        //StartCoroutine();
    }

    public override void Stop()
    {
        FightBehavior.instance.SetPreparationToAttack(false);
        //GameMenu.instance.canOpenMenu = true;

    }
}
