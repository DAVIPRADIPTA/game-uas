using UnityEngine;
using UnityEngine.InputSystem;

public class KunciKursor : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // CEGAHAN BARU: Kursor hanya mau dikunci kalau game TIDAK di-pause (waktu berjalan)
        if (Time.timeScale > 0f) 
        {
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}