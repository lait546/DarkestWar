using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DamagePopup : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private Animator anim;

    public static DamagePopup Create(Vector3 position, int damage)
    {
        DamagePopup damagePopup = Instantiate(GameAssets.i.DamagePopup, position, Quaternion.identity);

        damagePopup.Setup(damage);

        return damagePopup;
    }
    
    public void Setup(int damage)
    {
        text.text = damage.ToString();
        Destroy(this, anim.GetCurrentAnimatorClipInfo(0).Length);
    }


}
