using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Setinhas : MonoBehaviour
{
    public int sequenceLength = 5; // Número de teclas na sequência
    public GameObject arrowPrefab; // Prefab da imagem da seta
    public Transform enemy; // Referência ao inimigo
    public Vector3 arrowOffset = new Vector3(0, 1.2f, 0); // Posiciona as setas mais próximas do inimigo
    public float arrowSpacing = 0.6f; // Reduz a distância entre as setas
    public Sprite upArrowSprite, downArrowSprite, leftArrowSprite, rightArrowSprite; // Sprites das setas

    private List<KeyCode> possibleArrows = new List<KeyCode> { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow };
    private List<KeyCode> enemySequence; // Sequência aleatória do inimigo
    private List<GameObject> arrowObjects = new List<GameObject>(); // Lista das setas visuais
    private int currentIndex = 0; // Índice da seta atual que deve ser pressionada

    void Start()
    {
        GenerateRandomSequence();
        DisplayArrows();
        
        Debug.Log("Um inimigo apareceu! Pressione a sequência correta de teclas direcionais para derrotá-lo!");
        Debug.Log("Sequência do inimigo (para testes): " + string.Join(", ", enemySequence));
    }

    void Update()
    {
        if (currentIndex >= enemySequence.Count) return; // Se todas as setas foram acertadas, não faz nada

        foreach (KeyCode key in possibleArrows)
        {
            if (Input.GetKeyDown(key))
            {
                Debug.Log("Tecla pressionada: " + key);

                // Verifica se a tecla pressionada é a próxima na sequência
                if (key == enemySequence[currentIndex])
                {
                    Destroy(arrowObjects[currentIndex]); // Remove a seta correspondente
                    currentIndex++; // Avança para a próxima tecla esperada

                    // Se todas as setas foram pressionadas corretamente
                    if (currentIndex >= enemySequence.Count)
                    {
                        Debug.Log("Você derrotou o inimigo! Parabéns!");
                        this.enabled = false; // Desativa o script após a vitória
                    }
                }
            }
        }
    }

    void GenerateRandomSequence()
    {
        enemySequence = new List<KeyCode>();
        for (int i = 0; i < sequenceLength; i++)
        {
            int index = Random.Range(0, possibleArrows.Count);
            enemySequence.Add(possibleArrows[index]);
        }
    }

    void DisplayArrows()
    {
        for (int i = 0; i < enemySequence.Count; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab, enemy.position + arrowOffset + new Vector3(i * arrowSpacing, 0, 0), Quaternion.identity);
            SpriteRenderer sr = arrow.GetComponent<SpriteRenderer>();

            // Define o sprite correto
            switch (enemySequence[i])
            {
                case KeyCode.UpArrow: sr.sprite = upArrowSprite; break;
                case KeyCode.DownArrow: sr.sprite = downArrowSprite; break;
                case KeyCode.LeftArrow: sr.sprite = leftArrowSprite; break;
                case KeyCode.RightArrow: sr.sprite = rightArrowSprite; break;
            }

            arrow.transform.SetParent(enemy); // Define as setas como filhas do inimigo
            arrowObjects.Add(arrow);
        }
    } 
}
