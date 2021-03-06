﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;


public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;
    public InformationsNiveau niveau;
    public static DeathZone instance;
    public InfoSteve infoVie;


    private void Start()
    {
 
    }

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;

        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Deathzone dans la scène");
            return;
        }
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            try
            {
                infoVie.updateLifeCountDie();
            }
            catch
            {

            }
            collision.transform.position = playerSpawn.position;
            // sauvegarde.ecrire();
            try
            {
                niveau.reinitialiser(playerSpawn.position);
            }
            catch
            {
                Debug.Log("fix comme en haut");
            }
            //GameOverManager.instance.OnPlayerDeath();
        }
    }
}
