using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using CrabBot.Model;
using Microsoft.Data.Sqlite;

namespace CrabBot.DbHelper
{
    public class SQLite : DbInterface
    {
        bool DbInterface.Check()
        {
            //string sql = "CREATE TABLE IF NOT EXISTS student(id integer, name varchar(20), sex varchar(2));";
            //SqliteCommand cmd = new SqliteCommand(sql, ServerGlobal.conn);
            //cmd.ExecuteNonQuery();//如果表不存在，创建数据表  
            using (var conn = new SqliteConnection(ServerGlobal.connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "show tables;";
                    SqliteCommand cmd = new SqliteCommand(sql, conn);
                    SqliteDataReader dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {

                    }
                    
                    return true;
                }
                catch (Exception ex)
                {
                    //无法连接到数据库，则报错
                    Common.Tools.PrintLn(ex.ToString(), ConsoleColor.Red);
                    return false;
                }
            }
        }

        bool DbInterface.BotsPersistence()
        {
            throw new NotImplementedException();
        }

        bool DbInterface.CreateConsoleLog(string content)
        {
            throw new NotImplementedException();
        }

        bool DbInterface.CreateMessageLog(Message message, Socket socket)
        {
            throw new NotImplementedException();
        }

        bool DbInterface.UserPersistence()
        {
            throw new NotImplementedException();
        }
     }
}
