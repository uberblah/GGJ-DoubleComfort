using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exiter : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("LASJGHKAJSHFKJASKJFHKASF");
            Application.Quit();
        }
    }
}
