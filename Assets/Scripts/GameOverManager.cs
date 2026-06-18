using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject panelGameOver;

    void Start()
    {
        // Pastikan panel mati saat baru mulai
        if (panelGameOver != null) panelGameOver.SetActive(false);
    }

    public void MunculkanGameOver()
    {
        // 1. Hentikan waktu & Munculkan Mouse
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 2. Nyalakan Panel
        if (panelGameOver != null) panelGameOver.SetActive(true);
    }

    public void TombolRestart()
    {
        Time.timeScale = 1f; // Jalankan waktu lagi
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Load ulang level ini
    }

    public void TombolKeMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Kembali ke menu utama
    }
}