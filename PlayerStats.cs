using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;

    private bool canTakeDamage = true;

    private Animator anim;
    public HealthBar healthBar;
    public Text gameOverText;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        health = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
    }
    public void TakeDamage(float damage)
    {
        if (!canTakeDamage)
        {
            return;
        }

        health -= damage;
        anim.SetBool("Damage", true);

        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }

        if (health <= 0)
        {
            Die();
        }
        StartCoroutine(DamagePrevention());
    }
    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if (health > 0)
        {
            canTakeDamage = true;
            anim.SetBool("Damage", false);
        }
        else
        {
            anim.SetBool("Death", true);
        }
    }
    private void Die()
    {
        Debug.Log("Game Over");

        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponentInParent<GatherInput>().DisableControls();

        if (gameOverText != null)
            gameOverText.gameObject.SetActive(true);

    }
}
