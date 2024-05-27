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
    public float recoilDuration = 0.1f; // Geri tepme süresi


    private Vector3 initialPosition; // Baþlangýç pozisyonunu saklamak için

    void Start()
    {
        // Silahýn baþlangýç pozisyonunu kaydet
        initialPosition = gun.transform.localPosition;
    }

    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("ateeeeþþþ");
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
                // Hareket tamamlandýðýnda eski konumuna dön
                gun.transform.DOLocalMove(initialPosition, recoilDuration);
            });

    }
}
