using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupilLine : MonoBehaviour
{
	[SerializeField] private ButtonManager _pupilFullName;

	public void SetName(string name)
	{
		Debug.Log($"setting name {name}");
		_pupilFullName.buttonText = name;
		_pupilFullName.UpdateUI();
	}
}
