using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : SaiMonoBehaviour
{
	[SerializeField] protected Spawner spawner;
	[SerializeField] protected SpawnPoints spawnPoints;
	public Spawner Spawner => spawner;
	public SpawnPoints SpawnPoints => spawnPoints; 

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadSpawner();
		this.LoadSpawnPoints();
	}

	protected virtual void LoadSpawner()
	{
		if (this.spawner != null) return;
		this.spawner = GetComponent<Spawner>();
		Debug.Log(transform.name + ": LoadSpawner", gameObject);
	}

	protected void LoadSpawnPoints()
	{
		if (this.spawnPoints != null) return;
		this.spawnPoints = GameObject.Find("SceneSpawnPoints").GetComponent<SpawnPoints>();
		Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
	}
}