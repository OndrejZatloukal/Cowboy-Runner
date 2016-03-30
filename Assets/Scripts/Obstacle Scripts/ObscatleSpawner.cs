using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObscatleSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] obstacles;

	private List<GameObject> obstaclesForSpawning = new List<GameObject> ();

	void Awake () {
		InitializeObstacles ();
	}
	

	void Start () {
		StartCoroutine (SpawnRandomObstacles ());
	}

	void InitializeObstacles() {
		int index = 0;
		for (int i = 0; i < obstacles.Length * 3; i++) {
			GameObject obj = Instantiate (obstacles [index], new Vector3(transform.position.x,
				transform.position.y, -2), Quaternion.identity) as GameObject;
			obstaclesForSpawning.Add (obj);
			obstaclesForSpawning [i].SetActive (false);
			index++;
			if (index == obstacles.Length)
				index = 0;
		}
	}

	void Shuffle() {
		for (int i = 0; i < obstaclesForSpawning.Count; i++) {
			GameObject temp = obstaclesForSpawning [i];
			int random = Random.Range (i, obstaclesForSpawning.Count);
			obstaclesForSpawning[i] = obstaclesForSpawning[random];
			obstaclesForSpawning[random] = temp;

			// obj = list[i]; - means that obj holds value 3
			// list[i] = 3;
			// list[random] = 5;
			// list[i] = list[random];
			// list[i] = 5; - the previous value of 3 is now lost, and instead we have the value of 5
			// list[random] = obj; - meaning the previous value of random index is lost and now we have value of obj which is 3
		}
	}

	IEnumerator SpawnRandomObstacles() {
		yield return new WaitForSeconds (Random.Range (1.5f, 4.5f));

		int index = Random.Range (0, obstaclesForSpawning.Count);
		while (true) {
			if (!obstaclesForSpawning [index].activeInHierarchy) {
				obstaclesForSpawning [index].SetActive (true);
				obstaclesForSpawning [index].transform.position = new Vector3(transform.position.x, transform.position.y, -2);
				break;
			} else { 
				index = Random.Range (0, obstaclesForSpawning.Count);
			}
		}

		StartCoroutine (SpawnRandomObstacles ());
	}

} // ObscatleSpawner









































