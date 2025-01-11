using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopOutPanel : MonoBehaviour
{
    public GameObject panel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            panel.SetActive(true);
        }
    }
}
