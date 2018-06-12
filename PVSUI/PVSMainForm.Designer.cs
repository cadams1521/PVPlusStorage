using System;

namespace PVSUI
{
    partial class PVSMainForm
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
            this.grpObjects = new System.Windows.Forms.GroupBox();
            this.lblDeserialize = new System.Windows.Forms.Label();
            this.butDesScheduleResponseLC = new System.Windows.Forms.Button();
            this.butDesScheduleRequestCL = new System.Windows.Forms.Button();
            this.lblSerialize = new System.Windows.Forms.Label();
            this.butSerScheduleResponseLC = new System.Windows.Forms.Button();
            this.butSerScheduleRequestCL = new System.Windows.Forms.Button();
            this.grpHMAC = new System.Windows.Forms.GroupBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblPost = new System.Windows.Forms.Label();
            this.butPostScheduleRequestCL = new System.Windows.Forms.Button();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.txtOutputText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butKeyAdd = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.grpObjects.SuspendLayout();
            this.grpHMAC.SuspendLayout();
            this.grpOutput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpObjects
            // 
            this.grpObjects.Controls.Add(this.lblDeserialize);
            this.grpObjects.Controls.Add(this.butDesScheduleResponseLC);
            this.grpObjects.Controls.Add(this.butDesScheduleRequestCL);
            this.grpObjects.Controls.Add(this.lblSerialize);
            this.grpObjects.Controls.Add(this.butSerScheduleResponseLC);
            this.grpObjects.Controls.Add(this.butSerScheduleRequestCL);
            this.grpObjects.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpObjects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.grpObjects.Location = new System.Drawing.Point(12, 12);
            this.grpObjects.Name = "grpObjects";
            this.grpObjects.Size = new System.Drawing.Size(488, 178);
            this.grpObjects.TabIndex = 0;
            this.grpObjects.TabStop = false;
            this.grpObjects.Text = "Objects";
            // 
            // lblDeserialize
            // 
            this.lblDeserialize.AutoSize = true;
            this.lblDeserialize.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeserialize.Location = new System.Drawing.Point(269, 42);
            this.lblDeserialize.Name = "lblDeserialize";
            this.lblDeserialize.Size = new System.Drawing.Size(170, 15);
            this.lblDeserialize.TabIndex = 11;
            this.lblDeserialize.Text = "Deserialize and send to Output";
            // 
            // butDesScheduleResponseLC
            // 
            this.butDesScheduleResponseLC.BackColor = System.Drawing.Color.White;
            this.butDesScheduleResponseLC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDesScheduleResponseLC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.butDesScheduleResponseLC.Location = new System.Drawing.Point(263, 116);
            this.butDesScheduleResponseLC.Name = "butDesScheduleResponseLC";
            this.butDesScheduleResponseLC.Size = new System.Drawing.Size(189, 41);
            this.butDesScheduleResponseLC.TabIndex = 9;
            this.butDesScheduleResponseLC.Text = "ScheduleResponseLC";
            this.butDesScheduleResponseLC.UseVisualStyleBackColor = false;
            this.butDesScheduleResponseLC.Click += new System.EventHandler(this.butDesScheduleResponseLC_Click);
            // 
            // butDesScheduleRequestCL
            // 
            this.butDesScheduleRequestCL.BackColor = System.Drawing.Color.White;
            this.butDesScheduleRequestCL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDesScheduleRequestCL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDesScheduleRequestCL.Location = new System.Drawing.Point(263, 69);
            this.butDesScheduleRequestCL.Name = "butDesScheduleRequestCL";
            this.butDesScheduleRequestCL.Size = new System.Drawing.Size(189, 41);
            this.butDesScheduleRequestCL.TabIndex = 7;
            this.butDesScheduleRequestCL.Text = "ScheduleRequestCL";
            this.butDesScheduleRequestCL.UseVisualStyleBackColor = false;
            this.butDesScheduleRequestCL.Click += new System.EventHandler(this.butDesScheduleRequestCL_Click);
            // 
            // lblSerialize
            // 
            this.lblSerialize.AutoSize = true;
            this.lblSerialize.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialize.Location = new System.Drawing.Point(48, 42);
            this.lblSerialize.Name = "lblSerialize";
            this.lblSerialize.Size = new System.Drawing.Size(157, 15);
            this.lblSerialize.TabIndex = 6;
            this.lblSerialize.Text = "Serialize and send to Output";
            // 
            // butSerScheduleResponseLC
            // 
            this.butSerScheduleResponseLC.BackColor = System.Drawing.Color.White;
            this.butSerScheduleResponseLC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSerScheduleResponseLC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.butSerScheduleResponseLC.Location = new System.Drawing.Point(35, 116);
            this.butSerScheduleResponseLC.Name = "butSerScheduleResponseLC";
            this.butSerScheduleResponseLC.Size = new System.Drawing.Size(189, 41);
            this.butSerScheduleResponseLC.TabIndex = 2;
            this.butSerScheduleResponseLC.Text = "ScheduleResponseLC";
            this.butSerScheduleResponseLC.UseVisualStyleBackColor = false;
            this.butSerScheduleResponseLC.Click += new System.EventHandler(this.butSerScheduleResponseLC_Click);
            // 
            // butSerScheduleRequestCL
            // 
            this.butSerScheduleRequestCL.BackColor = System.Drawing.Color.White;
            this.butSerScheduleRequestCL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSerScheduleRequestCL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSerScheduleRequestCL.Location = new System.Drawing.Point(35, 69);
            this.butSerScheduleRequestCL.Name = "butSerScheduleRequestCL";
            this.butSerScheduleRequestCL.Size = new System.Drawing.Size(189, 41);
            this.butSerScheduleRequestCL.TabIndex = 0;
            this.butSerScheduleRequestCL.Text = "ScheduleRequestCL";
            this.butSerScheduleRequestCL.UseVisualStyleBackColor = false;
            this.butSerScheduleRequestCL.Click += new System.EventHandler(this.butSerScheduleRequestCL_Click);
            // 
            // grpHMAC
            // 
            this.grpHMAC.Controls.Add(this.lblNote);
            this.grpHMAC.Controls.Add(this.lblPost);
            this.grpHMAC.Controls.Add(this.butPostScheduleRequestCL);
            this.grpHMAC.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHMAC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.grpHMAC.Location = new System.Drawing.Point(13, 196);
            this.grpHMAC.Name = "grpHMAC";
            this.grpHMAC.Size = new System.Drawing.Size(488, 164);
            this.grpHMAC.TabIndex = 1;
            this.grpHMAC.TabStop = false;
            this.grpHMAC.Text = "HMAC";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblNote.Location = new System.Drawing.Point(16, 35);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(466, 15);
            this.lblNote.TabIndex = 22;
            this.lblNote.Text = "Note: You may need to adjust some of the variables in PVSMainForm.HMACEncryption";
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPost.Location = new System.Drawing.Point(140, 70);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(194, 15);
            this.lblPost.TabIndex = 20;
            this.lblPost.Text = "Post Request and Process Response";
            // 
            // butPostScheduleRequestCL
            // 
            this.butPostScheduleRequestCL.BackColor = System.Drawing.Color.White;
            this.butPostScheduleRequestCL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPostScheduleRequestCL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPostScheduleRequestCL.Location = new System.Drawing.Point(143, 98);
            this.butPostScheduleRequestCL.Name = "butPostScheduleRequestCL";
            this.butPostScheduleRequestCL.Size = new System.Drawing.Size(189, 41);
            this.butPostScheduleRequestCL.TabIndex = 19;
            this.butPostScheduleRequestCL.Text = "ScheduleRequestCL";
            this.butPostScheduleRequestCL.UseVisualStyleBackColor = false;
            this.butPostScheduleRequestCL.Click += new System.EventHandler(this.butPostScheduleRequestCL_Click);
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.txtOutputText);
            this.grpOutput.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.grpOutput.Location = new System.Drawing.Point(507, 13);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(488, 704);
            this.grpOutput.TabIndex = 2;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            // 
            // txtOutputText
            // 
            this.txtOutputText.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtOutputText.Location = new System.Drawing.Point(6, 38);
            this.txtOutputText.Multiline = true;
            this.txtOutputText.Name = "txtOutputText";
            this.txtOutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutputText.Size = new System.Drawing.Size(476, 604);
            this.txtOutputText.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.butKeyAdd);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.groupBox1.Location = new System.Drawing.Point(13, 366);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 164);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HMAC Key Generation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Add 5 HMAC Key Combinations and send to Output";
            // 
            // butKeyAdd
            // 
            this.butKeyAdd.BackColor = System.Drawing.Color.White;
            this.butKeyAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butKeyAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKeyAdd.Location = new System.Drawing.Point(143, 98);
            this.butKeyAdd.Name = "butKeyAdd";
            this.butKeyAdd.Size = new System.Drawing.Size(189, 41);
            this.butKeyAdd.TabIndex = 19;
            this.butKeyAdd.Text = "Add 5 Keys";
            this.butKeyAdd.UseVisualStyleBackColor = false;
            this.butKeyAdd.Click += new System.EventHandler(this.butKeyAdd_Click);
            // 
            // butExit
            // 
            this.butExit.BackColor = System.Drawing.Color.White;
            this.butExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.butExit.Location = new System.Drawing.Point(156, 676);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(189, 41);
            this.butExit.TabIndex = 24;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = false;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // PVSMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.grpHMAC);
            this.Controls.Add(this.grpObjects);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "PVSMainForm";
            this.Text = "PVS Main";
            this.grpObjects.ResumeLayout(false);
            this.grpObjects.PerformLayout();
            this.grpHMAC.ResumeLayout(false);
            this.grpHMAC.PerformLayout();
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpObjects;
        private System.Windows.Forms.GroupBox grpHMAC;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.Button butSerScheduleRequestCL;
        private System.Windows.Forms.Button butSerScheduleResponseLC;
        private System.Windows.Forms.TextBox txtOutputText;
        private System.Windows.Forms.Label lblSerialize;
        private System.Windows.Forms.Label lblDeserialize;
        private System.Windows.Forms.Button butDesScheduleResponseLC;
        private System.Windows.Forms.Button butDesScheduleRequestCL;
        private System.Windows.Forms.Button butPostScheduleRequestCL;
        private System.Windows.Forms.Label lblPost;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butKeyAdd;
        private System.Windows.Forms.Button butExit;
    }
}

