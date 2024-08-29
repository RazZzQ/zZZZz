using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;  // Referencia al texto del puntaje actual en la UI
    public Text maxScoreText;  // Referencia al texto del puntaje máximo en la UI
    public ScoreEvent scoreEvent;  // Referencia al ScriptableObject ScoreEvent

    private void OnEnable()
    {
        // Suscribirse a los eventos de cambio de puntaje y puntaje máximo
        scoreEvent.onScoreChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        // Desuscribirse de los eventos
        scoreEvent.onScoreChanged -= UpdateScoreText;
    }
    private void Start()
    {
        scoreText.text = "Score: " + scoreEvent.score.ToString();
        maxScoreText.text = "Max Score: " + scoreEvent.maxScore.ToString();
    }
    private void UpdateScoreText(int newScore)
    {
        // Actualizar el texto de la UI con el nuevo puntaje
        scoreText.text = "Score: " + newScore.ToString();
    }

    private void UpdateMaxScoreText(int newMaxScore)
    {
        // Actualizar el texto de la UI con el nuevo puntaje máximo
        maxScoreText.text = "Max Score: " + newMaxScore.ToString();
    }
}

