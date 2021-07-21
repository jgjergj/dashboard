﻿using Dashboard.Application.Sports.ViewModels;
using Dashboard.Application.States.ViewModels;

namespace Dashboard.Application.Teams.ViewModels
{
    public class TeamVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StateVM State { get; set; }
        public SportVM Sport { get; set; }
        public LeagueVM Leagues { get; set; }
    }
}
