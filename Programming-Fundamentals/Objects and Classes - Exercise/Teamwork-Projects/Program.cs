using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] teamCreation = Console.ReadLine().Split('-');

                string creator = teamCreation[0];
                string teamName = teamCreation[1];

                Team team = new Team();

                team.Creator = creator;
                team.TeamName = teamName;

                if (teams.Exists(x => x.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else if (teams.Exists(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else
                {
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                    teams.Add(team);
                }
            }

            string[] memberToJoin = Console.ReadLine().Split("->");

            while (memberToJoin[0] != "end of assignment")
            {
                string user = memberToJoin[0];
                string nameOfTeam = memberToJoin[1];

                if (!teams.Exists(x => x.TeamName == nameOfTeam))
                {
                    Console.WriteLine($"Team {nameOfTeam} does not exist!");
                }
                else if (teams.Select(x => x.Members).Any(x => x.Contains(user)) ||
                         teams.Select(x => x.Creator).Any(x => x.Contains(user)))
                {
                    Console.WriteLine($"Member {user} cannot join team {nameOfTeam}!");
                }
                else
                {
                    int index = teams.FindIndex(x => x.TeamName == nameOfTeam);
                    teams[index].Members.Add(user);
                }
                memberToJoin = Console.ReadLine().Split("->");
            }

            List<Team> teamsToDisband = teams
                .OrderBy(x => x.TeamName)
                .Where(x => x.Members.Count == 0)
                .ToList();

            teams.RemoveAll(x => x.Members.Count == 0);

            teams.OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName);

            StringBuilder sb = new StringBuilder();

            foreach (var team in teams.OrderByDescending(x => x.TeamName))
            {
                sb.AppendLine($"{team.TeamName}");
                sb.AppendLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(x => x))
                {
                    sb.AppendLine($"-- {member}");
                }
            }

            sb.AppendLine("Teams to disband:");

            foreach (var teamToDisband in teamsToDisband)
            {
                sb.AppendLine(teamToDisband.TeamName);
            }

            Console.WriteLine(sb.ToString());
        }
    }

    class Team
    {

        public Team()
        {
            Members = new List<string>();
        }

        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

    }
}
