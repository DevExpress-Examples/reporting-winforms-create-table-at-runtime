namespace XRTable_RuntimeCreation {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnTableInCode = new System.Windows.Forms.Button();
            this.btnTableInEventHandler = new System.Windows.Forms.Button();
            this.btnLoadReportCodeBehind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTableInCode
            // 
            this.btnTableInCode.Location = new System.Drawing.Point(46, 25);
            this.btnTableInCode.Name = "btnTableInCode";
            this.btnTableInCode.Size = new System.Drawing.Size(223, 56);
            this.btnTableInCode.TabIndex = 0;
            this.btnTableInCode.Text = "Create a report with a table";
            this.btnTableInCode.UseVisualStyleBackColor = true;
            this.btnTableInCode.Click += new System.EventHandler(this.btnTableInCode_Click);
            // 
            // btnTableInEventHandler
            // 
            this.btnTableInEventHandler.Location = new System.Drawing.Point(46, 113);
            this.btnTableInEventHandler.Name = "btnTableInEventHandler";
            this.btnTableInEventHandler.Size = new System.Drawing.Size(223, 56);
            this.btnTableInEventHandler.TabIndex = 1;
            this.btnTableInEventHandler.Text = "Create a report and add a table in the event handler";
            this.btnTableInEventHandler.UseVisualStyleBackColor = true;
            this.btnTableInEventHandler.Click += new System.EventHandler(this.btnTableInEventHandler_Click);
            // 
            // btnLoadReportCodeBehind
            // 
            this.btnLoadReportCodeBehind.Location = new System.Drawing.Point(46, 201);
            this.btnLoadReportCodeBehind.Name = "btnLoadReportCodeBehind";
            this.btnLoadReportCodeBehind.Size = new System.Drawing.Size(223, 56);
            this.btnLoadReportCodeBehind.TabIndex = 2;
            this.btnLoadReportCodeBehind.Text = "Preview a report with a table created in the code behind";
            this.btnLoadReportCodeBehind.UseVisualStyleBackColor = true;
            this.btnLoadReportCodeBehind.Click += new System.EventHandler(this.btnLoadReportCodeBehind_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 285);
            this.Controls.Add(this.btnLoadReportCodeBehind);
            this.Controls.Add(this.btnTableInEventHandler);
            this.Controls.Add(this.btnTableInCode);
            this.Name = "Form1";
            this.Text = "Create XRTable at Runtime";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTableInCode;
        private System.Windows.Forms.Button btnTableInEventHandler;
        private System.Windows.Forms.Button btnLoadReportCodeBehind;
    }
}

