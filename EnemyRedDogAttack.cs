using UnityEngine;

public class EnemyRedDogAttack : EnemyAttack
{
    PlayerMoveControls playerMoveControls;

    public float forceX;
    public float forceY;
    public float duration;

    public override void SpecialAttack()
    {
        base.SpecialAttack();
        playerMoveControls = playerStats.GetComponentInParent<PlayerMoveControls>();
        StartCoroutine(playerMoveControls.KnockBack(forceX, forceY, duration, transform));
    }
}

