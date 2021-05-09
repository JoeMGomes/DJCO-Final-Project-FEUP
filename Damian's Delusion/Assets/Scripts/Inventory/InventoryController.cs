using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<Item> ItemList = new List<Item>();

    public GameObject Player;
    public GameObject InventoryPanel;
    public static InventoryController instance;
    // Start is called before the first frame update

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
            slot.updateinfo();
            index++;
        }
    }

    void Add(Item item)
    {
        if (ItemList.Count < 6)
        {
            ItemList.Add(item);
        }
        updateSlots();
    }


    void Remove(Item item)
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
        if (Input.GetKeyDown(KeyCode.Tab)){
            GameObject inventoryPanel = InventoryController.instance.InventoryPanel;
            InventoryController.instance.Player.GetComponentInChildren<cameraLook>().enabled = false;
            if (!inventoryPanel.activeSelf){
                inventoryPanel.SetActive(true);
                InventoryController.instance.Player.GetComponentInChildren<cameraLook>().enabled = false;
            }else {
                inventoryPanel.SetActive(false);
                InventoryController.instance.Player.GetComponentInChildren<cameraLook>().enabled = true;
            }
        }
    }
}
