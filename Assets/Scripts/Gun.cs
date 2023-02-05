using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public virtual void Shoot()
    {
        GameObject bulletGo = Instantiate(this.bulletPrefab);
        bulletGo.transform.position = this.firePoint.position;
    }
}
