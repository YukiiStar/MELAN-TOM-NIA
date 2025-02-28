using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public GameObject Morrendo;
    public GameObject Atacando;
    
    private SpriteRenderer sr;
    private BoxCollider2D box;

    void Start()
    {
        lives = 3;
        Debug.Log("Vidas do jogador: " + lives);
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    public void AddLives(int amount)
    {
        lives += amount;
        Debug.Log("Vida(s) adicionada(s)! Vidas atuais: " + lives);
    }

    public void RemoveLife(int amount = 1)
    {
        lives -= amount;
        Debug.Log("Vida perdida! Vidas restantes: " + lives);

        GameController.Instance.CheckGameOver(lives);
        if (GameController.Instance.currentGameState == GameState.IsGameOver)
        {
            sr.enabled = false;
            box.enabled = false;
            Morrendo.SetActive(true);
            AudioManager.Instance.PlayPlayerDeathSound();
            Destroy(gameObject, 2f);
        }
    }

}
