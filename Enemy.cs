using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 10f;
    public float health;
    public float damageCooldown = 0.2f; // เวลาช่วงกันโดนซ้ำ
    private bool canTakeDamage = true;
    private bool isDead = false;

    protected Rigidbody2D rb;
    private Animator anim;
    private Collider2D col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // ถ้าตายแล้วหรืออยู่ในช่วงกันโดนซ้ำ → ไม่ทำอะไร
        if (!canTakeDamage || isDead)
            return;

        health -= damage;

        // เล่นอนิเมชันโดนโจมตี
        anim.SetBool("Damage", true);

        // เริ่มกันโดนซ้ำชั่วคราว
        StartCoroutine(DamageCooldown());

        // ถ้าเลือดหมด → เรียกตาย
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);

        // ถ้ายังไม่ตาย → ปิด Hurt animation
        if (!isDead)
        {
            anim.SetBool("Damage", false);
            canTakeDamage = true;
        }
    }

    private IEnumerator Die()
    {
        isDead = true;
        canTakeDamage = false;

        // ปิดคอลลิเดอร์ไม่ให้โดนอีก
        if (col != null)
            col.enabled = false;
        rb.simulated = false;
        GetComponent<Collider2D>().enabled = false; // ปิด Collider ด้วย
        // เล่นอนิเมชันตาย
        anim.SetBool("Damage", false);
        anim.SetBool("Death", true);


        // หน่วงเวลาให้อนิเมชันเล่นจนจบ (แก้ตามเวลาจริงของคลิป Death)
        yield return new WaitForSeconds(1.2f);

        Destroy(gameObject);
    }
}
