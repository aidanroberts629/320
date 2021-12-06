using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "Player")
            SceneManager.LoadScene(4); //loads scene at index 4 (should be game over scene)
    }
}
