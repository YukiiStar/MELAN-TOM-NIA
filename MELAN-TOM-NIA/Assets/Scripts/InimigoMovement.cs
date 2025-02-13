using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMovement : MonoBehaviour
{
    public Transform Inimigo; // Referência ao Transform do inimigo
    public Transform[] PosAtual; // Pontos de movimento
    public float veloc = 2f; // Velocidade de movimento

    private int currentPointIndex = 0; // Índice do ponto atual

    void Start()
    {
        // Verifica se a referência ao Inimigo está definida
        if (Inimigo == null)
        {
            Inimigo = transform; // Usa o Transform do próprio objeto
        }

        // Verifica se há pontos de movimento definidos
        if (PosAtual == null || PosAtual.Length == 0)
        {
            Debug.LogError("Nenhum ponto de movimento definido para o inimigo!");
        }
        else
        {
            Inimigo.position = PosAtual[0].position; // Inicia no primeiro ponto
        }
    }

    void Update()
    {
        if (PosAtual != null && PosAtual.Length > 0)
        {
            // Move o inimigo em direção ao ponto atual
            Inimigo.position = Vector3.MoveTowards(Inimigo.position, PosAtual[currentPointIndex].position, veloc * Time.deltaTime);

            // Verifica se o inimigo chegou ao ponto atual
            if (Vector3.Distance(Inimigo.position, PosAtual[currentPointIndex].position) < 0.001f)
            {
                // Avança para o próximo ponto
                currentPointIndex = (currentPointIndex + 1) % PosAtual.Length;
            }
        }
    }
}