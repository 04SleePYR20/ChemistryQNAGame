using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopOutPanel : MonoBehaviour
{
    public GameObject panel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            panel.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }


    public void ResumeGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    public void RightAnswer()
    {
        ResumeGame();
    }
}
