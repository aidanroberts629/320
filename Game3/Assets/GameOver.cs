using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger enter");
        SceneManager.LoadScene(4); //loads scene at index 4 (should be game over scene)
    }
}
