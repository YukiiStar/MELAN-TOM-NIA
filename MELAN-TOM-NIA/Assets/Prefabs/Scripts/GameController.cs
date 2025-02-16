using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance; // Singleton para facilitar o acesso ao GameController

    public GameObject enemyPrefab; // Prefab do inimigo
    public Transform[] spawnPoints; // Pontos de spawn dos inimigos
    public int maxEnemies = 5; // Número máximo de inimigos na cena
    public float spawnInterval = 3f; // Intervalo de spawn dos inimigos

    private List<GameObject> activeEnemies = new List<GameObject>(); // Lista de inimigos ativos

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (activeEnemies.Count < maxEnemies)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                activeEnemies.Add(enemy);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void EnemyDefeated(GameObject enemy)
    {
        activeEnemies.Remove(enemy);
        Destroy(enemy);

        // Verifica se todos os inimigos foram derrotados
        if (activeEnemies.Count == 0)
        {
            Debug.Log("Todos os inimigos foram derrotados! Você venceu!");
            LoadMenu();
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu"); // Carrega a cena do menu
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena atual
    }
}