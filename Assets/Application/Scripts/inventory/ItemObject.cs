using System.Collections;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [Header("Item Settings")]
    [SerializeField] private int itemId = -1;
    [SerializeField] private int count = 1;

    [Header("Disappearance Settings")]
    [SerializeField, Range(0f, 1f)] private float disappearanceRate = 0.005f;

    private DataBase dataBase;
    private Inventory inventory;

    private new Transform transform;
    private SpriteRenderer spriteRenderer;

    private string itemSpriteName;
    private float itemPositionY;

    private bool available = false;

    private void Awake()
    {
        dataBase = FindObjectOfType<DataBase>();
        inventory = FindObjectOfType<Inventory>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
    }

    private void Start()
    {
        itemSpriteName = spriteRenderer.name;

        if (itemId == -1)
        {
            itemId = dataBase.GetIdByName(itemSpriteName);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && available)
        {
            PickUpItem();
        }
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
            available = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            available = false;
    }

    public void PickUpItem()
    {
        inventory.AddItem(itemId, dataBase.items[itemId], count);
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        itemPositionY = transform.position.y;
        for (float rate = itemPositionY; rate <= itemPositionY + 0.2f; rate += disappearanceRate)
        {
            transform.position = new Vector2(transform.position.x, rate);
            yield return 0.005f;
        }
        Destroy(gameObject);
    }
}
