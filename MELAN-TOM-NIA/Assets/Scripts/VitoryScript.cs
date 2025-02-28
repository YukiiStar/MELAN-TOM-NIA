using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class VitoryScript : MonoBehaviour
{
    [SerializeField] private string voltarMenu;
    [SerializeField] private string proximafase;
   


    public void SairJogo()
    {
        SceneManager.LoadScene(voltarMenu);
       
    }
    

    public void JogarProximaFase()
    {
        SceneManager.LoadScene(proximafase);
       
    }
}

