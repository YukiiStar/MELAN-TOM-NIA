using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtraActions : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameController.Instance.CollectAllPickups(); //Pede pro GameController limpar os pickups
        }
    }
}
