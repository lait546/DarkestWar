using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    [SerializeField] private Transform PointForFight1, PointForFight2;
    [SerializeField] private float WaitAttackTime = 4f, cameraBringWaitTime = 1.5f;
    private Character character1, character2;
    Vector3 oldPosCharacter1, oldPosCharacter2;

    public void StartAttack(Character _attacking, Character _attacked)
    {
        character1 = _attacking;
        character2 = _attacked;

        oldPosCharacter1 = _attacking.transform.position;
        oldPosCharacter2 = _attacked.transform.position;

        GameStateBehavior.Instance.SwitchState<AttackCharactersState>();

        character1.View.SetAttackState(true);
        character2.View.SetAttackState(true);

        if (character1.NumberPlayer == 0)
        {
            character1.Movement.Move(PointForFight1.position);
            character2.Movement.Move(PointForFight2.position);
        }
        else
        {
            character1.Movement.Move(PointForFight2.position);
            character2.Movement.Move(PointForFight1.position);
        }
        StartCoroutine(IWaitAttack(_attacking, _attacked));
    }

    private IEnumerator IWaitAttack(Character _attacking, Character _attacked)
    {
        yield return new WaitForSeconds(cameraBringWaitTime);
        _attacking.Attack(_attacked);
        yield return new WaitForSeconds(WaitAttackTime);
        EndAttack();
        FightBehavior.instance.ChangeTurn();
    }

    private void EndAttack()
    {
        if (character1)
        {
            character1.Movement.Move(oldPosCharacter1);
            character1.View.SetAttackState(false);
        }
        if (character2)
        {
            character2.Movement.Move(oldPosCharacter2);
            character2.View.SetAttackState(false);
        }
    }
}
