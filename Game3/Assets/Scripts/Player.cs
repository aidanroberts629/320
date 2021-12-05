using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    int HP;

    bool invulnerable;
    float invulnerableCountDown;

    [SerializeField]
    GameObject invulnerableUI;

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
            invulnerable = true;
            invulnerableCountDown = Time.time + 0.3f;
            if (HP <= 0)
            {
                gameObject.SetActive(false);

                //end game condition reach, end game logic here, load gameover scene
                //SceneManager.LoadScene(2);
            }
        }
        return 0;
    }

    public void Invulnerable()
    {
        invulnerable = true;
        invulnerableCountDown = Time.time + 5.0f;
    }

    public void Heal()
    {
        if (HP < 3) HP++;
    }
}
