using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public GameObject foodPrefab;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    public ScoreEvent scoreEvent;  // Referencia al ScriptableObject ScoreEvent

    private int currentScore;

    private void Start()
    {
        // Suscribir al evento de recolección de comida
        if (PlayerController.Instance != null)
        {
            PlayerController.Instance.onFoodCollected += OnFoodCollected;
        }

        // Instanciar la primera comida
        SpawnFood();
    }

    private void OnDestroy()
    {
        if (PlayerController.Instance != null)
        {
            PlayerController.Instance.onFoodCollected -= OnFoodCollected;
        }
    }

    private void OnFoodCollected()
    {
        currentScore++;
        scoreEvent.RaiseEvent(currentScore);  // Actualizar el puntaje mediante el ScoreEvent
    }

    public void SpawnFood()
    {
        float spawnX = UnityEngine.Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float spawnY = UnityEngine.Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        // Limitar la posición para asegurarse de que la comida esté dentro de los límites
        spawnX = Mathf.Clamp(spawnX, spawnAreaMin.x, spawnAreaMax.x);
        spawnY = Mathf.Clamp(spawnY, spawnAreaMin.y, spawnAreaMax.y);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }
        // Finalizar el juego
    public void EndGame()
    {
        // Detener el juego o mostrar menú de fin del juego
        Debug.Log("Game Over! Finaliza el juego.");
        Time.timeScale = 0f;
    }
}
