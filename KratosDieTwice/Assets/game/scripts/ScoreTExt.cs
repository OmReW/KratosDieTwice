using UnityEngine;
using TMPro;

public class ScoreTExt : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    public movement playerMovement; // Movement scriptine referans

    void Update() {
        if (scoreText != null && playerMovement != null) {
            scoreText.text = "Skor: " + playerMovement.gameScore.ToString();
        }
    }
}