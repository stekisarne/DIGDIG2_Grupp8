﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaterScript : MonoBehaviour
{
    [SerializeField] float eaterSpeed;
    public AudioSource alarm;
    public bool bossTime = false;
    public PlayerHpScript playerHP;
    void Update()
    {
        if (!bossTime)
        {
            transform.Translate(0, -eaterSpeed * Time.deltaTime, 0); // Moves eater up or down depending on eaterSpeeds
        }
        if (bossTime) { Destroy(gameObject, 2f); }
    }

    void EatChunk(GameObject ChunkToDestroy) // Destroys ChunkToDestroy 5 seconds after touching
    {
        Destroy(ChunkToDestroy, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Chunk")
        {
            print("chunker");
            EatChunk(other.gameObject); // Calls function and sends the GameObject of triggering object
        }
        if (other.tag == "Player")
        {
            alarm.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            alarm.Stop();
        }
    }
}
