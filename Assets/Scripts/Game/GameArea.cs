using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GameArea : MonoBehaviour
{
    public static GameArea instance;
    [SerializeField] private FightBehavior fightBehavior;
    public CharacterFactory characterFactory; //проверить должна ли быть паблик
    public GameStateBehavior gameStateBehavior;
    public AttackBehavior attackBehavior;
    public ActionPanel actionButtonsPanel;
    public CharacteristicsPanel characteristicsPanel;
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
        attackBehavior.Init();
    }

    public void SetBringToCharacters(bool value)
    {
        GameAreaAnimator.SetBool("Bring", value);
    }
}
