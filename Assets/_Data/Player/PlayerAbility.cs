using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : SaiMonoBehaviour
{
	public virtual void Active(AbilityCode abilitiesCode)
	{
		Debug.Log("AbilitiesCode: " + abilitiesCode.ToString());
	}
}
