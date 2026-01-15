using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
   
    public void StartOnClick() {
       
        SceneManager.LoadScene("Omer-Chan UWUdes");

    }

 
    public void ExitOnClick() {
     
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
       
        Application.Quit();
#endif

        Debug.Log("Oyundan çýkýlýyor...");
    }
}



