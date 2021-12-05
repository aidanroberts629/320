using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    int HP;

    public bool invulnerable;
    public float invulnerableCountDown;

    void Update()
    {
        if (invulnerable && Time.time > invulnerableCountDown)
        {
            invulnerable = false;
        }
    }

    public int ReciveDamage(int damage)
    {
        if (!invulnerable)
        {
            HP -= damage;
            if (HP <= 0)
            {
                gameObject.SetActive(false);

                //end game condition reach, end game logic here, load gameover scene
                //SceneManager.LoadScene(2);
            }
        }
        return 0;
    }
}
