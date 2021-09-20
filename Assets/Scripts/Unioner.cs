using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unioner : MonoBehaviour
{
    public static Unioner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Unir(Chincheta chinche1, Chincheta chinche2)
    {

    }
}
