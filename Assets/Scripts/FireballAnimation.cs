using UnityEngine;

public class FireballAnimation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float olcek = 1f + Mathf.Sin(Time.time * 5f) * 0.1f;
        transform.localScale = new Vector3(olcek, olcek, olcek);
    }
}
