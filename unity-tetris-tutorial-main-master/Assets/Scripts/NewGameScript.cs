using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameScript : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayGame()
    {
        Application.LoadLevel("Tetris");
    }
}
