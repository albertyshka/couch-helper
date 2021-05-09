using Mono.Data.Sqlite;
using UnityEngine;

namespace DataBank
{
    public class PupicDb : SqliteHelper
    {
        private const string Tag = "Riz: PupilDb:\t";

        private const string TABLE_NAME = "Pupils";
        private const string KEY_ID = "id";
        private const string KEY_FULL_NAME = "full_name";
        private const string KEY_BIRTHDAY = "birthday";
        private const string KEY_DOCUMENTS_DATA = "documents_data";
        private const string KEY_PUPIL_PHONE_NUMBER = "pupil_phone_number";
        private const string KEY_RELATIVE_NAME = "relative_name";
        private const string KEY_RELATIVE_PHONE = "relative_phone_number";
        private const string KEY_CREATION_DATE = "creation_date";
        private string[] COLUMNS = new string[] { KEY_ID, KEY_FULL_NAME, KEY_BIRTHDAY, KEY_DOCUMENTS_DATA, KEY_PUPIL_PHONE_NUMBER, KEY_RELATIVE_NAME, KEY_RELATIVE_PHONE, KEY_CREATION_DATE };

        public PupicDb() : base()
        {
            SqliteCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_FULL_NAME + " TEXT, " +
                KEY_BIRTHDAY + " TEXT, " +
                KEY_DOCUMENTS_DATA + " TEXT, " +
                KEY_PUPIL_PHONE_NUMBER + " TEXT, " +
                KEY_RELATIVE_NAME + " TEXT, " +
                KEY_RELATIVE_PHONE + " TEXT, " +
                KEY_CREATION_DATE + " DATETIME DEFAULT CURRENT_TIMESTAMP )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(PupilEntity pupil)
        {
            SqliteCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_FULL_NAME + ", "
                + KEY_BIRTHDAY + ", "
                + KEY_DOCUMENTS_DATA + ", "
                + KEY_PUPIL_PHONE_NUMBER + ", "
                + KEY_RELATIVE_NAME + ", "
                + KEY_RELATIVE_PHONE + " ) "

                + "VALUES ( '"
                + pupil._id + "', '"
                + pupil._fullName + "', "
                + "datetime('" + pupil._birthday.ToString("yyyy-MM-dd") + "')" + ", '"
                + pupil._documentsData + "', '"
                + pupil._pupilPhoneNumber + "', '"
                + pupil._relativeName + "', '"
                + pupil._relativePhoneNumber + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override SqliteDataReader getDataById(int id)
        {
            return base.getDataById(id);
        }

        public override SqliteDataReader getDataByString(string str)
        {
            Debug.Log(Tag + "Getting Location: " + str);

            SqliteCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }

        public override void deleteDataByString(string id)
        {
            Debug.Log(Tag + "Deleting Location: " + id);

            SqliteCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + id + "'";
            dbcmd.ExecuteNonQuery();
        }

        public override void deleteDataById(int id)
        {
            base.deleteDataById(id);
        }

        public override void deleteAllData()
        {
            Debug.Log(Tag + "Deleting Table");

            base.deleteAllData(TABLE_NAME);
        }

        public override SqliteDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }

/*        public SqliteDataReader getNearestLocation(LocationInfo loc)
        {
            Debug.Log(Tag + "Getting nearest centoid from: "
                + loc.latitude + ", " + loc.longitude);
            SqliteCommand dbcmd = getDbCommand();

            string query =
                "SELECT * FROM "
                + TABLE_NAME
                + " ORDER BY ABS(" + KEY_LAT + " - " + loc.latitude
                + ") + ABS(" + KEY_LNG + " - " + loc.longitude + ") ASC LIMIT 1";

            dbcmd.CommandText = query;
            return dbcmd.ExecuteReader();
        }*/

        public SqliteDataReader getLatestTimeStamp()
        {
            SqliteCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " ORDER BY " + KEY_CREATION_DATE + " DESC LIMIT 1";
            return dbcmd.ExecuteReader();
        }
    }
}