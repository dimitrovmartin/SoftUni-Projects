using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }
        }

        private static void IncreaseAgeStoredProcedure(SqlConnection connection)
        {
            int id = int.Parse(Console.ReadLine());

            SqlCommand command = new SqlCommand($"EXEC usp_GetOlder @id = {id}", connection);

            command.ExecuteNonQuery();

            command = new SqlCommand($"SELECT Name, Age FROM Minions WHERE Id = {id}", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} - {reader[1]} years old");
                }
            }
        }

        private static void IncreaseMinionAge(SqlConnection connection)
        {
            List<string> minionNames = new List<string>();

            SqlCommand command = new SqlCommand(@"UPDATE Minions
   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
 WHERE Id = @Id", connection);

            int[] ids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (var id in ids)
            {
                SqlParameter parameter = new SqlParameter("@Id", id);

                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
                command.Parameters.Remove(parameter);
            }

            command = new SqlCommand("SELECT Name, Age FROM Minions", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    minionNames.Add(reader[0].ToString() + " " + reader[1].ToString());
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, minionNames));
        }

        private static void PrintAllMinionNames(SqlConnection connection)
        {
            List<string> minionNames = new List<string>();

            SqlCommand command = new SqlCommand("SELECT Name FROM Minions", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    minionNames.Add(reader[0].ToString());
                }
            }

            int counter = 0;

            while (minionNames.Any())
            {
                if (counter % 2 == 0)
                {
                    Console.WriteLine(minionNames[0]);

                    minionNames.RemoveAt(0);
                }
                else
                {
                    Console.WriteLine(minionNames[minionNames.Count - 1]);

                    minionNames.RemoveAt(minionNames.Count - 1);
                }

                counter++;
            }
        }

        private static void RemoveVillain(SqlConnection connection)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Villains WHERE Id = @villainId", connection);
            command.Parameters.Add(new SqlParameter("@villainId", villainId));
            int count = (int)command.ExecuteScalar();

            if (count == 0)
            {
                Console.WriteLine($"No such villain was found.");
            }
            else
            {
                command = new SqlCommand("SELECT Name FROM Villains WHERE Id = @villainId", connection);
                command.Parameters.Add(new SqlParameter("@villainId", villainId));

                string name = command.ExecuteScalar().ToString();

                command = new SqlCommand(@"DELETE FROM MinionsVillains 
      WHERE VillainId = @villainId", connection);

                command.Parameters.Add(new SqlParameter("@villainId", villainId));

                int affectedRows = command.ExecuteNonQuery();

                command = new SqlCommand(@"DELETE FROM Villains
      WHERE Id = @villainId", connection);

                command.Parameters.Add(new SqlParameter("@villainId", villainId));

                command.ExecuteNonQuery();

                Console.WriteLine($"{name} was deleted.");
                Console.WriteLine($"{affectedRows} minions was released.");
            }
        }

        private static void ChangeTownNamesCasing(SqlConnection connection)
        {
            string country = Console.ReadLine();

            SqlCommand command = new SqlCommand(@"UPDATE Towns
                                                        SET Name = UPPER(Name)
                                                        WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)", connection);

            command.Parameters.Add(new SqlParameter("@countryName", country));

            int affectedRows = command.ExecuteNonQuery();

            if (affectedRows > 0)
            {
                Console.WriteLine($"{affectedRows} town names were affected.");

                command = new SqlCommand(@"SELECT t.Name 
   FROM Towns as t
   JOIN Countries AS c ON c.Id = t.CountryCode
  WHERE c.Name = @countryName", connection);

                command.Parameters.Add(new SqlParameter("@countryName", country));
               
                List<string> towns = new List<string>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        towns.Add(reader[0].ToString());
                    }
                }

                Console.WriteLine($"[{string.Join(", ", towns)}]");
            }
            else
            {
                Console.WriteLine("No town names were affected.");
            }
        }

        private static void AddMinion(SqlConnection connection)
        {
            string[] minionData = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionData[1];
            int minionAge = int.Parse(minionData[2]);
            string minionCity = minionData[3];

            string villainName = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

            SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM Towns WHERE Name = @townName", connection);
            command.Parameters.Add(new SqlParameter(@"townName", minionCity));

            int count = (int)command.ExecuteScalar();

            if (count == 0)
            {
                command = new SqlCommand("INSERT INTO Towns (Name) VALUES (@townName)", connection);
                command.Parameters.Add(new SqlParameter(@"townName", minionCity));

                command.ExecuteNonQuery();

                Console.WriteLine($"Town {minionCity} was added to the database.");
            }

            command = new SqlCommand($"SELECT COUNT(*) FROM Villains WHERE Name = @Name", connection);
            command.Parameters.Add(new SqlParameter("@Name", villainName));

            count = (int)command.ExecuteScalar();

            if (count == 0)
            {
                command = new SqlCommand("INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)", connection);
                command.Parameters.Add(new SqlParameter(@"villainName", villainName));

                command.ExecuteNonQuery();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            command = new SqlCommand("SELECT Id FROM Towns WHERE Name = @townName", connection);
            command.Parameters.Add(new SqlParameter("@townName", minionCity));
            int townId = (int)command.ExecuteScalar();

            command = new SqlCommand("SELECT Id FROM Villains WHERE Name = @Name", connection);
            command.Parameters.Add(new SqlParameter(@"Name", villainName));
            int villainId = (int)command.ExecuteScalar();

            command = new SqlCommand($"SELECT COUNT(*) FROM Minions WHERE Name = @Name", connection);
            command.Parameters.Add(new SqlParameter("@Name", minionName));

            count = (int)command.ExecuteScalar();

            if (count == 0)
            {
                command = new SqlCommand("INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)", connection);

                command.Parameters.Add(new SqlParameter("@nam", minionName));
                command.Parameters.Add(new SqlParameter("@age", minionAge));
                command.Parameters.Add(new SqlParameter("@townId", townId));

                command.ExecuteNonQuery();
            }

            command = new SqlCommand("SELECT Id FROM Minions WHERE Name = @Name", connection);
            command.Parameters.Add(new SqlParameter(@"Name", minionName));
            int minionId = (int)command.ExecuteScalar();

            command = new SqlCommand("INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)", connection);

            command.Parameters.Add(new SqlParameter("@villainId", villainId));
            command.Parameters.Add(new SqlParameter("@minionId", minionId));

            command.ExecuteNonQuery();

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static void MinionNames(SqlConnection connection)
        {
            string id = Console.ReadLine();

            SqlCommand command = new SqlCommand("SELECT Name FROM Villains WHERE Id = @Id", connection);

            command.Parameters.Add(new SqlParameter("@Id", id));

            string villainName = (string)command.ExecuteScalar();

            if (villainName != null)
            {
                Console.WriteLine($"Villain: {villainName}");

            }
            else
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
                return;
            }

            command = new SqlCommand(@"SELECT ROW_NUMBER() OVER(ORDER BY m.Name) as RowNum,
                                         m.Name,
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name", connection);

            command.Parameters.Add(new SqlParameter("@Id", id));
            int counter = 0;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    counter++;

                    Console.WriteLine($"{counter}. {reader["Name"]} {reader["Age"]}");
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"(no minions)");
            }
        }

        private static void VillainNames(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(@"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount
                                                        FROM Villains AS v
                                                        JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                                            GROUP BY v.Id, v.Name
                                                            HAVING COUNT(mv.VillainId) > 3
                                                            ORDER BY COUNT(mv.VillainId)", connection);


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} => {reader[1]}");
                }
            }
        }

        private static void InitialSetup(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("CREATE DATABASE MinionsDB", connection);

            command.ExecuteNonQuery();

            command = new SqlCommand("USE MinionsDB", connection);

            command.ExecuteNonQuery();

            string[] tableQueries = GetTableQueries();
            string[] insertionQueries = GetInsertionQueries();

            foreach (var query in tableQueries)
            {
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }

            foreach (var query in insertionQueries)
            {
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public static string[] GetTableQueries()
        {
            string[] queries = new string[]
            {
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",
                "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))",
                "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))"
            };

            return queries;
        }

        public static string[] GetInsertionQueries()
        {
            string[] insertionQueries = new string[]
            {
                "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')",
                "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)",
                "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)",
                "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')",
                "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)",
                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)"
            };

            return insertionQueries;
        }
    }
}
