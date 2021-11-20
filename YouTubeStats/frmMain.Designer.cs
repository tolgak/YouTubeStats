
namespace YouTubeStats
{
  partial class frmMain
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      this.txtLog = new System.Windows.Forms.TextBox();
      this.popStatTools = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuHistory = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.bsVideo = new System.Windows.Forms.BindingSource(this.components);
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnOpenAppFolder = new System.Windows.Forms.Button();
      this.txtTotalViewCount = new System.Windows.Forms.TextBox();
      this.lblTotalViewCount = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtWait = new System.Windows.Forms.TextBox();
      this.chkTimerEnabled = new System.Windows.Forms.CheckBox();
      this.lblChannelId = new System.Windows.Forms.Label();
      this.txtChannelId = new System.Windows.Forms.TextBox();
      this.lblNow = new System.Windows.Forms.Label();
      this.txtSubscribers = new System.Windows.Forms.TextBox();
      this.lblSubscribers = new System.Windows.Forms.Label();
      this.btnRequest = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.txtPlayList = new System.Windows.Forms.TextBox();
      this.timerRequest = new System.Windows.Forms.Timer(this.components);
      this.tabs = new System.Windows.Forms.TabControl();
      this.tabLatestReading = new System.Windows.Forms.TabPage();
      this.grdStat = new System.Windows.Forms.DataGridView();
      this.tabHistory = new System.Windows.Forms.TabPage();
      this.grdHistory = new System.Windows.Forms.DataGridView();
      this.bsHistory = new System.Windows.Forms.BindingSource(this.components);
      this.popStatTools.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bsVideo)).BeginInit();
      this.panel1.SuspendLayout();
      this.tabs.SuspendLayout();
      this.tabLatestReading.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grdStat)).BeginInit();
      this.tabHistory.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bsHistory)).BeginInit();
      this.SuspendLayout();
      // 
      // txtLog
      // 
      this.txtLog.BackColor = System.Drawing.Color.Black;
      this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txtLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.txtLog.ForeColor = System.Drawing.Color.Lime;
      this.txtLog.Location = new System.Drawing.Point(2, 517);
      this.txtLog.Multiline = true;
      this.txtLog.Name = "txtLog";
      this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtLog.Size = new System.Drawing.Size(1323, 126);
      this.txtLog.TabIndex = 2;
      // 
      // popStatTools
      // 
      this.popStatTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHistory,
            this.mnuOpen});
      this.popStatTools.Name = "popStatTools";
      this.popStatTools.Size = new System.Drawing.Size(162, 48);
      // 
      // mnuHistory
      // 
      this.mnuHistory.Name = "mnuHistory";
      this.mnuHistory.Size = new System.Drawing.Size(161, 22);
      this.mnuHistory.Text = "History";
      this.mnuHistory.Click += new System.EventHandler(this.mnuHistory_Click);
      // 
      // mnuOpen
      // 
      this.mnuOpen.Name = "mnuOpen";
      this.mnuOpen.Size = new System.Drawing.Size(161, 22);
      this.mnuOpen.Text = "Open in browser";
      this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnOpenAppFolder);
      this.panel1.Controls.Add(this.txtTotalViewCount);
      this.panel1.Controls.Add(this.lblTotalViewCount);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.txtWait);
      this.panel1.Controls.Add(this.chkTimerEnabled);
      this.panel1.Controls.Add(this.lblChannelId);
      this.panel1.Controls.Add(this.txtChannelId);
      this.panel1.Controls.Add(this.lblNow);
      this.panel1.Controls.Add(this.txtSubscribers);
      this.panel1.Controls.Add(this.lblSubscribers);
      this.panel1.Controls.Add(this.btnRequest);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.txtPlayList);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(2, 2);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1323, 146);
      this.panel1.TabIndex = 0;
      // 
      // btnOpenAppFolder
      // 
      this.btnOpenAppFolder.AutoSize = true;
      this.btnOpenAppFolder.Location = new System.Drawing.Point(646, 13);
      this.btnOpenAppFolder.Name = "btnOpenAppFolder";
      this.btnOpenAppFolder.Size = new System.Drawing.Size(166, 25);
      this.btnOpenAppFolder.TabIndex = 20;
      this.btnOpenAppFolder.Text = "open app folder";
      this.btnOpenAppFolder.UseVisualStyleBackColor = true;
      this.btnOpenAppFolder.Click += new System.EventHandler(this.btnOpenAppFolder_Click);
      // 
      // txtTotalViewCount
      // 
      this.txtTotalViewCount.Location = new System.Drawing.Point(329, 111);
      this.txtTotalViewCount.Name = "txtTotalViewCount";
      this.txtTotalViewCount.Size = new System.Drawing.Size(69, 23);
      this.txtTotalViewCount.TabIndex = 19;
      this.txtTotalViewCount.TabStop = false;
      this.txtTotalViewCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // lblTotalViewCount
      // 
      this.lblTotalViewCount.AutoSize = true;
      this.lblTotalViewCount.Location = new System.Drawing.Point(230, 115);
      this.lblTotalViewCount.Name = "lblTotalViewCount";
      this.lblTotalViewCount.Size = new System.Drawing.Size(93, 15);
      this.lblTotalViewCount.TabIndex = 18;
      this.lblTotalViewCount.Text = "Total view count";
      this.lblTotalViewCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(440, 16);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(89, 15);
      this.label3.TabIndex = 17;
      this.label3.Text = "Minutes to wait";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtWait
      // 
      this.txtWait.Location = new System.Drawing.Point(537, 13);
      this.txtWait.Name = "txtWait";
      this.txtWait.Size = new System.Drawing.Size(53, 23);
      this.txtWait.TabIndex = 4;
      this.txtWait.Text = "30";
      this.txtWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // chkTimerEnabled
      // 
      this.chkTimerEnabled.AutoSize = true;
      this.chkTimerEnabled.Location = new System.Drawing.Point(442, 44);
      this.chkTimerEnabled.Name = "chkTimerEnabled";
      this.chkTimerEnabled.Size = new System.Drawing.Size(92, 19);
      this.chkTimerEnabled.TabIndex = 5;
      this.chkTimerEnabled.Text = "Enable timer";
      this.chkTimerEnabled.UseVisualStyleBackColor = true;
      this.chkTimerEnabled.Click += new System.EventHandler(this.chkTimerEnabled_Click);
      // 
      // lblChannelId
      // 
      this.lblChannelId.AutoSize = true;
      this.lblChannelId.Location = new System.Drawing.Point(17, 16);
      this.lblChannelId.Name = "lblChannelId";
      this.lblChannelId.Size = new System.Drawing.Size(64, 15);
      this.lblChannelId.TabIndex = 14;
      this.lblChannelId.Text = "Channel Id";
      // 
      // txtChannelId
      // 
      this.txtChannelId.Location = new System.Drawing.Point(93, 13);
      this.txtChannelId.Name = "txtChannelId";
      this.txtChannelId.Size = new System.Drawing.Size(305, 23);
      this.txtChannelId.TabIndex = 1;
      this.txtChannelId.TabStop = false;
      this.txtChannelId.Text = "UCOSQzjNlbmiSe4cxUCtAgpg";
      // 
      // lblNow
      // 
      this.lblNow.AutoSize = true;
      this.lblNow.Location = new System.Drawing.Point(440, 115);
      this.lblNow.Name = "lblNow";
      this.lblNow.Size = new System.Drawing.Size(82, 15);
      this.lblNow.TabIndex = 12;
      this.lblNow.Text = "no request yet";
      this.lblNow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtSubscribers
      // 
      this.txtSubscribers.Location = new System.Drawing.Point(93, 111);
      this.txtSubscribers.Name = "txtSubscribers";
      this.txtSubscribers.Size = new System.Drawing.Size(69, 23);
      this.txtSubscribers.TabIndex = 3;
      this.txtSubscribers.TabStop = false;
      this.txtSubscribers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // lblSubscribers
      // 
      this.lblSubscribers.AutoSize = true;
      this.lblSubscribers.Location = new System.Drawing.Point(17, 115);
      this.lblSubscribers.Name = "lblSubscribers";
      this.lblSubscribers.Size = new System.Drawing.Size(67, 15);
      this.lblSubscribers.TabIndex = 10;
      this.lblSubscribers.Text = "Subscribers";
      // 
      // btnRequest
      // 
      this.btnRequest.AutoSize = true;
      this.btnRequest.Location = new System.Drawing.Point(442, 69);
      this.btnRequest.Name = "btnRequest";
      this.btnRequest.Size = new System.Drawing.Size(166, 25);
      this.btnRequest.TabIndex = 6;
      this.btnRequest.Text = "request";
      this.btnRequest.UseVisualStyleBackColor = true;
      this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(17, 45);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(60, 15);
      this.label2.TabIndex = 8;
      this.label2.Text = "PlayList Id";
      // 
      // txtPlayList
      // 
      this.txtPlayList.Location = new System.Drawing.Point(93, 42);
      this.txtPlayList.Name = "txtPlayList";
      this.txtPlayList.Size = new System.Drawing.Size(305, 23);
      this.txtPlayList.TabIndex = 2;
      this.txtPlayList.TabStop = false;
      this.txtPlayList.Text = "PLaza8H91nF2itBoChbZetsgGeX3bs3qO5";
      // 
      // timerRequest
      // 
      this.timerRequest.Tick += new System.EventHandler(this.timerRequest_Tick);
      // 
      // tabs
      // 
      this.tabs.Controls.Add(this.tabLatestReading);
      this.tabs.Controls.Add(this.tabHistory);
      this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabs.Location = new System.Drawing.Point(2, 148);
      this.tabs.Name = "tabs";
      this.tabs.SelectedIndex = 0;
      this.tabs.Size = new System.Drawing.Size(1323, 369);
      this.tabs.TabIndex = 22;
      // 
      // tabLatestReading
      // 
      this.tabLatestReading.AutoScroll = true;
      this.tabLatestReading.Controls.Add(this.grdStat);
      this.tabLatestReading.Location = new System.Drawing.Point(4, 24);
      this.tabLatestReading.Name = "tabLatestReading";
      this.tabLatestReading.Padding = new System.Windows.Forms.Padding(3);
      this.tabLatestReading.Size = new System.Drawing.Size(1315, 341);
      this.tabLatestReading.TabIndex = 0;
      this.tabLatestReading.Text = "Latest reading";
      this.tabLatestReading.UseVisualStyleBackColor = true;
      // 
      // grdStat
      // 
      this.grdStat.AllowUserToAddRows = false;
      this.grdStat.AllowUserToDeleteRows = false;
      this.grdStat.AllowUserToOrderColumns = true;
      this.grdStat.AllowUserToResizeRows = false;
      this.grdStat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.grdStat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.grdStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdStat.ContextMenuStrip = this.popStatTools;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.grdStat.DefaultCellStyle = dataGridViewCellStyle2;
      this.grdStat.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grdStat.Location = new System.Drawing.Point(3, 3);
      this.grdStat.Name = "grdStat";
      this.grdStat.ReadOnly = true;
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.grdStat.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
      this.grdStat.RowHeadersVisible = false;
      this.grdStat.RowTemplate.Height = 25;
      this.grdStat.Size = new System.Drawing.Size(1309, 335);
      this.grdStat.TabIndex = 2;
      this.grdStat.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdStat_CellFormatting);
      this.grdStat.DoubleClick += new System.EventHandler(this.grdStat_DoubleClick);
      // 
      // tabHistory
      // 
      this.tabHistory.Controls.Add(this.grdHistory);
      this.tabHistory.Location = new System.Drawing.Point(4, 24);
      this.tabHistory.Name = "tabHistory";
      this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
      this.tabHistory.Size = new System.Drawing.Size(1315, 341);
      this.tabHistory.TabIndex = 1;
      this.tabHistory.Text = "History";
      this.tabHistory.UseVisualStyleBackColor = true;
      // 
      // grdHistory
      // 
      this.grdHistory.AllowUserToAddRows = false;
      this.grdHistory.AllowUserToDeleteRows = false;
      this.grdHistory.AllowUserToOrderColumns = true;
      this.grdHistory.AllowUserToResizeRows = false;
      this.grdHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.grdHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
      this.grdHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdHistory.ContextMenuStrip = this.popStatTools;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.grdHistory.DefaultCellStyle = dataGridViewCellStyle5;
      this.grdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grdHistory.Location = new System.Drawing.Point(3, 3);
      this.grdHistory.Name = "grdHistory";
      this.grdHistory.ReadOnly = true;
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.grdHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
      this.grdHistory.RowHeadersVisible = false;
      this.grdHistory.RowTemplate.Height = 25;
      this.grdHistory.Size = new System.Drawing.Size(1309, 335);
      this.grdHistory.TabIndex = 3;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1327, 645);
      this.Controls.Add(this.tabs);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.txtLog);
      this.Name = "frmMain";
      this.Padding = new System.Windows.Forms.Padding(2);
      this.Text = "YouTube Statistics Viewer";
      this.popStatTools.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.bsVideo)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.tabs.ResumeLayout(false);
      this.tabLatestReading.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grdStat)).EndInit();
      this.tabHistory.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bsHistory)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox txtLog;
    private System.Windows.Forms.BindingSource bsVideo;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnRequest;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtPlayList;
    private System.Windows.Forms.TextBox txtSubscribers;
    private System.Windows.Forms.Label lblSubscribers;
    private System.Windows.Forms.Label lblNow;
    private System.Windows.Forms.Label lblChannelId;
    private System.Windows.Forms.TextBox txtChannelId;
    private System.Windows.Forms.Timer timerRequest;
    private System.Windows.Forms.CheckBox chkTimerEnabled;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtWait;
    private System.Windows.Forms.ContextMenuStrip popStatTools;
    private System.Windows.Forms.ToolStripMenuItem mnuHistory;
    private System.Windows.Forms.ToolStripMenuItem mnuOpen;
    private System.Windows.Forms.TextBox txtTotalViewCount;
    private System.Windows.Forms.Label lblTotalViewCount;
    private System.Windows.Forms.Button btnOpenAppFolder;
    private System.Windows.Forms.TabControl tabs;
    private System.Windows.Forms.TabPage tabLatestReading;
    private System.Windows.Forms.DataGridView grdStat;
    private System.Windows.Forms.TabPage tabHistory;
    private System.Windows.Forms.BindingSource bsHistory;
    private System.Windows.Forms.DataGridView grdHistory;
  }
}

