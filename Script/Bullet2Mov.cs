using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Mov : MonoBehaviour
{
    Rigidbody rb;
    GameObject target;
    float atLeast = 100;
    private float time= 0;
    private float fireSpeed = 10.0f;
    private void Start()
    {
        
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 3.0f)
        {
            Destroy(this.gameObject);
        }
        Targeting();
        Vector3 movPos = (target.transform.position - this.transform.position).normalized;
        this.transform.position += movPos * Time.deltaTime * fireSpeed;
    }
    private void Targeting()
    {
        GameObject[] EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < EnemyList.Length; i++)
        {
            if((this.transform.position - EnemyList[i].transform.position).magnitude < atLeast)
            {
                atLeast = (this.transform.position - EnemyList[i].transform.position).magnitude;
                target = EnemyList[i];
            }
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
