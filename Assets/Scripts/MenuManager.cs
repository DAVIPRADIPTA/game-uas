using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        // Memastikan kursor muncul kembali saat masuk ke menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void MulaiGame()
    {
        // Sesuaikan dengan nama Scene Level 1 kamu
        SceneManager.LoadScene("SampleScene"); 
    }

    public void KeluarGame()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit();
    }
}

