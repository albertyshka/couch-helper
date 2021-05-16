using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using Mono.Data.Sqlite;
using System;

public class GroupList : MonoBehaviour
{
    [SerializeField] private GameObject _linePrefab;

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

			PasteLine(entity);

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

	private void PasteLine(GroupEntity groupEntity)
	{
		var groupLine = Instantiate(_linePrefab, transform);
		var script = groupLine.GetComponent<GroupLine>();

		script.SetName(groupEntity._name);
	}
}
