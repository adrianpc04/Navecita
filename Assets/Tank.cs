using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    [SerializeField, Range (0, 20)] private float speed;
    private float xMin = -9f, xMax = 9f;
    private float yMin = -4.3f, yMax = 4.4f;
    private float playerInput;
    private Vector2 moveInput;
    void Update()
    {
        Rango();
        transform.Translate(moveInput * speed * Time.deltaTime);
    }

    private void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }

    private void Rango()
    {
        float xPos = Mathf.Clamp(transform.position.x, xMin, xMax);
        float yPos = Mathf.Clamp(transform.position.y, yMin, yMax);

        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}
