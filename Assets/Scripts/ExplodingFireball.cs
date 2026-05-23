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
        Destroy(this.gameObject);
    }

    private void Update()
    {
        float olcek = 1f + Mathf.Sin(Time.time * 5f) * 0.1f;
        transform.localScale = new Vector3(olcek, olcek, olcek);
    }
}
