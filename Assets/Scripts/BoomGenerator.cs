using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomGenerator : MonoBehaviour
{
    public GameObject boomItemPrefabs;
    private float span = 3f;
    private float delta = 0;


    private void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject boomItemGo = Instantiate(boomItemPrefabs);
            boomItemGo.transform.position = new Vector3(Random.Range(-2.07f, 2.07f), 5.65f, 0);
        }

    }

}

