using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform player; // Oyuncunun pozisyonu
    public GameObject bulletPrefab; // Mermi prefabı
    public float bulletSpeed = 60;
    public Transform bulletSpawnPosition;
    public float fireInterval = 1f; // Ateş aralığı
    public float shootingRange = 10f; // Ateş menzili
    private float fireTimer = 0f; // Ateş zamanlayıcısı

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncunun transform bileşenine erişim sağlanır
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer < shootingRange)
            {
                fireTimer += Time.deltaTime;

                if (fireTimer >= fireInterval)
                {
                    Fire();
                    fireTimer = 0f;
                }
            }
        }
    }

    void Fire()
    {
        Debug.Log("Enemy is shooting!"); // Ateş etme işlemi burada gerçekleştirilebilir

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.identity);
        Vector3 direction = (player.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;

        Destroy(bullet, 3f);
    }
}
