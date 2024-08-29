using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Score Event", menuName = "Events/Score Action")]
public class ScoreEvent : ScriptableObject
{
    public event Action<int> onScoreChanged;  // Evento que notificar� cuando el puntaje cambie
    public event Action<int> onMaxScoreChanged;  // Evento que notificar� cuando el puntaje m�ximo cambie

    public int score = 0;  // Puntaje actual
    public int maxScore = 0;  // Puntaje m�ximo

    // M�todo para actualizar el puntaje actual y el m�ximo si es necesario
    public void RaiseEvent(int newScore)
    {
        score = newScore;

        // Invocar el evento de cambio de puntaje actual
        onScoreChanged?.Invoke(score);

        // Actualizar y emitir el puntaje m�ximo si se ha superado
        if (score > maxScore)
        {
            maxScore = score;
            onMaxScoreChanged?.Invoke(maxScore);
        }
    }
}
