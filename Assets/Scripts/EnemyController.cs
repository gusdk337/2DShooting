using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public enum eType
    {
        None = -1,
        Enemy1,
        Enemy2,
        Enemy3
    }

    public Action<Vector3> onExplode;

    public float speed;

    public int score;

    public eType type;


    public void Explode()
    {
        if (this.onExplode != null)
            this.onExplode(this.transform.position);

        Destroy(this.gameObject);
    }
    private void Update()
    {
        this.transform.Translate(Vector3.down * this.speed * Time.deltaTime);
        if (this.transform.position.y < -6.24f)
        {
            Destroy(this.gameObject);
        }
    }
}
