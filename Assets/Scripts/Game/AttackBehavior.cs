using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    [SerializeField] private Transform PointForFight1, PointForFight2;
    [SerializeField] private float WaitAttackTime = 4f;
    private Character character1, character2;
    Vector3 oldPosCharacter1, oldPosCharacter2;

    public void StartAttack(Character _character1, Character _character2)
    {
        character1 = _character1;
        character2 = _character2;

        oldPosCharacter1 = _character1.transform.position;
        oldPosCharacter2 = _character2.transform.position;

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
        StartCoroutine(IWaitAttack());
    }

    public IEnumerator IWaitAttack()
    {
        yield return new WaitForSeconds(WaitAttackTime);
        EndAttack();
        FightBehavior.instance.ChangeTurn();
    }

    public void EndAttack()
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
