using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[CreateAssetMenu(fileName = "Pistol", menuName = "SO/Pistol")]
public class Pistol : Gun
{
    Light2D light2d;
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
            ob.GetComponentInChildren<Light2D>().color = template.color;
            ob.SetActive(true);
        }
    }
}