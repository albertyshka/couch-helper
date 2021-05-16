using DataBank;
using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupilList : MonoBehaviour
{
    [SerializeField] private GameObject _linePrefab;

	public void UpdateView()
	{
		PupilDb pupilDb = new PupilDb();
		SqliteDataReader reader = pupilDb.GetAllData();

		int fieldCount = reader.FieldCount;
		List<PupilEntity> myList = new List<PupilEntity>();

		DestroyAllChildren();

		while (reader.Read())
		{
			PupilEntity entity = new PupilEntity(
									reader[0].ToString(),
									reader[1].ToString(),
									System.DateTime.Parse(reader[2].ToString()),
									reader[3].ToString(),
									reader[4].ToString(),
									reader[5].ToString(),
									reader[6].ToString());


			Debug.Log($"id:  + {entity._id} " +
				$"_fullName {entity._fullName} " +
				$"_birthday {entity._birthday} " +
				$"_documentsData {entity._documentsData} " +
				$"_pupilPhoneNumber {entity._pupilPhoneNumber}");
			//Debug.Log("id: " + entity._id);
			myList.Add(entity);

			PasteLine(entity);

			myList.Add(entity);
		}

		pupilDb.Close();

	}

	private void DestroyAllChildren()
	{
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}
	}

	private void PasteLine(PupilEntity entity)
	{
		var line = Instantiate(_linePrefab, transform);
		var script = line.GetComponent<PupilLine>();

		script.SetName(entity._fullName);
	}
}
