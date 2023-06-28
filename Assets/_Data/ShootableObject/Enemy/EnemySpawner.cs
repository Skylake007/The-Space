using UnityEngine;

public class EnemySpawner : Spawner
{
	private static EnemySpawner instance;
	public static EnemySpawner Instance => instance;

	protected override void Awake()
	{
		base.Awake();
		if (EnemySpawner.instance != null) Debug.Log("Only 1 EnemySpawner allow");
		EnemySpawner.instance = this;
	}

	public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
	{
		Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
		this.AddHPBarToObject(newEnemy);

		return newEnemy;
	}

	protected virtual void AddHPBarToObject(Transform newEnemy)
	{
		ShootableObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
		Transform newHPBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
		HPBar hpBar = newHPBar.GetComponent<HPBar>();

		hpBar.SetTarget(newEnemy);
		hpBar.SetObjCtrl(newEnemyCtrl);
		newHPBar.gameObject.SetActive(true);
	}
}
