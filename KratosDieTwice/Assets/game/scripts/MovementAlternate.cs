using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LaneMovement : MonoBehaviour {
    [Header("Ayarlar")]
    public float laneDistance = 3.0f;
    public float laneSwitchSpeed = 10.0f;
    public float forwardSpeed;
    private int currentLane = 1;
    private float targetX;
    private int maxLaneIndex = 3;
   
  
    void Start() {
        CalculateTargetX();
    }

    void Update() {
      


        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.leftArrowKey.wasPressedThisFrame || keyboard.aKey.wasPressedThisFrame) {
            ChangeLane(-1);
        } else if (keyboard.rightArrowKey.wasPressedThisFrame || keyboard.dKey.wasPressedThisFrame) {
            ChangeLane(1);
        }

        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneSwitchSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    void ChangeLane(int direction) {
        currentLane += direction;
        currentLane = Mathf.Clamp(currentLane, 0, maxLaneIndex);
        CalculateTargetX();
    }

    void CalculateTargetX() {
        float centerOffset = (maxLaneIndex / 2.0f);
        targetX = (currentLane - centerOffset) * laneDistance;
    }}
   