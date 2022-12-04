using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerManager : MonoBehaviour
{
    [SerializeField] float playerCheckDelay = 0.5f;
    [SerializeField] float playerCheckDistance = 10f;
    [SerializeField] float spawnerMovment = 30f;
    [SerializeField] PlatformSpawner[] spawners;
    [SerializeField] Transform player;

    private void Start()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].Initialize();

            spawners[i].RandomizePlatforms();
        }
            StartCoroutine(CheckPlayerDistance());
    }

    IEnumerator CheckPlayerDistance()
    {
        while (Application.isPlaying)
        {
           for (int i = 0; i < spawners.Length; i++) //bucle infito para las platformas
           {
                if(spawners[i].transform.position.y < player.position.y &&(spawners[i].transform.position - player.position).sqrMagnitude > playerCheckDistance * playerCheckDistance)//Se activa cuando el jugador esta por encima.
                {
                    spawners[i].transform.position += Vector3.up * spawnerMovment;
                    spawners[i].RandomizePlatforms();//llama a la funcion de platform spawner para que se sigan randomizando
                }
           }

            yield return new WaitForSeconds(playerCheckDelay);
        }
    }
}
