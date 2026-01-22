using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movement : MonoBehaviour {
    private float horizontalLocation = 0f;
    public float forwardSpeed = 5f;
    //public float horizontalSpeed = 45f;
    public float booster = 2f;
    public float obstacle = -2f;
    public static float gameScore = 0;
    public GameObject hitEffect;
    public GameObject soundEffect;
    public GameObject boosterHitEffect;
    public GameObject obstacleHitEffect;
    public GameObject UIScreen;
    public float leftRightDistance = 5f;
    public GameObject soundEffectBorder;
    public GameObject soundEffectBooster;
    public GameObject soundEffectObstacle;
    



    void Start() {
        Application.targetFrameRate = 60;
        soundEffectBooster.SetActive(false);
    
    }


        // Update is called once per frame
        void Update() {
        if (forwardSpeed <= 0) {
            SceneManager.LoadScene(2);
            forwardSpeed = 0;
            Debug.Log(gameScore);
            hitEffect.SetActive(true);
              soundEffectBorder.SetActive(true);

        }
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, new Vector3(horizontalLocation, transform.position.y, transform.position.z), Time.deltaTime * 10);
            if (Keyboard.current.dKey.wasPressedThisFrame) {
                horizontalLocation = horizontalLocation + leftRightDistance;
            /*
            if (transform.position.x > 0) {
                //    transform.Translate(Vector3.left * horizontalSpeed* Time.deltaTime);
                horizontalLocation = Vector3.zero;
            }
            else if (transform.position.x > -2f) {
              //  transform.Translate(Vector3.left * horizontalSpeed );
            horizontalLocation = Vector3.left* -2f;

            }
            */
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }

            if (Keyboard.current.aKey.wasPressedThisFrame) {
                horizontalLocation = horizontalLocation - leftRightDistance;
                /*  if (transform.position.x < 0f) {
                     //    transform.Translate(Vector3.right * horizontalSpeed );
                     horizontalLocation = Vector3.zero;
                 } else if(transform.position.x < 2f)
                         {
                     //  transform.Translate(Vector3.right * horizontalSpeed );
                     horizontalLocation = Vector3.left*2f;
                 } 
                 */


            }
            horizontalLocation = Mathf.Clamp(horizontalLocation, -leftRightDistance, leftRightDistance);
        }

    
    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("obstacle")) {

            forwardSpeed = forwardSpeed + obstacle;
            Destroy(other.gameObject);
            gameScore--;
            //obstacleSoundEffect.SetActive(true);
            StartCoroutine(obstacleEffect());
            Debug.Log("aaa");

        }
        if (other.CompareTag("booster")) {
            forwardSpeed = forwardSpeed + booster;
            Destroy(other.gameObject);
            gameScore++;
            StartCoroutine(boosterEffect());
         
        }
      

    }
    IEnumerator obstacleEffect() {
        obstacleHitEffect.SetActive(true);
        soundEffectObstacle.SetActive(true);
       
        yield return new WaitForSeconds(0.5f);
        obstacleHitEffect.SetActive(false);
 soundEffectObstacle.SetActive(false);   
    }
  IEnumerator boosterEffect() {
       boosterHitEffect.SetActive(true);
        soundEffectBooster.SetActive(true);
      
        yield return new WaitForSeconds(0.5f);
        boosterHitEffect.SetActive(false);
         soundEffectBooster.SetActive(false);
    }

}

