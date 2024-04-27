using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreUI;
    private int _score;

    private void OnEnable()
    {
        Platform.OnScoreAdded += AddScore;
    }

    public void AddScore()
    {
        _score++;
        _scoreUI.text = _score.ToString();
    }
    
}
