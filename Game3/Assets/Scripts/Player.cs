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

    [SerializeField]
    List<GameObject> HPUI;

    void Update()
    {
        if (invulnerable && Time.time > invulnerableCountDown)
        {
            invulnerable = false;
            invulnerableUI.SetActive(false);
        }
    }

    public int ReciveDamage(int damage)
    {
        if (!invulnerable)
        {
            HP -= damage;
            if (HP == 2)
            {
                HPUI[2].SetActive(false);
            }
            else if (HP == 1)
            {
                HPUI[1].SetActive(false);
            }
            else if (HP == 0)
            {
                HPUI[0].SetActive(false);
            }
            invulnerable = true;
            invulnerableCountDown = Time.time + 0.5f;
            if (HP <= 0)
            {
                gameObject.SetActive(false);

                //end game condition reach, end game logic here, load gameover scene
                SceneManager.LoadScene(4); //loads scene at index 4 (should be game over scene)
            }
        }
        return 0;
    }

    public void Invulnerable()
    {
        invulnerable = true;
        invulnerableCountDown = Time.time + 5.0f;
        invulnerableUI.SetActive(true);
    }

    public void Heal()
    {
        if (HP < 3) HP++;

        if (HP == 3)
        {
            HPUI[2].SetActive(true);
        }
        else if (HP == 2)
        {
            HPUI[1].SetActive(true);
        }
    }
}
