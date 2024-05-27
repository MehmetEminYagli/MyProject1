using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public GameObject[] healthRedPanels;

    void Start()
    {
        for (int i = 0; i < healthRedPanels.Length; i++)
        {
            healthRedPanels[i].SetActive(false);
        }
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        HealtPanel();
    }

    public void HealthMinus()
    {
        if (health > 0)
        {
            health -= 10;
            Debug.Log("can" + health + "azaldý");
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log("öldün gg");
        }
    }
    public void HealtPanel()
    {
        if (health > 69 && health < 81)
        {
            for (int i = 0; i < healthRedPanels.Length; i++)
            {
                healthRedPanels[i].SetActive(false);
            }
            healthRedPanels[0].SetActive(true);
        }
        else if (health > 50 && health < 75)
        {
            for (int i = 0; i < healthRedPanels.Length; i++)
            {
                healthRedPanels[i].SetActive(false);
            }
            healthRedPanels[1].SetActive(true);
        }
        else if (health > 25 && health < 50)
        {
            for (int i = 0; i < healthRedPanels.Length; i++)
            {
                healthRedPanels[i].SetActive(false);
            }
            healthRedPanels[2].SetActive(true);
        }
        else if (health > 0 && health < 25)
        {
            for (int i = 0; i < healthRedPanels.Length; i++)
            {
                healthRedPanels[i].SetActive(false);
            }
            healthRedPanels[3].SetActive(true);
        }
    }
}
