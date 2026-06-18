using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class KameraFoto : MonoBehaviour
{
    [Header("Pengaturan Kamera")]
    public Camera kameraPemain; 
    public float jarakMaksimalFoto = 15f; 

    [Header("Efek Jepretan")]
    public AudioSource suaraJepret; 
    public GameObject uiFlashPutih; 

    [Header("Data Misi Foto (BARU)")]
    public int jumlahFotoDidapat = 0; // Menyimpan jumlah patung yang sudah difoto

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            AmbilFoto();
        }
    }

    void AmbilFoto()
    {
        StartCoroutine(MainkanEfekFlash());

        RaycastHit informasiTabrakan;
        if (Physics.Raycast(kameraPemain.transform.position, kameraPemain.transform.forward, out informasiTabrakan, jarakMaksimalFoto))
        {
            if (informasiTabrakan.transform.CompareTag("TargetFoto"))
            {
                // 1. Tambah angka penghitung foto
                jumlahFotoDidapat++;
                Debug.Log("Jepret! Sukses memotret patung. Total foto saat ini: " + jumlahFotoDidapat);

                // 2. ANTI-CURANG: Ubah tag patung ini agar tidak bisa difoto lagi
                informasiTabrakan.transform.tag = "Untagged";
            }
            else
            {
                Debug.Log("Jepret! Tapi cuma memotret dinding/benda biasa.");
            }
        }
    }

    IEnumerator MainkanEfekFlash()
    {
        if(suaraJepret != null) suaraJepret.Play();
        
        if(uiFlashPutih != null)
        {
            uiFlashPutih.SetActive(true); 
            yield return new WaitForSeconds(0.1f); 
            uiFlashPutih.SetActive(false); 
        }
    }
}