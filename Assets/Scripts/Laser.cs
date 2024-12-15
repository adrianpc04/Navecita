using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Laser : MonoBehaviour
{
    [SerializeField] float laserspeed = 20;
    private float desplazamiento;
    void Update()
    {
        transform.Translate(laserspeed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MataLaser"))
        {
            Destroy(gameObject);
        }
    }
}
