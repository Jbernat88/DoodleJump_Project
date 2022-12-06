using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBM_PlatformSpawner : MonoBehaviour
{
    //Gizmos
    [SerializeField] float boxHeight;
    [SerializeField] float boxWidht;
    [SerializeField] float platformDistance;
    [SerializeField] Color gizmoColor;

    [SerializeField] GameObject[] platform;//Array

    private float halfHeight; //Heigh
    private float halfWidht; //Widh

    private List<GameObject> platforms = new List<GameObject>();//List

    private void Awake()
    {
         halfHeight = boxHeight * 0.5f;
         halfWidht = boxWidht * 0.5f;
    }
    public void Start()
    {
        Debug.Assert(platforms.Count < 1, "Ya");

        for (float i = transform.position.y - halfHeight; i < transform.position.y + halfHeight; i += platformDistance)           
            platforms.Add(Instantiate(platform[Random.Range(0, platform.Length)], transform));

        RandomizePlatforms();
    }

    //Randomise the platform spawn
    public void RandomizePlatforms()
    {
        Debug.Assert(platforms.Count > 1, "No");

        int count = 0;

        //loop that goes through all the distances of the platforms      
        for (float i = transform.position.y - halfHeight; i < transform.position.y + halfHeight; i += platformDistance)
        {
            platforms[count].gameObject.SetActive(true);//Active the clound when the spawn move
            platforms[count].transform.position = new Vector3(transform.position.x + Random.Range(-halfWidht, halfWidht), i);//Generate platforms randomly within the assigned margins
            count++;
        }
    }
    private void OnDrawGizmos()//Draw parameters in scene
    {
         halfHeight = boxHeight * 0.5f;
         halfWidht= boxWidht * 0.5f;

        //Parameters to find the points where the platforms will spawn     
        Vector2 topRight = new Vector2(transform.position.x + halfWidht, transform.position.y + halfHeight);
        Vector2 buttonRight = new Vector2(transform.position.x + halfWidht, transform.position.y - halfHeight);
        Vector2 topLeft = new Vector2(transform.position.x - halfWidht, transform.position.y + halfHeight);
        Vector2 buttonLeft = new Vector2(transform.position.x - halfWidht, transform.position.y - halfHeight);

        Gizmos.color = gizmoColor; //Add color to the gizmo
        //Create lines according to the marked parameters.
        Gizmos.DrawLine(topRight, topLeft);
        Gizmos.DrawLine(topRight, buttonRight);
        Gizmos.DrawLine(buttonLeft, topLeft);
        Gizmos.DrawLine(buttonRight, buttonLeft);

    }
}
