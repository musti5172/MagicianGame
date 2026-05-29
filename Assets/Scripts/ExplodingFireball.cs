using UnityEngine;
using UnityEngine.VFX;

public class ExplodingFireball : MonoBehaviour
{

    [SerializeField] private GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint temasNoktasi = collision.contacts[0];
        GameObject effectClone = Instantiate(explosionEffect, temasNoktasi.point, Quaternion.LookRotation(temasNoktasi.normal));
        Destroy(effectClone, 2f);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }
}
