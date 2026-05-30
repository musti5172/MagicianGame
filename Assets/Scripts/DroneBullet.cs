using Unity.VisualScripting;
using UnityEngine;

public class DroneBullet : MonoBehaviour
{
    [SerializeField] private float mermiHizi = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, 3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * mermiHizi * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(20);
            Destroy(this.gameObject);
        }


    }

}
