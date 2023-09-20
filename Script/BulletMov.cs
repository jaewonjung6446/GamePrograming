using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    private float time = 0;
    private void Update()
    {
        time += Time.deltaTime;
        if(time>= 3.0f)
        {
            Destroy(this.gameObject);
            Debug.Log("ÃÑÅº ÆÄ±«");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Debug.Log("ÃÑÅº ÆÄ±«");
        }
    }
}
