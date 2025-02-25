using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Playing,
    IsGameOver,
    Ended,
    Paused
}


public class GameController : MonoBehaviour
{
    public static GameController Instance; // Singleton para facilitar o acesso ao GameController

    public GameObject enemyPrefab; // Prefab do inimigo
    public Transform[] spawnPoints; // Pontos de spawn dos inimigos
    public GameObject coletavel;
    public int maxEnemies = 5; // Número máximo de inimigos na cena
    public float spawnInterval = 3f; // Intervalo de spawn dos inimigos
    private int killCount; // Quantos inimigos foram mortos
    public int killsUntilReward; // Quantidade de inimigos que precisam ser mortos para dropar o coletável

    private List<GameObject> activeEnemies = new List<GameObject>(); // Lista de inimigos ativos
    private List<GameObject> activePickups = new List<GameObject>(); // Lista de pickups ativos

    public GameState currentGameState;

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
        RandomizeKills();
        currentGameState = GameState.Playing;
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
            Destroy(enemy.transform.parent.gameObject);
            killCount++;
            AudioManager.Instance.PlayEnemyDeathSound(); //Toca o som de morte do inimigo
        
        // Verifica se todos os inimigos foram derrotados
        if (activeEnemies.Count == 0)
        {
            Debug.Log("Todos os inimigos foram derrotados! Você venceu!");
            SceneManager.LoadScene("Level01");
        }
    }

    public void Pickup(Vector2 enemyPos)
    {
        if (killCount >= killsUntilReward)
        {
            GameObject pickup = Instantiate(coletavel, enemyPos, Quaternion.identity); /*Cria o coletavel
            na posição de morte do inimigo */
            activePickups.Add(pickup); // Adiciona o coletavel à lista
            killCount = 0; // Resetar o contador
            RandomizeKills(); //Aleatoriza novamente
        }
    }

    public void CollectAllPickups() /*Depois implementar uma coleta apropriada, quando houver um meio de
    armazenar pontos da Loja */
    {
        foreach (GameObject pickup in activePickups)
        {
            Destroy(pickup);
        }
        activePickups.Clear(); // Remove todos os pickups da lista
    }

    private void RandomizeKills() // Sorteia quantas kills serão necessárias pra dropar o coletável
    {
        killsUntilReward = Random.Range(2, 5); // Sorteia entre 3 e 7 kills para spawnar o coletável
    }

    public void CheckGameOver(int lives){
        if (lives <= 0)
        {
            currentGameState = GameState.IsGameOver;
        }
    }

}
