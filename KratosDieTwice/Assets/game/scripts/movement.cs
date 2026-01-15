using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movement : MonoBehaviour {
    private float horizontalLocation = 0f;
    public float forwardSpeed = 5f;
    public float horizontalSpeed = 45f;
    public float booster = 2f;
    public float obstacle = -2f;
    public float gameScore = 0;
    public GameObject hitEffect;
    public GameObject soundEffect;
    public GameObject boosterHitEffect;
    public GameObject obstacleHitEffect;
    public GameObject UIScreen;
    public float leftRightDistance = 0f;
    public AudioClip soundEffectA;
    public AudioClip soundEffectB;
    public AudioClip soundEffectC;



    void Start() {
        Application.targetFrameRate = 60;
        hitEffect.SetActive(false);
        soundEffect.SetActive(false);
        UIScreen.SetActive(false);
        boosterHitEffect.SetActive(false);
        obstacleHitEffect.SetActive(false);
    }


        // Update is called once per frame
        void Update() {
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
            obstacleHitEffect.SetActive(true);
            AudioSource.PlayClipAtPoint(soundEffectC, transform.position);
          


        }
        if (other.CompareTag("booster")) {
            forwardSpeed = forwardSpeed + booster;
            Destroy(other.gameObject);
            gameScore++;
            AudioSource.PlayClipAtPoint(soundEffectB, transform.position);
         
        }
        if (other.CompareTag("border")) {
            SceneManager.LoadScene(2);
            forwardSpeed = 0;
            Debug.Log(gameScore);
            Destroy(other.gameObject);
            hitEffect.SetActive(true);
            //soundEffect.SetActive(true);
            AudioSource.PlayClipAtPoint(soundEffectA, transform.position);
        }

    }
  
}

