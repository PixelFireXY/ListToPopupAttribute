using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Just a scriptable object to contain the data of the enum list.
/// </summary>
[CreateAssetMenu(fileName = "Enum List", menuName = "Enum list/New enum list")]
public class EnumListBehaviourSO : ScriptableObject
{
	public List<string> enumList;
}
