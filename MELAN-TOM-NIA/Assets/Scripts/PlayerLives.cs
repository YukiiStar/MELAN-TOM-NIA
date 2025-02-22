using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    // Variável pública que representa as vidas do jogador
    public int lives = 3;
    public GameObject Morrendo;
    
    
    private SpriteRenderer sr;
    private BoxCollider2D box;
    void Start()
    {
        // Inicializa as vidas do jogador com 3 ao iniciar o jogo
        lives = 3;
        Debug.Log("Vidas do jogador: " + lives);
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        
    }

    // Método para adicionar vidas (caso seja necessário em outros momentos do jogo)
    public void AddLives(int amount)
    {
        lives += amount;
        Debug.Log("Vida(s) adicionada(s)! Vidas atuais: " + lives);
    }

    // Método para remover vidas (por exemplo, ao receber dano)
    public void RemoveLife(int amount = 1)
    {
        lives -= amount;
        Debug.Log("Vida perdida! Vidas restantes: " + lives);

        if (lives <= 0)
        {
            sr.enabled = false;
            box.enabled = false;
            Morrendo.SetActive(true);
            AudioManager.Instance.PlayPlayerDeathSound(); //Toca o sfx de morte do player
            
            Destroy(gameObject, 2f);
        }
        
    }
}
