using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBank
{

    public class ClassEntity
    {
        public string _id;
        public DateTime _dateOfConducting;
        public string _dateCreated;

		public ClassEntity(string id, DateTime dateOfConducting)
		{
			_id = id;
			_dateOfConducting = dateOfConducting;
		}
	}
}


