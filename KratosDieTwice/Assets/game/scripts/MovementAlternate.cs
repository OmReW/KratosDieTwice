using UnityEngine;
using UnityEngine.InputSystem; // <-- BU SATIRI EKLEMELİSİN

public class LaneMovement : MonoBehaviour
{
    [Header("Ayarlar")]
    public float laneDistance = 3.0f;
    public float laneSwitchSpeed = 10.0f;
    public float forwardSpeed;
    private int currentLane = 1;
    private float targetX;
    private int maxLaneIndex = 3;

    void Start()
    {
        CalculateTargetX();
    }

    void Update()
    {
        // Klavyeyi kontrol et
        var keyboard = Keyboard.current;
        if (keyboard == null) return; // Klavye yoksa hata vermesin

        // YENİ INPUT SİSTEMİ KODLARI:
        // Sol ok veya A tuşu
        if (keyboard.leftArrowKey.wasPressedThisFrame || keyboard.aKey.wasPressedThisFrame)
        {
            ChangeLane(-1);
        }
        // Sağ ok veya D tuşu
        else if (keyboard.rightArrowKey.wasPressedThisFrame || keyboard.dKey.wasPressedThisFrame)
        {
            ChangeLane(1);
        }

        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneSwitchSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    void ChangeLane(int direction)
    {
        currentLane += direction;
        currentLane = Mathf.Clamp(currentLane, 0, maxLaneIndex);
        CalculateTargetX();
    }

    void CalculateTargetX()
    {
        float centerOffset = (maxLaneIndex / 2.0f);
        targetX = (currentLane - centerOffset) * laneDistance;
    }
}