using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : SaiMonoBehaviour
{
	[SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
	[SerializeField] protected float randomDelay = 1f;
	[SerializeField] protected float randomTimer = 0f;
	[SerializeField] protected float randomLimit = 9f;
	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadJunkCtrl();
	}

	protected void LoadJunkCtrl()
	{
		if (this.junkSpawnerCtrl != null) return;
		this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
		Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
	}

	protected override void Start()
	{
		//this.JunkSpawning();
	}

	protected virtual void FixedUpdate()
	{
		this.JunkSpawning();
	}

	protected virtual void JunkSpawning()
	{
		if (this.RandomReachLimit()) return;

		this.randomTimer += Time.fixedDeltaTime;
		if (this.randomTimer < this.randomDelay) return;
		this.randomTimer = 0;

		Transform ranPoint = this.junkSpawnerCtrl.SpawnPoints.GetRandom();
		Vector3 pos = ranPoint.position;
		Quaternion rot = transform.rotation;

		Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RandomPrefab();
 		Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, pos, rot);
		obj.gameObject.SetActive(true);
		
		//Invoke(nameof(this.JunkSpawning), 7f);
	}

	protected virtual bool RandomReachLimit()
	{
		int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnedCount;
		return currentJunk >= this.randomLimit;
	}
}
