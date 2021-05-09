using System;

namespace DataBank
{
    public class PupilEntity
    {

        public string _id;
        public string _fullName;
        public DateTime _birthday;
		public string _documentsData;
        public string _pupilPhoneNumber;
        public string _relativeName;
		public string _relativePhoneNumber;
		public string _dateCreated;

		public PupilEntity(string id, string fullName, DateTime birthday, string documentsData, string pupilPhoneNumber, string relativeName, string relativePhone)
		{
			_id = id;
			_fullName = fullName;
			_birthday = birthday;
			_documentsData = documentsData;
			_pupilPhoneNumber = pupilPhoneNumber;
			_relativeName = relativeName;
			_relativePhoneNumber = relativePhone;
		}

		public static PupilEntity getFakeLocation()
        {
			return new PupilEntity(
				"0",
				"Sonya Kolesnik",
				new DateTime(2006, 5, 16),
				"doc data",
				"89997802822",
				"mom",
				"89997802822");
        }
    }
}