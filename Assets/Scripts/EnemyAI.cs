using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    private NavMeshAgent agent;
    public float atesAraligi = 2f;
    private float atesZamani = 0f;
    [SerializeField] private GameObject mermiEnemyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, player.position);
        if ((mesafe > 10f))
        {
            agent.SetDestination(player.position);
        }
        else
        {
            atesZamani += Time.deltaTime;   
            agent.ResetPath();
            if (atesZamani >= atesAraligi)
            {
                transform.LookAt(player);
                Instantiate(mermiEnemyPrefab, transform.position, transform.rotation);
                atesZamani = 0f;
            }
        }


    }
}
