using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    void OnEnable()
    {
        GameObject inventoryPanel = InventoryController.instance.InventoryPanel;
        Time.timeScale = 0;
        InventoryController.instance.Player.GetComponentInChildren<cameraLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnDisable()
    {
        GameObject inventoryPanel = InventoryController.instance.InventoryPanel;
        Time.timeScale = 1;
        InventoryController.instance.Player.GetComponentInChildren<cameraLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

}
