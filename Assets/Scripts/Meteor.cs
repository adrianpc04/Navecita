using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float force = 1;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
            transform.Translate(Vector2.left * force * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if  (collision.gameObject.CompareTag("Player")){
            Destroy(collision.gameObject);
            Time.timeScale = 0f;
        }
        if (collision.gameObject.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("MataMeteoros"))
        {
            Destroy(gameObject);
        }
    }
}
