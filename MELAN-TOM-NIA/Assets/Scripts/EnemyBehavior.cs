using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Dano que o inimigo causa ao jogador
    public int damage = 1;

    // Referências para os scripts de movimento
    public EnemyMove2 enemyMoveScript;
    public InimigoMovement inimigoMovementScript;

    // Posição de spawn do inimigo
    private Vector3 spawnPosition;

    // Tamanho do raio ao redor do spawn, que define a área onde o inimigo pode retornar
    public float spawnRadius = 5f;

    void Start()
    {
        // Definir a posição de spawn dependendo do script presente
        if (enemyMoveScript != null)
        {
            spawnPosition = enemyMoveScript.Inimigo.position;
        }
        else if (inimigoMovementScript != null)
        {
            spawnPosition = inimigoMovementScript.PosAtual[0].position;
        }
        else
        {
            spawnPosition = transform.position; // Fallback, caso nenhum script seja atribuído
        }
    }

    // Esse método é chamado quando outro collider entra no trigger do inimigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto colidido tem a tag "Player"
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlayPlayerHitSound();
            // Tenta obter o componente PlayerLives do objeto do jogador
            PlayerLives playerLives = collision.GetComponent<PlayerLives>();
            if (playerLives != null)
            {
                // Causa 1 de dano ao jogador
                playerLives.RemoveLife(damage);
                // Retorna o inimigo para sua posição de spawn com um raio maior
                ReturnToSpawn();
            }
        }
    }

    // Método que reposiciona o inimigo em seu ponto de origem (com raio maior)
    void ReturnToSpawn()
    {
        // Gera uma nova posição de spawn dentro do raio especificado
        Vector3 newSpawnPosition = spawnPosition + new Vector3(
            Random.Range(-spawnRadius, spawnRadius),
            Random.Range(-spawnRadius, spawnRadius),
            0f
        );

        // Teleporta o inimigo para a nova posição de spawn
        transform.position = newSpawnPosition;
    }
}
