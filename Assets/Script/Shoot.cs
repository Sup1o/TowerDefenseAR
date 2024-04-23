using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform target;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = other.transform;
            if (fireCountdown <= 0f)
            {
                InititateBullet();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }


    void InititateBullet()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bulllet bullet = bulletGO.GetComponent<Bulllet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
