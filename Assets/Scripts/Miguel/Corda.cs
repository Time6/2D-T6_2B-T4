using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corda : MonoBehaviour {
    public int VelocidadeDeRotacao;
    public GameObject sprite;

    void Update()
    {
           sprite.transform.Rotate(0, 0, Time.deltaTime * VelocidadeDeRotacao);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "C")
        {
            VelocidadeDeRotacao = VelocidadeDeRotacao * -1;
        }
    }
}