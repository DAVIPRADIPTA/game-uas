using UnityEngine;

public class PetunjukLevel : MonoBehaviour
{
    [Header("UI Elemen")]
    public GameObject panelPetunjuk; // Tarik panel UI petunjuk ke sini

    void Start()
    {
        // 1. Hentikan waktu dunia game (Pause) agar anomali & pemain membeku
        Time.timeScale = 0f;

        // 2. Munculkan kursor mouse agar pemain bisa mengklik tombol
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 3. Pastikan panel petunjuknya menyala di awal
        if (panelPetunjuk != null)
        {
            panelPetunjuk.SetActive(true);
        }
    }

    // Fungsi ini akan dipanggil saat tombol di UI diklik
    public void TombolMulaiDiklik()
    {
        // 1. Jalankan kembali waktu dunia game (Unpause)
        Time.timeScale = 1f;

        // 2. Sembunyikan kursor mouse agar bisa main dengan mulus
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 3. Matikan panel petunjuknya
        if (panelPetunjuk != null)
        {
            panelPetunjuk.SetActive(false);
        }
    }
}