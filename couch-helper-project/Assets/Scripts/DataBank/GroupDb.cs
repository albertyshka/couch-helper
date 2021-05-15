using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBank
{
    public class GroupDb : SqliteHelper
    {
        private const string Tag = "Riz: GroupDb:\t";

        private const string TABLE_NAME = "Groups";
        private const string KEY_ID = "id";
        private const string KEY_NAME = "name";
        private const string KEY_CLASS_COST = "class_cost";
        private const string KEY_CREATION_DATE = "creation_date";

        private string[] COLUMNS = new string[] { KEY_ID, KEY_NAME, KEY_CLASS_COST, KEY_CREATION_DATE };

        public GroupDb() : base()
        {
            SqliteCommand dbcmd = GetDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_NAME + " TEXT, " +
                KEY_CLASS_COST + " REAL, " +
                KEY_CREATION_DATE + " DATETIME DEFAULT CURRENT_TIMESTAMP )";
            dbcmd.ExecuteNonQuery();
        }

        public void AddData(GroupEntity group)
        {
            SqliteCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_NAME + ", "
                + KEY_CLASS_COST + " ) "

                + "VALUES ( '"
                + group._id + "', '"
                + group._name + "', '"
                + group._classCost + "' )";
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

        public SqliteDataReader GetLatestTimeStamp()
        {
            SqliteCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " ORDER BY " + KEY_CREATION_DATE + " DESC LIMIT 1";
            return dbcmd.ExecuteReader();
        }
    }
}
