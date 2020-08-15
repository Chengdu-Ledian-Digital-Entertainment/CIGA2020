using UnityEngine;
[CreateAssetMenu(fileName = "Pistol", menuName = "SO/Pistol")]
public class Pistol : Gun
{
    GameObject ob;
    protected override void Fire(Pool bulletClip, Vector3 direction, Vector3 startPosition, ref int bulletCount)
    {
        if (bulletCount > 0)
        {
            bulletCount--;
            ob = bulletClip.Get();
            ob.GetComponent<Bullet>().template = template;
            ob.transform.right = direction;
            ob.transform.parent = null;
            ob.transform.position = startPosition;
            ob.SetActive(true);
        }
    }
}