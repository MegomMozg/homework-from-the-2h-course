using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCursor : MonoBehaviour
{
    private void Cursormenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
    public void startLVL()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
