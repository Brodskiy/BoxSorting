﻿using UnityEngine;

class HeardController:MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterView>())
        {
            GetComponent<HeardView>().Deactivation();

            if (GameLiveInspector.Lives < 3)
            {                
                FindObjectOfType<GameLiveInspector>().LiveAdd(1);
            }            
        }
    }
}