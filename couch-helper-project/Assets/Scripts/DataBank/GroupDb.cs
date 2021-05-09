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
            SqliteCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_NAME + " TEXT, " +
                KEY_CLASS_COST + " REAL, " +
                KEY_CREATION_DATE + " DATETIME DEFAULT CURRENT_TIMESTAMP )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(GroupEntity group)
        {
            SqliteCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_NAME + ", "
                + KEY_CLASS_COST + " ) "

                + "VALUES ( '"
                + group._id + "', '"
                + group._name + "', "
                + group._classCost + "' )";
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

        public SqliteDataReader getLatestTimeStamp()
        {
            SqliteCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " ORDER BY " + KEY_CREATION_DATE + " DESC LIMIT 1";
            return dbcmd.ExecuteReader();
        }
    }
}
