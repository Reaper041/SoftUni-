using System.Data.SqlClient;
using System.Text;
using ADO.NET;

using SqlConnection sqlConnection = 
    new SqlConnection(Config.ConnectionString);

sqlConnection.Open();

//Console.WriteLine(GetVillainsNamesWithMinionsCount(sqlConnection));

//Console.WriteLine(GetVillainWithHisMinions(sqlConnection));

//Console.WriteLine(AddMinion(sqlConnection));

//Console.WriteLine(AllTownsToUpperCase(sqlConnection));


sqlConnection.Close();

static string GetVillainsNamesWithMinionsCount(SqlConnection sqlConnection)
{
	StringBuilder sb = new StringBuilder();

    string query = @"SELECT 
	                    v.Name,
	                    COUNT(v.Id) AS [NumberOfMinions]
                    FROM
	                    Villains AS v
                    JOIN
	                    MinionsVillains AS mv
	                    ON v.Id = mv.VillainId
                    JOIN 
	                    Minions AS m
	                    ON mv.MinionId = m.Id
                    GROUP BY
	                    v.Name
                    HAVING
	                    COUNT(v.Id) > 3
                    ORDER BY 
	                    COUNT(v.Id) DESC";

    SqlCommand cmd = new SqlCommand(query, sqlConnection);

	using SqlDataReader reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        sb.AppendLine($"{reader["Name"]} - {reader["NumberOfMinions"]}");
    }

    return sb.ToString().TrimEnd();
}

static string GetVillainWithHisMinions(SqlConnection sqlConnection)
{
    StringBuilder stringBuilder = new StringBuilder();

    string queryVillain = @"SELECT [Name] FROM Villains WHERE Id = @Id";

    SqlCommand getVillainName = new SqlCommand(queryVillain, sqlConnection);

    int id = int.Parse(Console.ReadLine());

    getVillainName.Parameters.AddWithValue("@Id", id);

    string villainName = (string)getVillainName.ExecuteScalar();

    if (villainName == null)
    {
        stringBuilder.AppendLine($"No villain with ID {id} exists in the database.");
        return stringBuilder.ToString().TrimEnd();
    }
    else
    {
        stringBuilder.AppendLine($"Villain: {villainName}");
    }

    string queryMinions = @"SELECT 
	                            ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
	                            m.Name,
	                            m.Age
                            FROM
	                            MinionsVillains AS mv
	                            JOIN Minions AS m ON mv.MinionId = m.Id
                            WHERE
	                            mv.VillainId = @Id
                            ORDER BY 
	                            m.Name";

    SqlCommand getMinions = new SqlCommand(queryMinions, sqlConnection);

    getMinions.Parameters.AddWithValue("@Id", id);

    using SqlDataReader reader = getMinions.ExecuteReader();

    if (reader.Read())
    {
        stringBuilder.AppendLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");

        while (reader.Read())
        {
            stringBuilder.AppendLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
        }

        return stringBuilder.ToString().TrimEnd();
    }
    else
    {
        return stringBuilder.AppendLine("(no minions)").ToString().TrimEnd();
    }
    
}

