using UnityEngine;

public class Gun : ScriptableObject
{
    public float shotInterval;
    public BulletTemplate template;
    protected float shotTimer = 0;

    public void Shot(Pool bulletClip,Vector3 direction,Vector3 startPosition,ref int bulletCount)
    {
        if (shotTimer <= 0)
        {
            if (bulletCount > 0)
            {
                Fire(bulletClip, direction, startPosition,ref bulletCount);
                shotTimer = shotInterval;
                PlayerController.animator.SetTrigger("Fire");
            }
        }
    }
    protected virtual void Fire(Pool bulletClip, Vector3 direction, Vector3 startPosition, ref int bulletCount)
    {

    }

    public virtual void Cooldown(float t)
    {
        shotTimer -= shotTimer > 0 ? t : 0;
    }
}
