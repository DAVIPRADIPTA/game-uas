using UnityEngine;

public class MenghadapKamera : MonoBehaviour
{
    [Header("Masukkan Kamera Pemain Kesini")]
    public Transform kameraPemain;

    // LateUpdate dipanggil setelah pergerakan selesai, cocok untuk kamera/rotasi
    void LateUpdate()
    {
        if (kameraPemain != null)
        {
            // Teknik Billboard: Menyamakan arah hadap sprite dengan arah hadap kamera
            transform.forward = kameraPemain.forward;
        }
    }
}