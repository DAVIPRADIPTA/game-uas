using UnityEngine;

public class SentuhanMonster : MonoBehaviour
{
    public GameOverManager scriptManager; // Tarik objek ManajerGameOver ke sini

    private void OnTriggerEnter(Collider other)
    {
        // Jika yang menyentuh monster adalah objek dengan Tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pemain Tertangkap!");
            if (scriptManager != null)
            {
                scriptManager.MunculkanGameOver();
            }
        }
    }
}