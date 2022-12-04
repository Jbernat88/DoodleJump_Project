using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    //Gizmos
    [SerializeField] float boxHeight;
    [SerializeField] float boxWidht;
    [SerializeField] float platformDistance;
    [SerializeField] Color gizmoColor;

    [SerializeField] GameObject platform;

    private float halfHeight; //alto
    private float halfWidht; //ancho

    private List<GameObject> platforms = new List<GameObject>();//Lista

    private void Awake()
    {
         halfHeight = boxHeight * 0.5f;
         halfWidht = boxWidht * 0.5f;
    }

    /*
    private void Start()
    {
        Initialize();

        RandomizePlatforms();
    }
    */

    public void Initialize()
    {
        Debug.Assert(platforms.Count < 1, "Ya");

        Debug.Log("instancia");

        for (float i = transform.position.y - halfHeight; i < transform.position.y + halfHeight; i += platformDistance)
            platforms.Add(Instantiate(platform, transform));
    }

    public void RandomizePlatforms()
    {
        Debug.Assert(platforms.Count > 1, "No");

        Debug.Log("RANDOMIZA");

        int count = 0;

        //bucle que recorre todas las distancias de las plataformas
        for (float i = transform.position.y - halfHeight; i < transform.position.y + halfHeight; i += platformDistance)
        {
            //if (Random.value >= 0.5) return; //7% de probabilidades de que haya plataformas
            platforms[count].transform.position = new Vector3(transform.position.x + Random.Range(-halfWidht, halfWidht), i);//Genera plataformas aleatoriamente dentro de los margenes asignados
            count++;
        }
    }
    private void OnDrawGizmos()//Dibuja parametros en escena
    {
         halfHeight = boxHeight * 0.5f;
         halfWidht= boxWidht * 0.5f;

        //Parametros para encontrar los puntos donde espaunearan las plataformas
        Vector2 topRight = new Vector2(transform.position.x + halfWidht, transform.position.y + halfHeight);
        Vector2 buttonRight = new Vector2(transform.position.x + halfWidht, transform.position.y - halfHeight);
        Vector2 topLeft = new Vector2(transform.position.x - halfWidht, transform.position.y + halfHeight);
        Vector2 buttonLeft = new Vector2(transform.position.x - halfWidht, transform.position.y - halfHeight);

        Gizmos.color = gizmoColor; //Añade color al gizmo
        //Crea lineas de segun los parametros marcados.
        Gizmos.DrawLine(topRight, topLeft);
        Gizmos.DrawLine(topRight, buttonRight);
        Gizmos.DrawLine(buttonLeft, topLeft);
        Gizmos.DrawLine(buttonRight, buttonLeft);

    }
}
