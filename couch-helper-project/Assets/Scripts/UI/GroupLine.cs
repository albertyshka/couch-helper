using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Michsky.UI.ModernUIPack;

public class GroupLine : MonoBehaviour
{
    [SerializeField] private ButtonManager _groupName;

    public void SetName(string name)
	{
		Debug.Log($"setting name {name}");
		_groupName.buttonText = name;
		_groupName.UpdateUI();
	}
}
