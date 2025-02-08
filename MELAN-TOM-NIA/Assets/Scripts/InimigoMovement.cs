using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMovement : MonoBehaviour
{
    public Transform Inimigo;
    public Transform[] PosAtual;
    public float veloc;
  
    // Start is called before the first frame update
    void Start()
    {
        Inimigo.position = PosAtual[0].position;
    }


    // Update is called once per frame
    void Update()
    {
      
        Inimigo.position = Vector3.MoveTowards(Inimigo.position,PosAtual[1].position, veloc * Time.deltaTime);
      
    }

}


