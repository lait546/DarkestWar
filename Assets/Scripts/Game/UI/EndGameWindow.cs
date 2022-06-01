using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameWindow : MonoBehaviour
{
    [SerializeField] private GameObject Window;

    public void EndGame()
    {
        Time.timeScale = 0f;
        Window.SetActive(true);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
