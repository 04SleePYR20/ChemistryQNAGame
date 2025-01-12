using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopOutPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject[] objectsToDestroy;

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

    public void yoloChoice()
    {
        int rng = Random.Range(0, 2);

        if (rng == 0)
        {
            RightAnswer();
            Debug.Log("Lucky");
        }
        else
        {
            RestartLevel();
            Debug.Log("Unlucky");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }


}
