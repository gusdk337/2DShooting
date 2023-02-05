using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //public System.Action<Vector3> onExplode;
    public GameObject explosionPrefab;
    public float speed;

    private void Update()
    {
        this.transform.Translate(this.transform.up * this.speed * Time.deltaTime);

        if(this.transform.position.y >= 6.12f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GameObject explosionGo = Instantiate(explosionPrefab);
            explosionGo.transform.position = this.transform.position;
            //this.onExplode(other.gameObject.transform.position);

            var director = GameObject.FindObjectOfType<GameDirector>();
            var enemy = other.gameObject.GetComponent<EnemyController>();
            director.UpdateScore(enemy.score);

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
