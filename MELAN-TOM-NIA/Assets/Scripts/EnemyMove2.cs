using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    /* Basicamente, aqui eu só mudei pra que o Inimigo procure o Transform do Player e atribua ele à
     variável PosAtual, ao invés de deixar ela como variável publica e referenciar o Transform do Player
     manualmente no inspector. Tava dando um probleminha que sempre que eu adicionava um prefab do inimigo
     na cena precisava referenciar o Transform do Player de novo pra cada inimigo, aí assim fica um pouco
     mais prático. 
     Ass: Luís */
    public Transform Inimigo;
    private Transform PosAtual;
    public float veloc;
  
    // Start is called before the first frame update
    void Start()
    {
        Inimigo.position = Inimigo.position;
        PosAtual = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
      
        Inimigo.position = Vector3.MoveTowards(Inimigo.position,PosAtual.position, veloc * Time.deltaTime);
      
    }

}