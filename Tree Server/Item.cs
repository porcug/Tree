using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
namespace Tree_Server
{
    class Item
    {
        public static string getItems(String path)
        {
            try
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder();
                connectionStringBuilder.DataSource = "./TreeDB.db";
                StringBuilder rezult = new StringBuilder();
                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    var selectcmd = connection.CreateCommand();
                    selectcmd.CommandText = "SELECT type,id,title FROM Tree_Items INNER JOIN Step_relation On Step_relation.child= Tree_Items.id WHERE Step_relation.parent=$parentId ";
                    selectcmd.Parameters.AddWithValue("$parentId", path);
                    List<List<String>> Items = new List<List<string>>();
                    using (var reader = selectcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            List<String> temp = new List<string>();
                            for (var index = 0; index < reader.FieldCount; index++)
                            {
                                temp.Add(reader.GetString(index));
                            }
                            Items.Add(temp);

                        }
                    }
                    for (int i = 0; i<Items.Count();i++)
                    {
                        var item = Items[i];
                        selectcmd = connection.CreateCommand();
                        selectcmd.CommandText = "SELECT Name FROM owners , Step_owners where Step_owners.ownerId = owners.id And Step_owners.taskId=$taskId";
                        selectcmd.Parameters.AddWithValue("$taskId", item[1]);
                        using (var reader = selectcmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.Add(reader.GetString(0));
                                System.Console.WriteLine(reader.GetString(0));
                            }
                        }
                       
                        
                    }
                   

                    foreach (var item in Items)
                    {
                        foreach (var value in item)
                        {
                            rezult.Append(value + "\n");
                        }
                        rezult.Append("\r\n");
                    }
                }

                return rezult.ToString();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "";
            }

        }
    }
}
