using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBank
{
    public class GroupEntity
    {
		public string _id;
		public string _name;
        public float _classCost;
		public string _dateCreated;

		public GroupEntity(string id, string name, float classCost)
		{
			_id = id;
			_name = name;
			_classCost = classCost;
		}
	}
}
