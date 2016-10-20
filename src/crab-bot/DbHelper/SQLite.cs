using System;
using System.Collections.Generic;
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
            try
            {
                using (var conn = new SqliteConnection(ServerGlobal.connStr))
                {

                    conn.Open();
                    string sql = "select name from sqlite_master where type='table' order by name;";
                    SqliteCommand cmd = new SqliteCommand(sql, conn);
                    SqliteDataReader dr = cmd.ExecuteReader();

                    if (!dr.HasRows)
                    {
                        return false;
                    }


                    while (dr.Read())
                    {
                        Common.Tools.PrintLn("找到表：" + dr["name"]);
                    }

                    return true;
                }

            }
            catch (Exception ex)
            {
                //无法连接到数据库，则报错
                Common.Tools.PrintDebug(ex.ToString(), ConsoleColor.Red);
                return false;
            }
        }

        bool DbInterface.BotsPersistence()
        {
            try
            {
                using (var conn = new SqliteConnection(ServerGlobal.connStr))
                {
                    conn.Open();
                    string sql = "REPLACE INTO Bots (BotId, Class, Status, Name, Description, SecretKey, Config) VALUES (@BotId, @Class, @Status, @Name, @Description, @SecretKey, @Config );";
                    foreach (var bot in ServerGlobal.bots)
                    {
                        SqliteCommand cmd = new SqliteCommand(sql, conn);

                        var botid = new SqliteParameter("@BotId",SqliteType.Text);
                        botid.Value = bot.Value.BotId.ToString();
                        cmd.Parameters.Add(botid);

                        var botclass = new SqliteParameter("@Class", SqliteType.Integer);
                        botclass.Value = (int)bot.Value.Class;
                        cmd.Parameters.Add(botclass);


                        var status = new SqliteParameter("@Status", SqliteType.Integer);
                        status.Value = (int)bot.Value.Status;
                        cmd.Parameters.Add(status);

                        var name = new SqliteParameter("@Name", SqliteType.Text);
                        name.Value = bot.Value.Name.ToString();
                        cmd.Parameters.Add(name);

                        var desc = new SqliteParameter("@Description", SqliteType.Text);
                        desc.Value = bot.Value.Description.ToString();
                        cmd.Parameters.Add(desc);

                        var sk = new SqliteParameter("@SecretKey", SqliteType.Text);
                        sk.Value = bot.Value.SecretKey.ToString();
                        cmd.Parameters.Add(sk);

                        var config = new SqliteParameter("@Config", SqliteType.Text);
                        config.Value = bot.Value.Config.ToString();
                        cmd.Parameters.Add(config);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.Tools.PrintDebug(ex.ToString(), ConsoleColor.Red);
                return false;
            }
        }

        bool DbInterface.UserPersistence()
        {
            //throw new NotImplementedException();
            return false;
        }

        bool DbInterface.CreateConsoleLog(string content)
        {
            throw new NotImplementedException();
        }

        bool DbInterface.CreateMessageLog(Message message, Socket socket)
        {
            throw new NotImplementedException();
        }
    }
}
