using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Server
{
    class PopulateDb
    {
        public static    void Populate()
        {
            try
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder();
                connectionStringBuilder.DataSource = "./TreeDB.db";
                StringBuilder rezult = new StringBuilder();
                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    var createcmd = connection.CreateCommand();
                    createcmd.CommandText = @"
CREATE TABLE  Tree_Items (
id integer Primary Key AutoIncrement,
type Text not null,
title Text not null
)";
                    createcmd.ExecuteNonQuery();
                    createcmd.CommandText = @"
CREATE TABLE  Step_owners (
ownerId integer,
taskId integer
)";
                    createcmd.ExecuteNonQuery();
                    createcmd.CommandText = @"
CREATE TABLE  Step_relation (
parent integer,
child integer
)";
                    createcmd.ExecuteNonQuery();
                    createcmd.CommandText = @"
CREATE TABLE  owners (
id integer primary key Autoincrement,
Name Text
)";
                    createcmd.ExecuteNonQuery();
                    createcmd.CommandText = @"
insert into Tree_Items (type,title)
values ('T','Task_1'),('T','Task_2'),('T','Task_3'),('S','Step_1_1'),('S','Step_1_2'),('S','Step_1_3')
,('S','Step_1_2_1'),('S','Step_1_2_1_1'),('S','Step_1_2_2')
,('S','Step_2_1'),('S','Step_2_1_1'),('S','Step_2_1_2')
,('S','Step_2_2');";
                    createcmd.ExecuteNonQuery();

                    createcmd.CommandText = @"
insert into owners (Name) values ('Marcel'),('Joe'),('Bob'),('Alice'),('Max')";
                    createcmd.ExecuteNonQuery();
                    createcmd.CommandText = @"
insert into Step_owners (ownerId,taskId) values (1,4),(2,5),(2,6),(2,13),(3,10),(3,11),(5,12),(4,11),(3,12)";
                    createcmd.ExecuteNonQuery();
                    createcmd.CommandText = @"
insert into Step_relation (parent,child) values (1,4),(1,5),(1,6),(2,10),(2,13),(2,6),(5,7),(5,9),(7,8),(0,1),(0,2),(0,3)";
                    createcmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
        }
    }
}
