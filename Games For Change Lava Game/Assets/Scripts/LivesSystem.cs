using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesSystem : MonoBehaviour
{
    public int startHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            PlayerDies();
        }
    }

    public void hurtPlayer(int damage)
    {
        currentHealth -= damage;
    }

    public void healPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > startHealth)
        {
            currentHealth = startHealth;
        }
    }

    private void PlayerDies()
    {
        GameManager.instance.GameOver();
        gameObject.SetActive(false);
    }
}
