using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger enter");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next level in build index
    }
}
