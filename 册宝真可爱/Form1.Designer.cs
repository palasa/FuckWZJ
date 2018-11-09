using 册宝真可爱.Entitys;

namespace 册宝真可爱
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.gbBuyTicket = new System.Windows.Forms.GroupBox();
            this.lblDetail = new System.Windows.Forms.Label();
            this.chkAutoRepeat = new System.Windows.Forms.CheckBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.NumericUpDown();
            this.panelTicketType = new System.Windows.Forms.Panel();
            this.radVip = new System.Windows.Forms.RadioButton();
            this.radNormal = new System.Windows.Forms.RadioButton();
            this.radStand = new System.Windows.Forms.RadioButton();
            this.btnBuyOne = new System.Windows.Forms.Button();
            this.ddlGroup = new System.Windows.Forms.ComboBox();
            this.ddlTicket = new System.Windows.Forms.ComboBox();
            this.lblTicket = new System.Windows.Forms.Label();
            this.timerAutoBuyAtEight = new System.Windows.Forms.Timer(this.components);
            this.gbGoods = new System.Windows.Forms.GroupBox();
            this.btnBuyGoods = new System.Windows.Forms.Button();
            this.lblGoodsId = new System.Windows.Forms.Label();
            this.txtGoodsId = new System.Windows.Forms.TextBox();
            this.lblTimeToEight = new System.Windows.Forms.Label();
            this.chkTimeUpAutoBuy = new System.Windows.Forms.CheckBox();
            this.timerAutoBuyRepeatfully = new System.Windows.Forms.Timer(this.components);
            this.timerSubRequest = new System.Windows.Forms.Timer(this.components);
            this.timerSyncDateTime = new System.Windows.Forms.Timer(this.components);
            this.lblTimeSpan = new System.Windows.Forms.Label();
            this.gbLogin.SuspendLayout();
            this.gbBuyTicket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).BeginInit();
            this.panelTicketType.SuspendLayout();
            this.gbGoods.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.btnLogin);
            this.gbLogin.Controls.Add(this.txtPassword);
            this.gbLogin.Controls.Add(this.lblPassword);
            this.gbLogin.Controls.Add(this.txtUsername);
            this.gbLogin.Controls.Add(this.lblUsername);
            this.gbLogin.Location = new System.Drawing.Point(12, 99);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(1359, 103);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "登录";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(857, 36);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(158, 53);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(569, 47);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 35);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "w7ihps8Y";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(456, 47);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(82, 24);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "密码：";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(173, 44);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 35);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "chongchong";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(60, 44);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(106, 24);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "用户名：";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(12, 47);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(82, 24);
            this.lblGroup.TabIndex = 2;
            this.lblGroup.Text = "组合：";
            // 
            // gbBuyTicket
            // 
            this.gbBuyTicket.Controls.Add(this.lblDetail);
            this.gbBuyTicket.Controls.Add(this.chkAutoRepeat);
            this.gbBuyTicket.Controls.Add(this.lblNumber);
            this.gbBuyTicket.Controls.Add(this.txtNumber);
            this.gbBuyTicket.Controls.Add(this.panelTicketType);
            this.gbBuyTicket.Controls.Add(this.btnBuyOne);
            this.gbBuyTicket.Controls.Add(this.ddlGroup);
            this.gbBuyTicket.Controls.Add(this.ddlTicket);
            this.gbBuyTicket.Controls.Add(this.lblTicket);
            this.gbBuyTicket.Controls.Add(this.lblGroup);
            this.gbBuyTicket.Location = new System.Drawing.Point(10, 247);
            this.gbBuyTicket.Name = "gbBuyTicket";
            this.gbBuyTicket.Size = new System.Drawing.Size(1361, 477);
            this.gbBuyTicket.TabIndex = 3;
            this.gbBuyTicket.TabStop = false;
            this.gbBuyTicket.Text = "购票";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Location = new System.Drawing.Point(16, 136);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(0, 24);
            this.lblDetail.TabIndex = 14;
            // 
            // chkAutoRepeat
            // 
            this.chkAutoRepeat.AutoSize = true;
            this.chkAutoRepeat.Location = new System.Drawing.Point(1111, 105);
            this.chkAutoRepeat.Name = "chkAutoRepeat";
            this.chkAutoRepeat.Size = new System.Drawing.Size(234, 28);
            this.chkAutoRepeat.TabIndex = 13;
            this.chkAutoRepeat.Text = "是否自动重复购买";
            this.chkAutoRepeat.UseVisualStyleBackColor = true;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(1028, 43);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(82, 24);
            this.lblNumber.TabIndex = 12;
            this.lblNumber.Text = "数量：";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(1111, 38);
            this.txtNumber.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.txtNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(74, 35);
            this.txtNumber.TabIndex = 11;
            this.txtNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panelTicketType
            // 
            this.panelTicketType.Controls.Add(this.radVip);
            this.panelTicketType.Controls.Add(this.radNormal);
            this.panelTicketType.Controls.Add(this.radStand);
            this.panelTicketType.Location = new System.Drawing.Point(791, 22);
            this.panelTicketType.Name = "panelTicketType";
            this.panelTicketType.Size = new System.Drawing.Size(229, 61);
            this.panelTicketType.TabIndex = 10;
            // 
            // radVip
            // 
            this.radVip.AutoSize = true;
            this.radVip.Checked = true;
            this.radVip.Location = new System.Drawing.Point(16, 20);
            this.radVip.Name = "radVip";
            this.radVip.Size = new System.Drawing.Size(53, 28);
            this.radVip.TabIndex = 7;
            this.radVip.TabStop = true;
            this.radVip.Text = "V";
            this.radVip.UseVisualStyleBackColor = true;
            // 
            // radNormal
            // 
            this.radNormal.AutoSize = true;
            this.radNormal.Location = new System.Drawing.Point(146, 21);
            this.radNormal.Name = "radNormal";
            this.radNormal.Size = new System.Drawing.Size(65, 28);
            this.radNormal.TabIndex = 9;
            this.radNormal.Text = "普";
            this.radNormal.UseVisualStyleBackColor = true;
            // 
            // radStand
            // 
            this.radStand.AutoSize = true;
            this.radStand.Location = new System.Drawing.Point(75, 19);
            this.radStand.Name = "radStand";
            this.radStand.Size = new System.Drawing.Size(65, 28);
            this.radStand.TabIndex = 8;
            this.radStand.Text = "站";
            this.radStand.UseVisualStyleBackColor = true;
            // 
            // btnBuyOne
            // 
            this.btnBuyOne.Location = new System.Drawing.Point(1202, 31);
            this.btnBuyOne.Name = "btnBuyOne";
            this.btnBuyOne.Size = new System.Drawing.Size(141, 50);
            this.btnBuyOne.TabIndex = 6;
            this.btnBuyOne.Text = "立即购票";
            this.btnBuyOne.UseVisualStyleBackColor = true;
            this.btnBuyOne.Click += new System.EventHandler(this.btnBuyOne_Click);
            // 
            // ddlGroup
            // 
            this.ddlGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ddlGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGroup.FormattingEnabled = true;
            this.ddlGroup.Location = new System.Drawing.Point(87, 44);
            this.ddlGroup.Name = "ddlGroup";
            this.ddlGroup.Size = new System.Drawing.Size(129, 36);
            this.ddlGroup.TabIndex = 5;
            this.ddlGroup.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ddlGroup_DrawItem);
            this.ddlGroup.SelectedIndexChanged += new System.EventHandler(this.ddlGroup_SelectedIndexChanged);
            // 
            // ddlTicket
            // 
            this.ddlTicket.DisplayMember = "Name";
            this.ddlTicket.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ddlTicket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTicket.FormattingEnabled = true;
            this.ddlTicket.Location = new System.Drawing.Point(303, 39);
            this.ddlTicket.Name = "ddlTicket";
            this.ddlTicket.Size = new System.Drawing.Size(479, 36);
            this.ddlTicket.TabIndex = 4;
            this.ddlTicket.ValueMember = "Id";
            this.ddlTicket.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ddlTicket_DrawItem);
            this.ddlTicket.SelectedIndexChanged += new System.EventHandler(this.ddlTicket_SelectedIndexChanged);
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.Location = new System.Drawing.Point(231, 47);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(82, 24);
            this.lblTicket.TabIndex = 3;
            this.lblTicket.Text = "门票：";
            // 
            // timerAutoBuyAtEight
            // 
            this.timerAutoBuyAtEight.Interval = 1000;
            this.timerAutoBuyAtEight.Tick += new System.EventHandler(this.timerAutoBuyAtEight_Tick);
            // 
            // gbGoods
            // 
            this.gbGoods.Controls.Add(this.btnBuyGoods);
            this.gbGoods.Controls.Add(this.lblGoodsId);
            this.gbGoods.Controls.Add(this.txtGoodsId);
            this.gbGoods.Location = new System.Drawing.Point(12, 747);
            this.gbGoods.Name = "gbGoods";
            this.gbGoods.Size = new System.Drawing.Size(1359, 125);
            this.gbGoods.TabIndex = 4;
            this.gbGoods.TabStop = false;
            this.gbGoods.Text = "购商品/冷餐";
            // 
            // btnBuyGoods
            // 
            this.btnBuyGoods.Enabled = false;
            this.btnBuyGoods.Location = new System.Drawing.Point(1141, 38);
            this.btnBuyGoods.Name = "btnBuyGoods";
            this.btnBuyGoods.Size = new System.Drawing.Size(130, 46);
            this.btnBuyGoods.TabIndex = 2;
            this.btnBuyGoods.Text = "直接购买";
            this.btnBuyGoods.UseVisualStyleBackColor = true;
            this.btnBuyGoods.Click += new System.EventHandler(this.btnBuyGoods_Click);
            // 
            // lblGoodsId
            // 
            this.lblGoodsId.AutoSize = true;
            this.lblGoodsId.Location = new System.Drawing.Point(25, 49);
            this.lblGoodsId.Name = "lblGoodsId";
            this.lblGoodsId.Size = new System.Drawing.Size(346, 24);
            this.lblGoodsId.TabIndex = 1;
            this.lblGoodsId.Text = "商品页面网址或最后四位编号：";
            // 
            // txtGoodsId
            // 
            this.txtGoodsId.Location = new System.Drawing.Point(396, 46);
            this.txtGoodsId.Name = "txtGoodsId";
            this.txtGoodsId.Size = new System.Drawing.Size(722, 35);
            this.txtGoodsId.TabIndex = 0;
            // 
            // lblTimeToEight
            // 
            this.lblTimeToEight.AutoSize = true;
            this.lblTimeToEight.ForeColor = System.Drawing.Color.Tomato;
            this.lblTimeToEight.Location = new System.Drawing.Point(278, 35);
            this.lblTimeToEight.Name = "lblTimeToEight";
            this.lblTimeToEight.Size = new System.Drawing.Size(106, 24);
            this.lblTimeToEight.TabIndex = 15;
            this.lblTimeToEight.Text = "00:00:00";
            // 
            // chkTimeUpAutoBuy
            // 
            this.chkTimeUpAutoBuy.AutoSize = true;
            this.chkTimeUpAutoBuy.Location = new System.Drawing.Point(41, 35);
            this.chkTimeUpAutoBuy.Name = "chkTimeUpAutoBuy";
            this.chkTimeUpAutoBuy.Size = new System.Drawing.Size(198, 28);
            this.chkTimeUpAutoBuy.TabIndex = 14;
            this.chkTimeUpAutoBuy.Text = "到8点自动购票";
            this.chkTimeUpAutoBuy.UseVisualStyleBackColor = true;
            // 
            // timerAutoBuyRepeatfully
            // 
            this.timerAutoBuyRepeatfully.Interval = 10500;
            this.timerAutoBuyRepeatfully.Tick += new System.EventHandler(this.timerAutoBuyRepeatfully_Tick);
            // 
            // timerSubRequest
            // 
            this.timerSubRequest.Interval = 1000;
            this.timerSubRequest.Tick += new System.EventHandler(this.timerSubRequest_Tick);
            // 
            // timerSyncDateTime
            // 
            this.timerSyncDateTime.Interval = 10000;
            this.timerSyncDateTime.Tick += new System.EventHandler(this.timerSyncDateTime_Tick);
            // 
            // lblTimeSpan
            // 
            this.lblTimeSpan.AutoSize = true;
            this.lblTimeSpan.Location = new System.Drawing.Point(526, 35);
            this.lblTimeSpan.Name = "lblTimeSpan";
            this.lblTimeSpan.Size = new System.Drawing.Size(82, 24);
            this.lblTimeSpan.TabIndex = 16;
            this.lblTimeSpan.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 893);
            this.Controls.Add(this.lblTimeSpan);
            this.Controls.Add(this.lblTimeToEight);
            this.Controls.Add(this.gbGoods);
            this.Controls.Add(this.chkTimeUpAutoBuy);
            this.Controls.Add(this.gbBuyTicket);
            this.Controls.Add(this.gbLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbBuyTicket.ResumeLayout(false);
            this.gbBuyTicket.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).EndInit();
            this.panelTicketType.ResumeLayout(false);
            this.panelTicketType.PerformLayout();
            this.gbGoods.ResumeLayout(false);
            this.gbGoods.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.GroupBox gbBuyTicket;
        private System.Windows.Forms.ComboBox ddlTicket;
        private System.Windows.Forms.Label lblTicket;
        private System.Windows.Forms.ComboBox ddlGroup;
        private System.Windows.Forms.Button btnBuyOne;
        private System.Windows.Forms.Panel panelTicketType;
        private System.Windows.Forms.RadioButton radVip;
        private System.Windows.Forms.RadioButton radNormal;
        private System.Windows.Forms.RadioButton radStand;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.NumericUpDown txtNumber;
        private System.Windows.Forms.Timer timerAutoBuyAtEight;
        private System.Windows.Forms.GroupBox gbGoods;
        private System.Windows.Forms.Button btnBuyGoods;
        private System.Windows.Forms.Label lblGoodsId;
        private System.Windows.Forms.TextBox txtGoodsId;
        private System.Windows.Forms.Label lblTimeToEight;
        private System.Windows.Forms.CheckBox chkTimeUpAutoBuy;
        private System.Windows.Forms.CheckBox chkAutoRepeat;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Timer timerAutoBuyRepeatfully;
        private System.Windows.Forms.Timer timerSubRequest;
        private System.Windows.Forms.Timer timerSyncDateTime;
        private System.Windows.Forms.Label lblTimeSpan;
    }
}

