using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<Item> ItemList = new List<Item>();

    public GameObject Player;
    public GameObject InventoryPanel;
    public static InventoryController instance;
    private int active = 0;
    public Item ActiveItem; 

    void updateSlots()
    {

        int index = 0;
        foreach (Transform child in InventoryPanel.transform)
        {
            SlotController slot = child.GetComponent<SlotController>();
            if (index < ItemList.Count)
            {
                slot.item = ItemList[index];
            }
            else
            {
                slot.item = null;
            }
            if(index == active){
                slot.setActive();
                ActiveItem = slot.item;
            }
            else{
                slot.setInactive();
            }

            slot.updateinfo();
            index++;
        }
    }

    public void Add(Item item)
    {
        if (ItemList.Count < 6)
        {
            ItemList.Add(item);
        }
        updateSlots();
    }


    public void Remove(Item item)
    {
        ItemList.Remove(item);
        updateSlots();
    }

    void Start()
    {
        instance = this;
        updateSlots();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameObject inventoryPanel = InventoryController.instance.InventoryPanel;
            if (!inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(true);
                InventoryController.instance.Player.GetComponentInChildren<cameraLook>().enabled = false;
            }
            else
            {
                inventoryPanel.SetActive(false);
                InventoryController.instance.Player.GetComponentInChildren<cameraLook>().enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            active = 0;
            updateSlots();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            active = 1;
            updateSlots();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            active = 2;
            updateSlots();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            active = 3;
            updateSlots();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            active = 4;
            updateSlots();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            active = 5;
            updateSlots();
        }
    }
}
