using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 1f;

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        this.transform.Translate(dir.normalized * this.speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bulletGo = Instantiate(this.bulletPrefab);
        bulletGo.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.9f, 0);
    }
}
