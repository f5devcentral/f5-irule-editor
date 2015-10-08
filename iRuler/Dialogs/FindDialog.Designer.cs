namespace iRuler.Dialogs
{
    partial class FindDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_SearchString = new System.Windows.Forms.TextBox();
            this.checkBox_MatchWholeWord = new System.Windows.Forms.CheckBox();
            this.checkBox_MatchCase = new System.Windows.Forms.CheckBox();
            this.checkBox_Regex = new System.Windows.Forms.CheckBox();
            this.checkBox_WrapAround = new System.Windows.Forms.CheckBox();
            this.checkBox_TransformBackslash = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Down = new System.Windows.Forms.RadioButton();
            this.radioButton_Up = new System.Windows.Forms.RadioButton();
            this.button_FindNext = new System.Windows.Forms.Button();
            this.button_MarkAll = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find what:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_SearchString
            // 
            this.textBox_SearchString.Location = new System.Drawing.Point(74, 11);
            this.textBox_SearchString.Name = "textBox_SearchString";
            this.textBox_SearchString.Size = new System.Drawing.Size(234, 21);
            this.textBox_SearchString.TabIndex = 1;
            this.textBox_SearchString.TextChanged += new System.EventHandler(this.textBox_SearchString_TextChanged);
            // 
            // checkBox_MatchWholeWord
            // 
            this.checkBox_MatchWholeWord.AutoSize = true;
            this.checkBox_MatchWholeWord.Location = new System.Drawing.Point(15, 41);
            this.checkBox_MatchWholeWord.Name = "checkBox_MatchWholeWord";
            this.checkBox_MatchWholeWord.Size = new System.Drawing.Size(136, 17);
            this.checkBox_MatchWholeWord.TabIndex = 2;
            this.checkBox_MatchWholeWord.Text = "Match whole word only";
            this.checkBox_MatchWholeWord.UseVisualStyleBackColor = true;
            this.checkBox_MatchWholeWord.CheckedChanged += new System.EventHandler(this.checkBox_MatchWholeWord_CheckedChanged);
            // 
            // checkBox_MatchCase
            // 
            this.checkBox_MatchCase.AutoSize = true;
            this.checkBox_MatchCase.Location = new System.Drawing.Point(15, 64);
            this.checkBox_MatchCase.Name = "checkBox_MatchCase";
            this.checkBox_MatchCase.Size = new System.Drawing.Size(80, 17);
            this.checkBox_MatchCase.TabIndex = 3;
            this.checkBox_MatchCase.Text = "Match case";
            this.checkBox_MatchCase.UseVisualStyleBackColor = true;
            this.checkBox_MatchCase.CheckedChanged += new System.EventHandler(this.checkBox_MatchCase_CheckedChanged);
            // 
            // checkBox_Regex
            // 
            this.checkBox_Regex.AutoSize = true;
            this.checkBox_Regex.Location = new System.Drawing.Point(15, 87);
            this.checkBox_Regex.Name = "checkBox_Regex";
            this.checkBox_Regex.Size = new System.Drawing.Size(118, 17);
            this.checkBox_Regex.TabIndex = 4;
            this.checkBox_Regex.Text = "Regular expression";
            this.checkBox_Regex.UseVisualStyleBackColor = true;
            this.checkBox_Regex.CheckedChanged += new System.EventHandler(this.checkBox_Regex_CheckedChanged);
            // 
            // checkBox_WrapAround
            // 
            this.checkBox_WrapAround.AutoSize = true;
            this.checkBox_WrapAround.Checked = true;
            this.checkBox_WrapAround.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_WrapAround.Location = new System.Drawing.Point(15, 110);
            this.checkBox_WrapAround.Name = "checkBox_WrapAround";
            this.checkBox_WrapAround.Size = new System.Drawing.Size(89, 17);
            this.checkBox_WrapAround.TabIndex = 5;
            this.checkBox_WrapAround.Text = "Wrap around";
            this.checkBox_WrapAround.UseVisualStyleBackColor = true;
            this.checkBox_WrapAround.CheckedChanged += new System.EventHandler(this.checkBox_WrapAround_CheckedChanged);
            // 
            // checkBox_TransformBackslash
            // 
            this.checkBox_TransformBackslash.AutoSize = true;
            this.checkBox_TransformBackslash.Location = new System.Drawing.Point(124, 110);
            this.checkBox_TransformBackslash.Name = "checkBox_TransformBackslash";
            this.checkBox_TransformBackslash.Size = new System.Drawing.Size(184, 17);
            this.checkBox_TransformBackslash.TabIndex = 6;
            this.checkBox_TransformBackslash.Text = "Transform backslash expressions";
            this.checkBox_TransformBackslash.UseVisualStyleBackColor = true;
            this.checkBox_TransformBackslash.Visible = false;
            this.checkBox_TransformBackslash.CheckedChanged += new System.EventHandler(this.checkBox_TransformBackslash_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_Down);
            this.groupBox1.Controls.Add(this.radioButton_Up);
            this.groupBox1.Location = new System.Drawing.Point(209, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 63);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direction";
            // 
            // radioButton_Down
            // 
            this.radioButton_Down.AutoSize = true;
            this.radioButton_Down.Location = new System.Drawing.Point(6, 42);
            this.radioButton_Down.Name = "radioButton_Down";
            this.radioButton_Down.Size = new System.Drawing.Size(52, 17);
            this.radioButton_Down.TabIndex = 1;
            this.radioButton_Down.TabStop = true;
            this.radioButton_Down.Text = "Down";
            this.radioButton_Down.UseVisualStyleBackColor = true;
            // 
            // radioButton_Up
            // 
            this.radioButton_Up.AutoSize = true;
            this.radioButton_Up.Location = new System.Drawing.Point(6, 19);
            this.radioButton_Up.Name = "radioButton_Up";
            this.radioButton_Up.Size = new System.Drawing.Size(38, 17);
            this.radioButton_Up.TabIndex = 0;
            this.radioButton_Up.TabStop = true;
            this.radioButton_Up.Text = "Up";
            this.radioButton_Up.UseVisualStyleBackColor = true;
            // 
            // button_FindNext
            // 
            this.button_FindNext.Location = new System.Drawing.Point(327, 14);
            this.button_FindNext.Name = "button_FindNext";
            this.button_FindNext.Size = new System.Drawing.Size(75, 23);
            this.button_FindNext.TabIndex = 8;
            this.button_FindNext.Text = "Find Next";
            this.button_FindNext.UseVisualStyleBackColor = true;
            this.button_FindNext.Click += new System.EventHandler(this.button_FindNext_Click);
            // 
            // button_MarkAll
            // 
            this.button_MarkAll.Location = new System.Drawing.Point(327, 41);
            this.button_MarkAll.Name = "button_MarkAll";
            this.button_MarkAll.Size = new System.Drawing.Size(75, 23);
            this.button_MarkAll.TabIndex = 9;
            this.button_MarkAll.Text = "Mark All";
            this.button_MarkAll.UseVisualStyleBackColor = true;
            this.button_MarkAll.Click += new System.EventHandler(this.button_MarkAll_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(327, 70);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 10;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // FindDialog
            // 
            this.AcceptButton = this.button_FindNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(414, 137);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_MarkAll);
            this.Controls.Add(this.button_FindNext);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox_TransformBackslash);
            this.Controls.Add(this.checkBox_WrapAround);
            this.Controls.Add(this.checkBox_Regex);
            this.Controls.Add(this.checkBox_MatchCase);
            this.Controls.Add(this.checkBox_MatchWholeWord);
            this.Controls.Add(this.textBox_SearchString);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.Load += new System.EventHandler(this.FindDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_SearchString;
        private System.Windows.Forms.CheckBox checkBox_MatchWholeWord;
        private System.Windows.Forms.CheckBox checkBox_MatchCase;
        private System.Windows.Forms.CheckBox checkBox_Regex;
        private System.Windows.Forms.CheckBox checkBox_WrapAround;
        private System.Windows.Forms.CheckBox checkBox_TransformBackslash;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_Down;
        private System.Windows.Forms.RadioButton radioButton_Up;
        private System.Windows.Forms.Button button_FindNext;
        private System.Windows.Forms.Button button_MarkAll;
        private System.Windows.Forms.Button button_Cancel;
    }
}