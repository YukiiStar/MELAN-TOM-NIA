using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField]private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelLojinha;



    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }
    public void AbrirLojinha()
    {
        painelMenuInicial.SetActive(false);
        painelLojinha.SetActive(true);
    }
    public void CompraAceita()
    {
        Debug.Log("Compra Feita com Sucesso!");
    }
    public void CompraNegada()
    {
        Debug.Log("Compra Negada!");
    }

    public void FecharLojinha()
    {
        painelLojinha.SetActive(false);
        painelMenuInicial.SetActive(true);

    }
    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);

    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
