using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GameArea : MonoBehaviour
{
    public static GameArea instance;
    public FightBehavior fightBehavior;
    public CharacterFactory characterFactory;
    public GameStateBehavior gameStateBehavior;
    public AttackBehavior attackBehavior;
    public ActionPanel actionButtonsPanel;
    public CharacteristicsPanel characteristicsPanel;
    public EndGameWindow endGameWindow;
    public CounterPanel counterPanel;
    public Animator GameAreaAnimator;
    public Transform CharacterContainer;

    [SerializeField] private Player player1, player2;
    public GameObject[] spawnPoints;
    public float SpaceBetweenSpawnCharacter = 1f;

    public void Awake()
    {
        instance = this;
        GameAreaAnimator = GetComponent<Animator>();
        Init();
    }

    public void Init()
    {
        player1.Init();
        player2.Init();

        actionButtonsPanel.Init();
        characteristicsPanel.Init();
        gameStateBehavior.Init();
        fightBehavior.Init(player1, player2);
        counterPanel.Init();
    }

    public void SetCameraBringToCharacters(bool value)
    {
        GameAreaAnimator.SetBool("Bring", value);
    }
}
