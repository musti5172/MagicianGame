using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private int maxPlayerHealth = 100;
    [SerializeField] private int currentPlayerHealth;
    public GameObject gameOverScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverScreen.SetActive(false);
        currentPlayerHealth = maxPlayerHealth;
        healthBar.maxValue = maxPlayerHealth;
        healthBar.value = currentPlayerHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentPlayerHealth -= damageAmount;
        healthBar.value = currentPlayerHealth;

        if(currentPlayerHealth <= 0)
        {
            gameOverScreen.SetActive(true);
            Debug.Log("Öldün!");
            Time.timeScale = 0f;
        }

    }
}
