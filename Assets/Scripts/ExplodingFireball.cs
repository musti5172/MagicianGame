using UnityEngine;
using UnityEngine.VFX;

public class ExplodingFireball : MonoBehaviour
{

    [SerializeField] private GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyAI>().TakeDamage(10f);
        }
        else
        {
            ContactPoint temasNoktasi = collision.contacts[0];
            GameObject effectClone = Instantiate(explosionEffect, temasNoktasi.point, Quaternion.LookRotation(temasNoktasi.normal));
            Destroy(effectClone, 2f);
        }

        Destroy(this.gameObject);


    }
}
