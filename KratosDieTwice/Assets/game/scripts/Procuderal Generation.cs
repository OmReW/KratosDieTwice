using UnityEngine;

public class ProcuderalGeneration : MonoBehaviour
{
    public GameObject[] Cityref;
    public float lastspawnposition = 20;
    public float distance;
    public GameObject PlayerC;
    private GameObject[] CityList;
    public GameObject obstacleref;
    private GameObject[] obstaclelist;

   

   


        void Update() {
            if (lastspawnposition - PlayerC.transform.position.z < 30) {
                spawnobstacle();
                spawnCity();
                lastspawnposition += distance; 
                Debug.Log("çalışıyor");
            }
        }

        void spawnobstacle() {
            int rnd = Random.Range(-1, 2); 
            GameObject spawnedobstacle = Instantiate(obstacleref, new Vector3(rnd * 4, 1, lastspawnposition), Quaternion.identity);
         
        }

        void spawnCity() {
            int rndCity = Random.Range(0, Cityref.Length);
            int rnd = Random.Range(0, 2) == 0 ? -1 : 1; // Sadece -1 veya 1 (sağ/sol)
            GameObject spawnedobstacle = Instantiate(Cityref[rndCity], new Vector3(rnd * 50, 1, lastspawnposition), Quaternion.identity);
          
        }
    
}
