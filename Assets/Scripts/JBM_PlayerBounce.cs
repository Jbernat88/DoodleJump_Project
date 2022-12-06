using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBM_PlayerBounce : MonoBehaviour
{
    [SerializeField] LayerMask layerMask; //Compruba las capas en las q puede golpear el rayo
    [SerializeField] Vector3 offset;
    [SerializeField] float platformDistance = 0.1f;
    [SerializeField] float radius = 0.1f;

    [SerializeField] float bounceForce;
    [SerializeField] float movmentSmooth;
    //Gizmos
    [Header("Gizmos")]
    [SerializeField] Color color;
    //Particles
    public ParticleSystem cloud;


    Rigidbody2D playerRigidbody;

    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()//Calucla mejor las fisicas
    {
        if (playerRigidbody.velocity.y < 0)
        {
            playerAnimator.SetBool("Jump", false);
        }

        //Solo si estamos bajando y colisionamos con la plataforma se plica la fuerza i el player salta
        RaycastHit2D ray = Physics2D.CircleCast(transform.position + offset, radius, Vector2.down, platformDistance, layerMask);
        if (playerRigidbody.velocity.y < 0 && ray)
        {
            playerRigidbody.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            playerAnimator.SetBool("Jump", true);

            if (ray.collider.gameObject.tag.Equals("Cloud"))
            {
                ray.collider.gameObject.SetActive(false);

                cloud = Instantiate(cloud, transform.position, cloud.transform.rotation);
            }
        }
    }
    // Update is called once per frame
    private void Update()
    {
        //Movimiento del raton
        if (Input.GetMouseButton(0))
        {
            Vector3 mosuePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float xPosition = Mathf.Lerp(transform.position.x, mosuePosition.x, Time.deltaTime * movmentSmooth );

            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = color;//Añade color al gizmo
        Gizmos.DrawWireSphere(transform.position + offset, radius);
        
    }
}
