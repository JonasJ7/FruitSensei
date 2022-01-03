using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public int hearts = 3;
    public int maxHearts = 3;
    [SerializeField ]HeartSystem hs;


    private void Start()
    {
        hs.DrawHearts(hearts, maxHearts);
        UpdateHealth();
    }

    public void Damage(int dmg)
    {
        if (hearts>0)
        {
            hearts -= dmg;
            hs.DrawHearts(hearts, maxHearts);
            UpdateHealth();
        }
    }

    public void Heal(int dmg)
    {
        if (hearts<maxHearts)
        {
            hearts += dmg;
            hs.DrawHearts(hearts, maxHearts);
        }
    }

    public void UpdateHealth()
    {
        if (hearts<=0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
