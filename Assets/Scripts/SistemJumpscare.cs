using UnityEngine;

public class SistemJumpscare : MonoBehaviour
{
    [Header("UI & Audio")]
    public GameObject uiJumpscare;
    public AudioSource suaraJumpscare; // Tambahan untuk efek suara

    private void OnTriggerEnter(Collider objekYangDisentuh)
    {
        if (objekYangDisentuh.CompareTag("Player"))
        {
            // 1. Munculkan gambar
            uiJumpscare.SetActive(true);
            
            // 2. Putar suara teriakan (jika ada)
            if(suaraJumpscare != null)
            {
                suaraJumpscare.Play();
            }
            
            // 3. Hentikan waktu
            Time.timeScale = 0f;
        }
    }
}