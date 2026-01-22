using UnityEngine;
using TMPro;

public class ScoreTExt : MonoBehaviour {
    public TextMeshProUGUI scoreText;

    void Update() {
        scoreText.text = "Score: " + movement.gameScore;
    }
}