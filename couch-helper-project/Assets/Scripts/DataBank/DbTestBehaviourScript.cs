using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using Mono.Data.Sqlite;

public class DbTestBehaviourScript : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
/*		PupilDb mLocationDb = new PupilDb();

		//Add Data
		mLocationDb.AddData(new PupilEntity("0", "AR", new System.DateTime(2006, 12, 7), "0.007", "93745", "mom", "63463"));
		mLocationDb.AddData(new PupilEntity("1", "AR", new System.DateTime(2006, 12, 7), "0.006", "93745", "mom", "63463"));
		mLocationDb.AddData(new PupilEntity("2", "AR", new System.DateTime(2006, 12, 7), "0.005", "93745", "mom", "63463"));
		mLocationDb.AddData(new PupilEntity("3", "AR", new System.DateTime(2006, 12, 7), "0.004", "93745", "mom", "63463"));
		mLocationDb.AddData(new PupilEntity("4", "AR", new System.DateTime(2006, 12, 7), "0.003", "93745", "mom", "63463"));
		mLocationDb.AddData(new PupilEntity("5", "AR", new System.DateTime(2006, 12, 7), "0.002", "93745", "mom", "63463"));
		mLocationDb.AddData(new PupilEntity("6", "AR", new System.DateTime(2006, 12, 7), "0.001", "93745", "mom", "63463"));
		mLocationDb.Close();


		//Fetch All Data
		PupilDb mLocationDb2 = new PupilDb();
		SqliteDataReader reader = mLocationDb2.GetAllData();

		int fieldCount = reader.FieldCount;
		List<PupilEntity> myList = new List<PupilEntity>();
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
		}*/

		//for groups

		GroupDb groupDb = new GroupDb();

		//Add Data
		groupDb.AddData(new GroupEntity("0", "zD.funky", 500));
		groupDb.AddData(new GroupEntity("1", "funkyStyle", 450));
		groupDb.AddData(new GroupEntity("2", "fs.Kids", 600));
		groupDb.Close();

	}

	// Update is called once per frame
	void Update()
	{

	}
}