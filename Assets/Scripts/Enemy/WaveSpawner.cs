using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

    public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	// public GameManager gameManager;

	private int waveIndex = 0;
}
