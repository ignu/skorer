using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Skorer.Core;
using Skorer.DataAccess;

namespace Skorer.WinForms
{
    public interface IAddPlayerView
    {
        
    }
    
    public partial class PlayerAdd : Form, IAddPlayerView
    {
        IPlayerRepository _PlayerRepository;

        public PlayerAdd(IPlayerRepository playerRepository)
        {
            _PlayerRepository = playerRepository;
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PlayerAdd_Load(object sender, EventArgs e)
        {
            playerListBox.DataSource = _PlayerRepository.GetAll();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            playerListBox.DataSource = _PlayerRepository.Find(firstNameTextBox.Text, lastNameTextBox.Text);
        }
    }
}
