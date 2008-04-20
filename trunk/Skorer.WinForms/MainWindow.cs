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
using Skorer.Services;

namespace Skorer.WinForms
{
    public interface IDefaultView
    {
        
    }

    public partial class MainWindow : Form, IDefaultView
    {
        private IRepository<Game, int> _GameRepository;

        public MainWindow(IRepository<Game, int> gameRepository)
        {
            _GameRepository = gameRepository;
            InitializeComponent();
        }


        private void _LoadMenuItems()
        {
            foreach (Game game in _GameRepository.GetAll())
            {
                var toolStripItem = new ToolStripButton(game.Name);
                toolStripItem.Click += new EventHandler(toolStripItem_Click);
                newGameToolStripMenuItem.DropDownItems.Add(toolStripItem);
            }
        }

        private void Form1_Load(object sender, EventArgs e)        
        {
            _LoadMenuItems();
        }

        void toolStripItem_Click(object sender, EventArgs e)
        {
            MatchForm newMatchForm = new MatchForm(Skorer.IOC.Container.Resolve<IGameRepository>(),
                Skorer.IOC.Container.Resolve<IScorer>());                
            newMatchForm.StartMatch(((ToolStripButton)sender).Text);            
            newMatchForm.MdiParent = this;
            newMatchForm.Show();
        }

        
    }
}
