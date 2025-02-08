using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
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