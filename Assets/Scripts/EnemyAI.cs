using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    [Header("Saldýrý Ayarlarý")]
    public float atesAraligi = 2f;
    private float atesZamani = 0f;
    [SerializeField] private GameObject mermiEnemyPrefab;

    private MeshRenderer boyaci;
    private Color orjinalRenk;

    [Header("Can ve Efekt Ayarlarý")]
    [SerializeField] private float enemyHealth = 30f;
    [SerializeField] private GameObject explosionEffectPrefab;

    [SerializeField] private Slider enemyHealthBar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boyaci = GetComponentInChildren<MeshRenderer>();
        orjinalRenk = boyaci.material.color;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthBar.transform.LookAt(Camera.main.transform);
        float mesafe = Vector3.Distance(transform.position, player.position);
        if ((mesafe > 10f))
        {
            agent.SetDestination(player.position);
        }
        else
        {
            transform.LookAt(player);
            atesZamani += Time.deltaTime;   
            agent.ResetPath();
            if (atesZamani >= atesAraligi)
            {
                Instantiate(mermiEnemyPrefab, transform.position, transform.rotation);
                atesZamani = 0f;
            }
        }


    }

    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;


        if(enemyHealthBar != null)
        {
            enemyHealthBar.value = (float)enemyHealth / 30f;

        }

        boyaci.material.color = Color.red;
        Invoke("FixColor", 0.1f);

        if(enemyHealth <= 0f)
        {
            Die();
        }
    }
    
    void FixColor()
    {
        boyaci.material.color = orjinalRenk;

    }

    void Die()
    {
        if(explosionEffectPrefab != null)
        {
            GameObject explosionEffect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(explosionEffect, 2f);
        }

        Destroy(this.gameObject);
    }
}
