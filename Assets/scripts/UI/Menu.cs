using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject panel;
    public Button ConGame;
    public Button ExitLVL;
    void Start()
    {
        ConGame.onClick.AddListener(conGame);
        ExitLVL.onClick.AddListener(exitLVL);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }

    }
    private void conGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        Time.timeScale = 1;
        panel.SetActive(false);
    }
    private void exitLVL()
    {
        SceneManager.LoadScene(0);
    }
    
   
}
