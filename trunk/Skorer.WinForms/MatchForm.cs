using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Skorer.DataAccess;
using Skorer.Core;

namespace Skorer.WinForms
{
    public interface IMatchView
    {
        Game CurrentGame { get; set; }
        Match CurrentMatch { get; set; }
        void StartMatch(Game game);
    }
    public partial class MatchForm : Form, IMatchView
    {
        IRepository<Match, int> _MatchRepository;
        IRepository<Game, int> _GameRepository;
        public Game CurrentGame { get;set;}
        public Match CurrentMatch { get; set; }

        public MatchForm(IRepository<Match, int> matchRepository, IRepository<Game, int> gameRepository)
        {
            _MatchRepository = matchRepository;
            _GameRepository = gameRepository;
            InitializeComponent();
        }


        public void StartMatch(Game game)
        {
            CurrentGame = game;
        }

        private void MatchForm_Load(object sender, EventArgs e)
        {
            CurrentMatch = new Match() { Game = CurrentGame };
            _MatchRepository.Save(CurrentMatch);
            EventList.DataSource = CurrentGame.Events;
            EventList.DisplayMember = "Name";            
        }
    }
}
