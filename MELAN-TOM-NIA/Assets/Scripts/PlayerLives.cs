using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    // Variável pública que representa as vidas do jogador
    public int lives = 3;
    private Animator anim;
    void Start()
    {
        // Inicializa as vidas do jogador com 3 ao iniciar o jogo
        lives = 3;
        Debug.Log("Vidas do jogador: " + lives);
        anim = GetComponent<Animator>();
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
            Debug.Log("Game Over!");
            anim.SetBool("EstaMorrendo",true);
            // Exclui o jogador da cena
            Destroy(gameObject);
        }
        else
        {
            anim.SetBool("EstaMorrendo",false);
        }
        
    }
}
