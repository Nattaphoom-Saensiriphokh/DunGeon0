using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 10f;
    private int enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            collision.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
}
