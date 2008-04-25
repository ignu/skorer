namespace Skorer.WinForms
{
    partial class MatchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.PlayerList = new System.Windows.Forms.ComboBox();
            this.AddEventButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EventList = new System.Windows.Forms.ComboBox();
            this.EventGrid = new System.Windows.Forms.DataGridView();
            this.PlayerScoreGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPlayerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchEventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gameEventDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roundDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerScoreGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchEventBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QuantityTextBox);
            this.groupBox1.Controls.Add(this.PlayerList);
            this.groupBox1.Controls.Add(this.AddEventButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.EventList);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Event";
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Location = new System.Drawing.Point(398, 54);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(43, 20);
            this.QuantityTextBox.TabIndex = 4;
            // 
            // PlayerList
            // 
            this.PlayerList.FormattingEnabled = true;
            this.PlayerList.Location = new System.Drawing.Point(213, 54);
            this.PlayerList.Name = "PlayerList";
            this.PlayerList.Size = new System.Drawing.Size(178, 21);
            this.PlayerList.TabIndex = 3;
            this.PlayerList.SelectedIndexChanged += new System.EventHandler(this.PlayerList_SelectedIndexChanged);
            // 
            // AddEventButton
            // 
            this.AddEventButton.Location = new System.Drawing.Point(447, 51);
            this.AddEventButton.Name = "AddEventButton";
            this.AddEventButton.Size = new System.Drawing.Size(75, 23);
            this.AddEventButton.TabIndex = 2;
            this.AddEventButton.Text = "Add Event";
            this.AddEventButton.UseVisualStyleBackColor = true;
            this.AddEventButton.Click += new System.EventHandler(this.AddEventButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Event ";
            // 
            // EventList
            // 
            this.EventList.FormattingEnabled = true;
            this.EventList.Location = new System.Drawing.Point(6, 53);
            this.EventList.Name = "EventList";
            this.EventList.Size = new System.Drawing.Size(201, 21);
            this.EventList.TabIndex = 0;
            this.EventList.SelectedIndexChanged += new System.EventHandler(this.EventList_SelectedIndexChanged);
            // 
            // EventGrid
            // 
            this.EventGrid.AutoGenerateColumns = false;
            this.EventGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EventGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gameEventDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.roundDataGridViewTextBoxColumn,
            this.scoreDataGridViewTextBoxColumn,
            this.playerDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn,
            this.DeleteButton});
            this.EventGrid.DataSource = this.matchEventBindingSource;
            this.EventGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EventGrid.Location = new System.Drawing.Point(0, 148);
            this.EventGrid.Name = "EventGrid";
            this.EventGrid.Size = new System.Drawing.Size(866, 310);
            this.EventGrid.TabIndex = 4;
            this.EventGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EventGrid_CellContentClick);
            // 
            // PlayerScoreGrid
            // 
            this.PlayerScoreGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlayerScoreGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.PlayerScoreGrid.Location = new System.Drawing.Point(581, 24);
            this.PlayerScoreGrid.Name = "PlayerScoreGrid";
            this.PlayerScoreGrid.Size = new System.Drawing.Size(285, 124);
            this.PlayerScoreGrid.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlayerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newPlayerToolStripMenuItem
            // 
            this.newPlayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlayerToolStripMenuItem1,
            this.saveToolStripMenuItem});
            this.newPlayerToolStripMenuItem.Name = "newPlayerToolStripMenuItem";
            this.newPlayerToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.newPlayerToolStripMenuItem.Text = "Match";
            // 
            // newPlayerToolStripMenuItem1
            // 
            this.newPlayerToolStripMenuItem1.Name = "newPlayerToolStripMenuItem1";
            this.newPlayerToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.newPlayerToolStripMenuItem1.Text = "New Player";
            this.newPlayerToolStripMenuItem1.Click += new System.EventHandler(this.newPlayerToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // matchEventBindingSource
            // 
            this.matchEventBindingSource.DataSource = typeof(Skorer.Core.MatchEvent);
            // 
            // gameEventDataGridViewTextBoxColumn
            // 
            this.gameEventDataGridViewTextBoxColumn.DataPropertyName = "GameEvent";
            this.gameEventDataGridViewTextBoxColumn.HeaderText = "GameEvent";
            this.gameEventDataGridViewTextBoxColumn.Name = "gameEventDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // roundDataGridViewTextBoxColumn
            // 
            this.roundDataGridViewTextBoxColumn.DataPropertyName = "Round";
            this.roundDataGridViewTextBoxColumn.HeaderText = "Round";
            this.roundDataGridViewTextBoxColumn.Name = "roundDataGridViewTextBoxColumn";
            // 
            // scoreDataGridViewTextBoxColumn
            // 
            this.scoreDataGridViewTextBoxColumn.DataPropertyName = "Score";
            this.scoreDataGridViewTextBoxColumn.HeaderText = "Score";
            this.scoreDataGridViewTextBoxColumn.Name = "scoreDataGridViewTextBoxColumn";
            // 
            // playerDataGridViewTextBoxColumn
            // 
            this.playerDataGridViewTextBoxColumn.DataPropertyName = "Player";
            this.playerDataGridViewTextBoxColumn.HeaderText = "Player";
            this.playerDataGridViewTextBoxColumn.Name = "playerDataGridViewTextBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // DeleteButton
            // 
            this.DeleteButton.HeaderText = "Delete";
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Text = "Delete";
            // 
            // MatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 458);
            this.Controls.Add(this.PlayerScoreGrid);
            this.Controls.Add(this.EventGrid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MatchForm";
            this.Text = "MatchForm";
            this.Load += new System.EventHandler(this.MatchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerScoreGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchEventBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox EventList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddEventButton;
        private System.Windows.Forms.ComboBox PlayerList;
        private System.Windows.Forms.DataGridView EventGrid;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.DataGridView PlayerScoreGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPlayerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn gameEventDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roundDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
        private System.Windows.Forms.BindingSource matchEventBindingSource;
    }
}