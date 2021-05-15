using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Michsky.UI.ModernUIPack;

public class GroupLine : MonoBehaviour
{
    [SerializeField] private ButtonManagerBasic _groupName;

    public void SetGroupName(string name)
	{
		Debug.Log($"setting name {name}");
		_groupName.buttonText = name;
	}
}
