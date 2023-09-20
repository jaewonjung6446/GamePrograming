using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet1;
    [SerializeField]
    private float bullet1Speed = 30.0f;
    [SerializeField]
    private GameObject bullet2;
    [SerializeField]
    private float bullet2Speed = 80.0f;

    [SerializeField]
    private GameObject firepos;
    private GameObject fireBullet;
    private bool isBullet1 = true;
    private bool isBullet2 = false;
    public void Atk()
    {
        if (isBullet1)
        {
            fireBullet = GameObject.Instantiate(bullet1);
            fireBullet.transform.position = firepos.transform.position;
            fireBullet.GetComponent<Rigidbody>().velocity = firepos.transform.forward.normalized * bullet1Speed;
        }
        if (isBullet2)
        {
            fireBullet = GameObject.Instantiate(bullet2);
            fireBullet.transform.position = firepos.transform.position;
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey("e"))
        {
            Swap();
        }
    }
    public void Swap()
    {
        isBullet1 = !isBullet1;
        isBullet2 = !isBullet2;
    }
}
