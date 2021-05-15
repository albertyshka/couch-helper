using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBank
{
    public class ClassDb : SqliteHelper
    {
        private const string Tag = "Riz: ClassDb:\t";

        private const string TABLE_NAME = "Classes";
        private const string KEY_ID = "id";
        private const string KEY_DATE_OF_CONDUCTING = "date_of_conducting";
        private const string KEY_CREATION_DATE = "creation_date";
        private string[] COLUMNS = new string[] { KEY_ID, KEY_DATE_OF_CONDUCTING, KEY_CREATION_DATE };

        public ClassDb() : base()
        {
            SqliteCommand dbcmd = GetDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_DATE_OF_CONDUCTING + " TEXT, " +
                KEY_CREATION_DATE + " DATETIME DEFAULT CURRENT_TIMESTAMP )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(ClassEntity @class)
        {
            SqliteCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_DATE_OF_CONDUCTING + " ) "

                + "VALUES ( '"
                + @class._id + "', '"
                + @class._dateOfConducting + "', "
                + "datetime('" + @class._dateOfConducting.ToString("yyyy-MM-dd HH:MM:SS.SSS") + "')" + " ) ";

            dbcmd.ExecuteNonQuery();
        }

        public override SqliteDataReader GetDataById(int id)
        {
            return base.GetDataById(id);
        }

        public override SqliteDataReader GetDataByString(string str)
        {
            Debug.Log(Tag + "Getting Location: " + str);

            SqliteCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }

        public override void DeleteDataByString(string id)
        {
            Debug.Log(Tag + "Deleting Location: " + id);

            SqliteCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + id + "'";
            dbcmd.ExecuteNonQuery();
        }

        public override void DeleteDataById(int id)
        {
            base.DeleteDataById(id);
        }

        public override void DeleteAllData()
        {
            Debug.Log(Tag + "Deleting Table");

            base.DeleteAllData(TABLE_NAME);
        }

        public override SqliteDataReader GetAllData()
        {
            return base.GetAllData(TABLE_NAME);
        }

        public SqliteDataReader getLatestTimeStamp()
        {
            SqliteCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " ORDER BY " + KEY_CREATION_DATE + " DESC LIMIT 1";
            return dbcmd.ExecuteReader();
        }
    }
}
