using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().Explode();
            //Destroy(other.gameObject);
        }
    }
}
