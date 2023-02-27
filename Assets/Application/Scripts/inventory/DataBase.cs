using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public int GetIdByName(string name)
    {
        foreach (Item item in items)
            if (item.name == name) 
                return item.id;
        return -1;
    }
}

[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public Sprite image;
}
