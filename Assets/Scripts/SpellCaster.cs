using UnityEngine;

public class SpellCaster : MonoBehaviour
{

    public GameObject fireBall;
    public Transform firePoint;
    public float fireSpeed = 30f;
    public Animator handAnimations;

    [Header("Eldeki Fireball Ayarlarý")]
    public GameObject fireBallOnHand;
    public float growingSpeed = 3f;
    public float maxSize = 1f;  


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

        if (fireBallOnHand.transform.localScale.x < maxSize)
        {
             float newSize  = fireBallOnHand.transform.localScale.x + (growingSpeed * Time.deltaTime);

            newSize = Mathf.Clamp(newSize, 0, maxSize);

            fireBallOnHand.transform.localScale = new Vector3(newSize, newSize, newSize);
        }

    }

    void AtesEt()
    {
        GameObject yeniTop = Instantiate(fireBall, firePoint.position, firePoint.rotation);
        Rigidbody rb = yeniTop.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * fireSpeed;
        Destroy(yeniTop, 3f);
        fireBallOnHand.transform.localScale = Vector3.zero;
    }
}
