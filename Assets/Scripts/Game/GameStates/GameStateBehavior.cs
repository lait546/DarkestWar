using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateBehavior : MonoBehaviour, IStateSwitcher
{
    public static GameStateBehavior Instance;
    private GameStates currentState;
    private List<GameStates> allStates;

    public void Init()
    {
        Instance = this;
        allStates = new List<GameStates>()
        {
            new BaseGameState(this),
            new AttackCharactersState(this),
            new EndGameState(this),
            new ChoiceAttackedEnemyState(this)
        };
        currentState = allStates[0];
    }

    public void SwitchState<T>() where T : GameStates
    {
        var state = allStates.FirstOrDefault(s => s is T);
        currentState.Stop();
        state.Start();
        currentState = state;
    }
}
