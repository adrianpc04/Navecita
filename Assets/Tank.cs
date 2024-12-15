using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    [SerializeField, Range(0, 20)] private float speed;
    private float xMin = -7.6f, xMax = 7.6f;
    private float yMin = -4.3f, yMax = 4.4f;
    private float playerInput;
    private Vector2 moveInput;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject antena;
    private AudioSource audioSource;
    [SerializeField] private AudioClip laserrr;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        Rango();
        transform.Translate(moveInput * speed * Time.deltaTime);
    }

    private void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }

    private void OnShoot(InputValue input)
    {
        if (Time.timeScale > 0)
        {
            audioSource.PlayOneShot(laserrr);
            Instantiate(laser, antena.transform.position, Quaternion.identity);
        }
    }

    private void Rango()
    {
        float xPos = Mathf.Clamp(transform.position.x, xMin, xMax);
        float yPos = Mathf.Clamp(transform.position.y, yMin, yMax);

        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }

    public void OnPausa()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
