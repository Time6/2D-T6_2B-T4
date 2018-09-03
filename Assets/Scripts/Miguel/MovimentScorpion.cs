using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentScorpion : MonoBehaviour {
    public float velocidade;
    public bool direcao;
    public float duracaoDirecao;

    private float tempoNaDirecao;
    private Animator animator;

    void Update()
    {
        if (direcao)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        tempoNaDirecao += Time.deltaTime;
        if (tempoNaDirecao >= duracaoDirecao)
        {
            tempoNaDirecao = 0;
            direcao = !direcao;
        }
    }
}
