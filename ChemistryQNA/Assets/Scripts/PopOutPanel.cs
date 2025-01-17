using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopOutPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject[] objectsToDestroy;
    public GameObject unluckyPanel;
    public GameObject luckyPanel;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RightAnswer()
    {
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }

        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void WrongAnswer()
    {
        audioManager.PlaySFX(audioManager.wrongAnswer);
    }

    public void yoloChoice()
    {
        int rng = Random.Range(0, 2);

        if (rng == 0)
        {
            luckyPanel.SetActive(true);
            //RightAnswer();
            Time.timeScale = 0f;
            Debug.Log("Lucky");
        }
        else
        {
            unluckyPanel.SetActive(true); 
            Time.timeScale = 0f; 
            Debug.Log("Unlucky");
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }


}