using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public bool isHoldingTrigger;


    private void Update()
    {
        isHoldingTrigger = Input.GetMouseButton(0);
    }
}

public class Gun
{
    public virtual void Shoot()
    {

    }
}