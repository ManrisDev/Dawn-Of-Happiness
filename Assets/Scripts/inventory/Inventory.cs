using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private DataBase dataBase;
    private new Camera camera;

    
    [SerializeField] private List<ItemInventory> items = new List<ItemInventory>();

    [SerializeField] private ItemInventory currentItem;

    [Header("UnityObjects")]
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject inventoryMainObject;
    [SerializeField] private GameObject background;

    [SerializeField] private EventSystem eventSystem;

    [SerializeField] private RectTransform movingObject;

    [Header("Settings")]
    [SerializeField] private int currentId;
    [SerializeField] private int maxItemsCount;
    [SerializeField] private int stackCount;

    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        dataBase = GetComponent<DataBase>();
        camera = GetComponent<Camera>();
    }

    private void Start()
    {
        if (items.Count == 0)
            AddGraphics();

        for (int i = 0; i < maxItemsCount; i++) //Test inventory
        {
            AddItem(i, dataBase.items[Random.Range(0, dataBase.items.Count)], Random.Range(1, 99));
        }
    }

    private void Update()
    {
        if (currentId != -1)
            MoveObject();

        if (Input.GetKeyDown(KeyCode.I))
        {
            background.SetActive(!background.activeSelf);
            if (background.activeSelf)
            {
                UpdateInventory();
            }
        }
    }

    public void SearchForSameItem(Item item, int count)
    {
        for (int i = 0; i < maxItemsCount; i++)
        {
            if (items[i].id == item.id)
            {
                items[i].count += count;
                if (items[i].count > stackCount)
                {
                    count = items[i].count - stackCount;
                    items[i].count = stackCount / 2;
                }
                else
                {
                    count = 0;
                    i = maxItemsCount;
                }
            }
        }

        if (count > 0)
        {
            for (int i = 0; i < maxItemsCount; i++)
            {
                if (items[i].id == 0)
                {
                    AddItem(i, item, count);
                    i = maxItemsCount;
                }
            }
        }
    }

    public void AddItem(int id, Item item, int count)
    {
        items[id].id = item.id;
        items[id].count = count;
        items[id].itemGameObject.GetComponent<Image>().sprite = item.image;

        if (count > 1 && item.id != 0)
        {
            items[id].itemGameObject.GetComponentInChildren<TextMeshProUGUI>().text = count.ToString();
        }
        else
        {
            items[id].itemGameObject.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }

    public void AddInventoryItem(int id, ItemInventory inventoryItem)
    {
        items[id].id = inventoryItem.id;
        items[id].count = inventoryItem.count;
        items[id].itemGameObject.GetComponent<Image>().sprite = dataBase.items[inventoryItem.id].image;

        if (inventoryItem.count > 1 && inventoryItem.id != 0)
        {
            items[id].itemGameObject.GetComponentInChildren<TextMeshProUGUI>().text = inventoryItem.count.ToString();
        }
        else
        {
            items[id].itemGameObject.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }

    public void AddGraphics()
    {
        for (int i = 0; i < maxItemsCount; i++)
        {
            GameObject newItem = Instantiate(itemPrefab, inventoryMainObject.transform) as GameObject;

            newItem.name = i.ToString();

            ItemInventory itemInventory = new ItemInventory();
            itemInventory.itemGameObject = newItem;

            RectTransform rectTransform = newItem.GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
            rectTransform.localScale = Vector3.one;
            newItem.GetComponentInChildren<RectTransform>().localScale = Vector3.one;

            Button tempButton = newItem.GetComponent<Button>();

            tempButton.onClick.AddListener(delegate { SelectObject(); });

            items.Add(itemInventory);
        }
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < maxItemsCount; i ++)
        {
            if (items[i].id != 0 && items[i].count > 1)
                items[i].itemGameObject.GetComponentInChildren<TextMeshProUGUI>().text = items[i].count.ToString();
            else
                items[i].itemGameObject.GetComponentInChildren<TextMeshProUGUI>().text = "";

            items[i].itemGameObject.GetComponent<Image>().sprite = dataBase.items[items[i].id].image;
        }
    }

    public void SelectObject()
    {
        if (currentId == -1)
        {
            currentId = int.Parse(eventSystem.currentSelectedGameObject.name);
            currentItem = CopyInventoryItem(items[currentId]);
            movingObject.gameObject.SetActive(true);
            movingObject.GetComponent<Image>().sprite = dataBase.items[currentItem.id].image;

            AddItem(currentId, dataBase.items[0], 0);
        }
        else
        {
            ItemInventory itemInventory = items[int.Parse(eventSystem.currentSelectedGameObject.name)];

            if (currentItem.id != itemInventory.id)
            {
                AddInventoryItem(currentId, itemInventory);

                AddInventoryItem(int.Parse(eventSystem.currentSelectedGameObject.name), currentItem);
            }
            else
            {
                int sum = itemInventory.count + currentItem.count;
                if (sum <= stackCount)
                {
                    itemInventory.count += currentItem.count;
                }
                else
                {
                    AddItem(currentId, dataBase.items[itemInventory.id], sum - stackCount);

                    itemInventory.count = stackCount;
                }

                itemInventory.itemGameObject.GetComponentInChildren<TextMeshProUGUI>().text = itemInventory.count.ToString();
            }


            currentId = -1;

            movingObject.gameObject.SetActive(false);
        }
    }

    public void MoveObject()
    {
        Vector3 position = Input.mousePosition + offset;
        position.z = inventoryMainObject.GetComponent<RectTransform>().position.z;
        movingObject.position = camera.ScreenToWorldPoint(position);
    }

    public ItemInventory CopyInventoryItem(ItemInventory oldObject)
    {
        ItemInventory newObject = new()
        {
            id = oldObject.id, 
            count = oldObject.count, 
            itemGameObject = oldObject.itemGameObject
        };

        return newObject;
    }
}

[System.Serializable]
public class ItemInventory
{
    public int id;
    public GameObject itemGameObject;

    public int count;
}
