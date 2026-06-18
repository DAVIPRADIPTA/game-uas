using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AmbilBarang : MonoBehaviour
{
    [Header("Pengaturan Interaksi")]
    public Camera kameraPemain;
    public float jarakAmbil = 3f;

    [Header("Pengaturan Pintu")]
    public string namaSceneTujuan = "Level2"; 
    public int totalFotoDibutuhkan = 2; // Batas jumlah foto (Bisa diatur di Inspector)

    [Header("Hubungkan ke Kamera (BARU)")]
    public KameraFoto scriptKamera; // Tempat mengambil data jumlahFotoDidapat

    [Header("Data Inventaris")]
    public int jumlahKunciDiBawa = 0;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            CobaAmbil();
        }
    }

    void CobaAmbil()
    {
        RaycastHit infoTabrakan;
        if (Physics.Raycast(kameraPemain.transform.position, kameraPemain.transform.forward, out infoTabrakan, jarakAmbil))
        {
            if (infoTabrakan.transform.CompareTag("Kunci"))
            {
                jumlahKunciDiBawa++;
                Debug.Log("Dapat Kunci! Total kuncimu: " + jumlahKunciDiBawa);
                Destroy(infoTabrakan.transform.gameObject);
            }
            else if (infoTabrakan.transform.CompareTag("PintuKeluar"))
            {
                // Ambil data jumlah foto terbaru dari script kamera
                int fotoSekarang = (scriptKamera != null) ? scriptKamera.jumlahFotoDidapat : 0;

                // SYARAT MUTLAK: Harus punya kunci DAN foto harus cukup
                if (jumlahKunciDiBawa > 0 && fotoSekarang >= totalFotoDibutuhkan) 
                {
                    Debug.Log("Pintu Terbuka! Kamu Berhasil Kabur!");
                    SceneManager.LoadScene(namaSceneTujuan); 
                }
                else
                {
                    // Memberikan petunjuk detail di Console tentang apa yang kurang
                    if (jumlahKunciDiBawa <= 0 && fotoSekarang < totalFotoDibutuhkan)
                    {
                        Debug.Log("Pintu terkunci! Kunci belum ada dan foto baru " + fotoSekarang + "/" + totalFotoDibutuhkan);
                    }
                    else if (jumlahKunciDiBawa <= 0)
                    {
                        Debug.Log("Pintu terkunci! Foto sudah cukup, tapi kamu belum mengambil KUNCI!");
                    }
                    else
                    {
                        Debug.Log("Pintu terkunci! Kunci ada, tapi foto belum cukup! Baru " + fotoSekarang + "/" + totalFotoDibutuhkan);
                    }
                }
            }
        }
    }
}