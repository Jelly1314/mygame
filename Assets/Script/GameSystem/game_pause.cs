using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_pause : MonoBehaviour
{
    public GameObject player; // Assign your player GameObject in the Inspector
    private Vector3 playerPosition;

    void Update()
    {
        // Check for pause input (e.g., Escape key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        // Store the player's current position
        playerPosition = player.transform.position;

        // Save player's position in PlayerPrefs
        PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerPosition.z);

        // Disable player movement and camera control
        if (player.GetComponent<FPSController>() != null)
            player.GetComponent<FPSController>().enabled = false;
        // Load the PauseGame scene
        SceneManager.LoadScene("PauseMenu");
        UnlockCursor();
    }
    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }
}

