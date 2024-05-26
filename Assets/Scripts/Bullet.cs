using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //enemy'in içinden geçmesini istiyorum merminin o yüzden trigger kullanıyorum
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public float damageAmount = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

            //PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            //if (playerHealth != null)
            //{
            //    playerHealth.TakeDamage(damageAmount);
            //}
        }
    }

}
