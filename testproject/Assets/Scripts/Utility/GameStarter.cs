using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        PlayerInventory.keyCount = 0;
        PlayerInventory.batteryCount = 0;
        Time.timeScale = 1f;
    }
}
