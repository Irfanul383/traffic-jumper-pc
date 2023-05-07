using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laneSpawner : MonoBehaviour
{

    [SerializeField] private GameObject [] carRefrence;
    [SerializeField] private GameObject [] itemRefrence;
    [SerializeField] private Transform Lane;
    private GameObject spawnedCars;
    private GameObject spawnedItems;
    private int randomCarIndex;
    private int randomItemIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(carSpawners());
        StartCoroutine(itemSpawner());
    }

    IEnumerator carSpawners(){
        while(true){
            yield return new WaitForSeconds(Random.Range(3,5));


            randomCarIndex = Random.Range(0,carRefrence.Length);

            spawnedCars = Instantiate(carRefrence[randomCarIndex]);
            spawnedCars.transform.localScale = new Vector3(.65f,-.65f,1f);
            spawnedCars.transform.position = Lane.position;
        }
}
    IEnumerator itemSpawner(){
        while(true){
            yield return new WaitForSeconds(Random.Range(8,10));
            

            randomItemIndex = Random.Range(0,itemRefrence.Length);
            spawnedItems = Instantiate(itemRefrence[randomItemIndex]);
            spawnedItems.transform.position = Lane.position;
        

        }
    }
}
