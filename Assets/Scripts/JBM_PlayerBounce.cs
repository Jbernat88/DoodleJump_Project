using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBM_PlayerBounce : MonoBehaviour
{
    [SerializeField] LayerMask layerMask; //Check the layers that lightning can hit
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

    //Sounds
    private AudioSource audioManager;
    public AudioClip boing; 

    private void Awake()
    {
        audioManager = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    //Calculate physics better
    private void FixedUpdate()
    {
        if (playerRigidbody.velocity.y < 0)
        {
            playerAnimator.SetBool("Jump", false);//Desctive the jump animation
        }

        //Only if we are going down and collide with the platform does the force apply and the player jumps
        RaycastHit2D ray = Physics2D.CircleCast(transform.position + offset, radius, Vector2.down, platformDistance, layerMask);
        if (playerRigidbody.velocity.y < 0 && ray)
        {
            playerRigidbody.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            playerAnimator.SetBool("Jump", true); //Active the jump animation

            //  when the lightning strikes the cloud, it disappears         
            if (ray.collider.gameObject.tag.Equals("Cloud"))
            {
                ray.collider.gameObject.SetActive(false); //The cloud dissapierd

                cloud = Instantiate(cloud, transform.position, cloud.transform.rotation);
            }

            audioManager.PlayOneShot(boing);
        }
    }
    // Update is called once per frame
    private void Update()
    {
        //Mouse Control
        if (Input.GetMouseButton(0))
        {
            //the world becomes that of the camera
            Vector3 mosuePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float xPosition = Mathf.Lerp(transform.position.x, mosuePosition.x, Time.deltaTime * movmentSmooth );

            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = color;//Give the color at the gizmo
        Gizmos.DrawWireSphere(transform.position + offset, radius);
        
    }
}
