using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBM_Cloud : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("si");
        Destroy(gameObject);
    }
    // Start is called before the first frame update

}
