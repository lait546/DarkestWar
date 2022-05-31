using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanel : MonoBehaviour
{
    public static ActionPanel instance;
    [SerializeField] private Button AttackBtn, SkipBtn;

    public void Init()
    {
        instance = this;
    }

    public void SetEnableAllButtons(bool value)
    {
        AttackBtn.interactable = value;
        SkipBtn.interactable = value;
    }

    public void SetEnableActionButtons(bool value)
    {
        AttackBtn.interactable = value;
        SkipBtn.interactable = true;
    }
}
