using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; set; }
    public GameManager gameManager;
    public float speed = 5f;
    private Vector2 movement;

    public event Action onFoodCollected;  // Evento para la recolección de comida

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 position = transform.position;
        position += movement * speed * Time.fixedDeltaTime;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            onFoodCollected?.Invoke();  // Evento de comida recolectada
            gameManager.SpawnFood();
            Destroy(other.gameObject);
        }
    }
}
