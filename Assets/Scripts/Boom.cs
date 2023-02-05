using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float duration = 2f;

    public void Init()
    {
        StartCoroutine(this.WaitForBoom());
    }

    private void Update()
    {
        this.transform.Translate(0, -0.03f, 0);

        if (transform.position.y < -5.87f)
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator WaitForBoom()
    {
        yield return new WaitForSeconds(this.duration);
        Destroy(this.gameObject);
    }

}