static string AddMinion(SqlConnection sqlConnection)
{
    StringBuilder sb = new StringBuilder();

    string[] minionInfo = Console.ReadLine()
        .Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray()[1]
        .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

    string minionName = minionInfo[0];
    int minionAge = int.Parse(minionInfo[1]);
    string minionTownName = minionInfo[2];

    string villainName = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray()[1];

    string townQuery = @"SELECT [Id] FROM Towns WHERE Towns.Name = @Name";

    SqlCommand townCmd = new SqlCommand(townQuery, sqlConnection);

    townCmd.Parameters.AddWithValue("@Name", minionTownName);
    

    if (townCmd.ExecuteScalar() == null)
    {
        string addTownQuery = @"INSERT INTO Towns(Name)
                                VALUES (@Name)";

        SqlCommand addTownCommand = new SqlCommand(addTownQuery, sqlConnection);

        addTownCommand.Parameters.AddWithValue("@Name", minionTownName);

        addTownCommand.ExecuteNonQuery();
        

        sb.AppendLine($"Town {minionTownName} was added to the database.");
    }

    int townId = (int)townCmd.ExecuteScalar();


    string villainQuery = @"SELECT [Id] FROM Villains WHERE Villains.Name = @Name";

    SqlCommand villainCmd = new SqlCommand(villainQuery, sqlConnection);

    villainCmd.Parameters.AddWithValue("@Name", villainName);

    if (villainCmd.ExecuteScalar() == null)
    {
        string addVillainQuery = @"INSERT INTO Villains(Name, EvilnessFactorId)
                                   VALUES (@Name, 4)";

        SqlCommand addVillainCmd = new SqlCommand( addVillainQuery, sqlConnection);

        addVillainCmd.Parameters.AddWithValue("@Name", villainName);

        addVillainCmd.ExecuteNonQuery();

        sb.AppendLine($"Villain {villainName} was added to the database.");
    }

    int villainId = (int)villainCmd.ExecuteScalar();

    string addMinionQuery = @"INSERT INTO Minions(Name, Age, TownId)
                               VALUES (@Name, @Age, @Town)";

    SqlCommand addMinionCmd = new SqlCommand(addMinionQuery, sqlConnection);

    addMinionCmd.Parameters.AddWithValue("@Name", minionName);
    addMinionCmd.Parameters.AddWithValue("@Age", minionAge);
    addMinionCmd.Parameters.AddWithValue("@Town", townId);


    addMinionCmd.ExecuteNonQuery();

    string minionIdQuery = @"SELECT [Id] FROM Minions WHERE Minions.Name = @Name";

    SqlCommand minionIdCmd = new SqlCommand(minionIdQuery, sqlConnection);

    minionIdCmd.Parameters.AddWithValue("@Name", minionName);

    int minionId = (int)minionIdCmd.ExecuteScalar();

    string matchMinionAndVillaingQuery = @"INSERT INTO MinionsVillains(MinionId, VillainId)
                                                VALUES (@MinionId, @VillainId)";

    SqlCommand matchMinionAndVillaingCmd = new SqlCommand(matchMinionAndVillaingQuery, sqlConnection);

    matchMinionAndVillaingCmd.Parameters.AddWithValue("@MinionId", minionId);
    matchMinionAndVillaingCmd.Parameters.AddWithValue("@VillainId", villainId);

    matchMinionAndVillaingCmd.ExecuteNonQuery();

    sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

    return sb.ToString().TrimEnd();
}

static string AllTownsToUpperCase(SqlConnection sqlConnection) 
{
    StringBuilder sb = new StringBuilder();

    string country = Console.ReadLine();

    string countryIdQuery = @"SELECT [Id] FROM Countries WHERE Name = @Name";

    SqlCommand countryIdCmd = new SqlCommand(countryIdQuery, sqlConnection);

    countryIdCmd.Parameters.AddWithValue("@Name", country);

    if (countryIdCmd.ExecuteScalar() == null)
    {
        sb.AppendLine($"No town names were affected.");

        return sb.ToString().TrimEnd();

    }

    int countryId = (int)countryIdCmd.ExecuteScalar();


    string townsQuery = @"SELECT [Name] FROM Towns WHERE Towns.CountryCode = @Id";

    SqlCommand townsCmd = new SqlCommand(townsQuery, sqlConnection);

    townsCmd.Parameters.AddWithValue("@Id", countryId);

    using SqlDataReader reader = townsCmd.ExecuteReader();

    if (!reader.HasRows)
    {
        sb.AppendLine($"No town names were affected.");

        return sb.ToString().TrimEnd();
    }
    
    List<string> towns = new List<string>();

    while (reader.Read())
    {
        towns.Add((string)reader["Name"]);
    }

    reader.Close();

    string toUpperQuery = @"UPDATE Towns 
                            SET Name = UPPER(Name)
                            WHERE [CountryCode] = @Id";

    SqlCommand toUpperCmd = new SqlCommand(toUpperQuery, sqlConnection);

    toUpperCmd.Parameters.AddWithValue(@"Id", countryId);

    toUpperCmd.ExecuteScalar();

    sb.AppendLine($"{towns.Count} town names were affected.");
    sb.AppendLine($"{String.Join(", ", towns)}");

    return sb.ToString().TrimEnd();
}