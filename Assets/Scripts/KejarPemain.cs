using UnityEngine;
using UnityEngine.AI;

public class KejarPemain : MonoBehaviour
{
    public Transform targetPemain; 
    private NavMeshAgent agenNavigasi;
    
    // TAMBAHKAN INI: Referensi ke komponen Animator
    private Animator animatorAnomali;

    [Header("Pengaturan AI")]
    public float jarakDeteksi = 10f;
    public float radiusPatroli = 15f;
    public float waktuGantiArah = 4f;

    private float timerPatroli;

    void Start()
    {
        agenNavigasi = GetComponent<NavMeshAgent>();
        
        // TAMBAHKAN INI: Mengambil komponen Animator secara otomatis
        animatorAnomali = GetComponent<Animator>();
        
        timerPatroli = waktuGantiArah;
    }

    void Update()
    {
        if (targetPemain == null) return;

        float jarakKePemain = Vector3.Distance(transform.position, targetPemain.position);

        if (jarakKePemain <= jarakDeteksi)
        {
            agenNavigasi.SetDestination(targetPemain.position);
        }
        else
        {
            PatroliAcak();
        }

        // TAMBAHKAN INI: Mengirim nilai kecepatan NavMesh ke Animator
        // agenNavigasi.velocity.magnitude mengukur kecepatan karakter saat ini (0 jika diam, >0 jika bergerak)
        if (animatorAnomali != null)
        {
            animatorAnomali.SetFloat("Kecepatan", agenNavigasi.velocity.magnitude);
        }
    }

    void PatroliAcak()
    {
        timerPatroli += Time.deltaTime;

        if (timerPatroli >= waktuGantiArah)
        {
            Vector3 arahAcak = Random.insideUnitSphere * radiusPatroli;
            arahAcak += transform.position;

            NavMeshHit infoNavMesh;
            if (NavMesh.SamplePosition(arahAcak, out infoNavMesh, radiusPatroli, 1))
            {
                agenNavigasi.SetDestination(infoNavMesh.position);
                timerPatroli = 0f;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, jarakDeteksi);
    }
}