using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float force = 1;
    private Vector2 cero;
    [SerializeField] GameObject over;
    private AudioSource audioSource;
    [SerializeField] private AudioClip boom;
    private CircleCollider2D box;
    private SpriteRenderer ventana;
    private void Start()
    {
        ventana = GetComponent<SpriteRenderer>();
        box = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
            transform.Translate(Vector2.left * force * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if  (collision.gameObject.CompareTag("Player")){
            audioSource.PlayOneShot(boom);
            ventana.enabled = false;
            box.enabled = false;
            Destroy(collision.gameObject);
            Time.timeScale = 0f;
            Instantiate(over, cero , Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Laser"))
        {
            audioSource.PlayOneShot(boom);
            Destroy(collision.gameObject);
            ventana.enabled = false;
            box.enabled = false;
            Destroy(gameObject,1);
        }
        if (collision.gameObject.CompareTag("MataMeteoros"))
        {
            Destroy(gameObject);
        }
    }
}
