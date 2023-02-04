using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        this.transform.Translate(this.transform.up * this.speed * Time.deltaTime);

        if(this.transform.position.y >= 6.12)
        {
            Destroy(this.gameObject);
        }
    }
}
