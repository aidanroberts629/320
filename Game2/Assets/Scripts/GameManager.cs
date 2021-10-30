using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> materialOnMap;

    public void RefreshMaterial()
    {
        foreach (var n in materialOnMap)
        {
            n.SetActive(true);
        }
    }
}
