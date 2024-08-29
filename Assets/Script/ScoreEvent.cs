using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Score Event", menuName = "Events/Score Action")]
public class ScoreEvent : ScriptableObject
{
    public event Action<int> onScoreChanged;  // Evento que notificará cuando el puntaje cambie
    public event Action<int> onMaxScoreChanged;  // Evento que notificará cuando el puntaje máximo cambie

    public int score = 0;  // Puntaje actual
    public int maxScore = 0;  // Puntaje máximo

    // Método para actualizar el puntaje actual y el máximo si es necesario
    public void RaiseEvent(int newScore)
    {
        score = newScore;

        // Invocar el evento de cambio de puntaje actual
        onScoreChanged?.Invoke(score);

        // Actualizar y emitir el puntaje máximo si se ha superado
        if (score > maxScore)
        {
            maxScore = score;
            onMaxScoreChanged?.Invoke(maxScore);
        }
    }
}
