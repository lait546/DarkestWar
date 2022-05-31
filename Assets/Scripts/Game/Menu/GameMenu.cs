using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public static GameMenu instance;
    [SerializeField] private GameObject GameMenuWindow;
    public bool canOpenMenu = true;

    public void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canOpenMenu)
        {
            SetActiveGameMenu(true);
        }
    }

    public void SetActiveGameMenu(bool value)
    {
        if (value)
        {
            GameMenuWindow.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            GameMenuWindow.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
