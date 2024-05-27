using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float bulletSpeed = 60;
    public Transform bulletSpawnPosition;
    public GameObject gun;
    public float recoilDistance = 0.5f; // Geri tepme mesafesi
    public float recoilDuration = 0.1f; // Geri tepme s�resi


    private Vector3 initialPosition; // Ba�lang�� pozisyonunu saklamak i�in

    void Start()
    {
        // Silah�n ba�lang�� pozisyonunu kaydet
        initialPosition = gun.transform.localPosition;
    }

    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("ateeee���");
            Fire();
        }
    }


    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab,bulletSpawnPosition.position,Quaternion.identity);
        Vector3 direction = transform.forward.normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;

        gun.transform.DOLocalMove(initialPosition - gun.transform.forward * recoilDistance, recoilDuration)
            .OnComplete(() =>
            {
                // Hareket tamamland���nda eski konumuna d�n
                gun.transform.DOLocalMove(initialPosition, recoilDuration);
            });

    }
}
