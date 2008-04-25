using System;
using System.Windows.Forms;
using Skorer.DataAccess;
using Skorer.Core;
using System.Collections.Generic;
using Skorer.Services;

namespace Skorer.WinForms
{
    
    public interface IMatchView
    {
        void StartMatch(string gameName);
    }

    public partial class MatchForm : Form, IMatchView
    {
        private IScorerFactory _ScorerFactory;
        private IScorer _Scorer;
        IRepository<Game, int> _GameRepository;

        private PlayerAdd _PlayerForm;
        public PlayerAdd PlayerForm
        {
            get
            {
                if (_PlayerForm == null || _PlayerForm.IsDisposed)
                {
                    _PlayerForm = new PlayerAdd(Skorer.IOC.Container.Resolve<IPlayerRepository>());
                    _PlayerForm.PlayerSelected += new EntitySelectedEventHander<Player>(_PlayerForm_PlayerSelected);
                }
                

                return _PlayerForm;
            }
        }                

        public void AddPlayer(Player player)
        {
            _Scorer.AddParticipant(player);
            PlayerList.Items.Remove(player);
            PlayerList.Items.Add(player);
            PlayerList.DisplayMember = "Name";
            PlayerList.ValueMember = "ID";                        
        }                            

        public MatchForm(IRepository<Game, int> gameRepository, IScorerFactory scorerFactory)
        {                        
            _GameRepository = gameRepository;
            _ScorerFactory = scorerFactory;
            
            InitializeComponent();
        }

        public void StartMatch(string gameName)
        {
            _Scorer = _ScorerFactory.GetScorerFor(gameName);
            _Scorer.LoadGame(gameName);                        
        }

        private void MatchForm_Load(object sender, EventArgs e)
        {                                                
            EventList.DataSource = _Scorer.Game.GetEvents();
            EventList.DisplayMember = "Name";
            EventList.ValueMember = "ID";   
        }

        void _PlayerForm_PlayerSelected(object o, EntitySelectedEventArgs<Player> e)
        {
            AddPlayer(e.SelectedEntity);            
        }        

        private void EventList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            _Scorer.AddEvent(
                (GameEvent)EventList.SelectedItem,
                (Player)PlayerList.SelectedItem,
                Int32.Parse(QuantityTextBox.Text));

            _RefreshEvents();
            _RefreshPlayerScores();
        }

        class PlayerScore
        {
            public PlayerScore(string name, int score)
            {
                Name = name;
                Score = score;
            }
            public string Name { get; set; }
            public int Score { get; set; }
        }

        public void _RefreshPlayerScores()
        {
            List<PlayerScore> playerScores = new List<PlayerScore>();
            foreach (Player player in _Scorer.Players)
            {
                playerScores.Add(new PlayerScore(
                    player.FirstName + " " + player.LastName, 
                    _Scorer.GetPlayerScore(player)));                   
            }

            PlayerScoreGrid.DataBindings.Clear();
            PlayerScoreGrid.DataSource = null;
            PlayerScoreGrid.Refresh();
            PlayerScoreGrid.DataSource = playerScores;
            PlayerScoreGrid.Refresh();
            PlayerScoreGrid.Update();
        }

        private void _RefreshEvents()
        {
            EventGrid.DataBindings.Clear();
            EventGrid.DataSource = null;
            EventGrid.Refresh();
            EventGrid.DataSource = _Scorer.MatchEvents;
            EventGrid.Update();
            EventGrid.Refresh();
        }
        private void newPlayerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PlayerForm.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Scorer.Save();
        }

        private void EventGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
   
        }
        
    }
}
