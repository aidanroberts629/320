using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // fields
    [SerializeField]
    public List<string> items;

    GameManager gameManager;
    public AudioSource source;
    public AudioClip pickupSound;

    // methods
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        source = gameObject.AddComponent<AudioSource>();
    }

    public void AddItem(string itemName)
    {
        if (items.Count < 3)
        {
            items.Add(itemName);
            source.PlayOneShot(pickupSound);
        }
    }

    public void ClearInventory()
    {
        items.Clear();
        gameManager.GetComponent<GameManager>().RefreshMaterial();
    }


}
