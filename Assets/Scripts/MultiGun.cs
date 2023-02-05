using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiGun : Gun
{
    [Tooltip("right fire point")]
    public Transform firePoint2;

    public override void Shoot()
    {
        //base.Shoot();

        GameObject leftGo = Instantiate(this.bulletPrefab);
        GameObject rightGo = Instantiate(this.bulletPrefab);

        leftGo.transform.position = this.firePoint.position;
        rightGo.transform.position = this.firePoint2.position;
    }
}
