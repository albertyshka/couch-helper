using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using Mono.Data.Sqlite;
using System;

public class GroupList : MonoBehaviour
{
    [SerializeField] private GameObject _groupLine;

	public void UpdateView()
	{
		GroupDb groupsDb = new GroupDb();
		SqliteDataReader reader = groupsDb.GetAllData();

		int fieldCount = reader.FieldCount;
		List<GroupEntity> myList = new List<GroupEntity>();

		DestroyAllChildren();

		while (reader.Read())
		{
			GroupEntity entity = new GroupEntity(
									reader[0].ToString(),
									reader[1].ToString(),
									Int32.Parse(reader[2].ToString()));

			Debug.Log($"id:  + {entity._id} " +
				$"_name {entity._name} " +
				$"_classCost {entity._classCost}");

			PasteGroupLine(entity);

			myList.Add(entity);
		}

		groupsDb.Close();

	}

	private void DestroyAllChildren()
	{
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}
	}

	private void PasteGroupLine(GroupEntity groupEntity)
	{
		var groupLine = Instantiate(_groupLine, transform);
		var script = groupLine.GetComponent<GroupLine>();

		script.SetGroupName(groupEntity._name);
	}
}
