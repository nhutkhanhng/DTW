﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

	public Wave[] waves;
    public EntityManager _EntityManager;
    public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	// public GameManager gameManager;

	private int waveIndex = 0;

	void Update ()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			// gameManager.WinLevel();
			this.enabled = false;
		}

		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
// 		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

    /// <summary>
    /// Dừng hàm lại, Tạo khoảng cách thời gian giữa 2 Enemies lúc ra của 1 State
    /// </summary>
    /// <returns></returns>
	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}

		waveIndex++;
	}

	void SpawnEnemy (EntityInfo enemy)
	{
        var NewObject = _EntityManager.CreateEntity(enemy);
        NewObject.position = this.spawnPoint.position;
	}

}
