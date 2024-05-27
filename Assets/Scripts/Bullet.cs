using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
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

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("düşman yok et");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>();

            Destroy(gameObject);

            //PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            //if (playerHealth != null)
            //{
            //    playerHealth.TakeDamage(damageAmount);
            //}

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            other.transform.DORotate(new Vector3(-90, 0, 0), 0.5f)
                .OnComplete(() =>
                {
                    Destroy(other.gameObject);
                    Debug.Log("düşman yok et");
                });
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.HealthMinus();
            //playerHealth.HealtPanel();
        }
    }

}
