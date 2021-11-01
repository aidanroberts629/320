using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // fields
    [SerializeField]
    List<GameObject> materialOnMap;

    [SerializeField]
    GameObject[] triggerKey;

    public void RefreshMaterial()
    {
        foreach (var n in materialOnMap)
        {
            n.SetActive(true);
        }
    }

    public void checkActive()
    {
        bool activate = true;
        for (int i = 0; i < triggerKey.Length; i++)
        {
            if (!triggerKey[i].GetComponent<ColorMatchPlate>().isActive)
                activate = false;
        }
        if (activate)
        {
            SceneManager.LoadScene(2);
        }
    }
}
