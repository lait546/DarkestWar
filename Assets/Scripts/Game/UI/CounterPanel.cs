using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counter;

    public void Init()
    {
        GameArea.instance.fightBehavior.OnChangeRound += ChangeCounter;
    }
    
    public void ChangeCounter(int number)
    {
        counter.text = number.ToString();
    }
}
