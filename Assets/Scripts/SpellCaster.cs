using UnityEngine;

public class SpellCaster : MonoBehaviour
{

    public GameObject fireBall;
    public Transform firePoint;
    public float fireSpeed = 10f;
    public Animator handAnimations;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            handAnimations.SetTrigger("Shoot");
        }

    }

    void AtesEt()
    {
        GameObject yeniTop = Instantiate(fireBall, firePoint.position, firePoint.rotation);
        Rigidbody rb = yeniTop.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * fireSpeed;
        Destroy(yeniTop, 3f);
    }
}
