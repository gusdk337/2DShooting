using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private int span = 1;
    private float delta = 0;

    private void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            GameObject prefab = null;
            var dice = Random.Range(1, 11);
            int idx = -1;
            if(dice <= 1)
            {
                //Enemy3
                idx = 2;
            }
            else if(dice >= 2 && dice < 5)
            {
                //Enemy2
                idx = 1;
            }
            else
            {
                //Enemy1
                idx = 0;
            }

            prefab = this.enemyPrefabs[idx];
            var enemyGo = Instantiate(prefab);
            enemyGo.transform.position = new Vector3(Random.Range(-2.07f, 2.07f), 5.65f, 0);
            this.delta = 0;
        }
    }
}
