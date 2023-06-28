using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] public float playerHealth = 100f;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject toppledWall;
    [SerializeField] GameObject horde;
    [SerializeField] ParticleSystem smoke;
    [SerializeField] AudioSource wallExplosionSound;
    DeathHandler loadGameOver;
    public bool isDead = false;
    public bool generatorTurnedOn;
    private void Start()
    {
        healthText.text = "Health: " + playerHealth.ToString();
        scoreText.text = "Score: " + score.ToString();
    }
    public void TakeDamage(float enemyDamage)
    {
        playerHealth -= enemyDamage;
        if (playerHealth <= 0)
        {
            isDead = true;
            loadGameOver = FindObjectOfType<DeathHandler>();
            loadGameOver.HandleDeath();
            Debug.Log("Yer dead");
        }
    }

    public void Heal()
    {
        playerHealth = 100f;
    }

    public void BreakWall()
    {
        if (generatorTurnedOn == true)
        {
            toppledWall.GetComponent<Animator>().SetTrigger("WALL FALL");
            wallExplosionSound.Play();
            horde.SetActive(true);
            smoke.Play();
        }
    }

    public void DeleteDuplicates()
    {
        int numPlayer = FindObjectsOfType<Player>().Length;
        if (numPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Update()
    {
        healthText.text = "Health: " + playerHealth.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddToScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }
}
