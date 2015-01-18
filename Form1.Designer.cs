namespace Labyrinth
{
    partial class Labyrinth_win
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Labyrinth_win));
            this.height_label = new System.Windows.Forms.Label();
            this.generate_button = new System.Windows.Forms.Button();
            this.width_label = new System.Windows.Forms.Label();
            this.research_button = new System.Windows.Forms.Button();
            this.info_label1 = new System.Windows.Forms.Label();
            this.info_label2 = new System.Windows.Forms.Label();
            this.width_box = new System.Windows.Forms.TextBox();
            this.height_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // height_label
            // 
            this.height_label.AutoSize = true;
            this.height_label.Location = new System.Drawing.Point(12, 43);
            this.height_label.Name = "height_label";
            this.height_label.Size = new System.Drawing.Size(41, 13);
            this.height_label.TabIndex = 0;
            this.height_label.Text = "Height:";
            // 
            // generate_button
            // 
            this.generate_button.Location = new System.Drawing.Point(73, 94);
            this.generate_button.Name = "generate_button";
            this.generate_button.Size = new System.Drawing.Size(113, 36);
            this.generate_button.TabIndex = 3;
            this.generate_button.Text = "Generate";
            this.generate_button.UseVisualStyleBackColor = true;
            this.generate_button.Click += new System.EventHandler(this.Generation_Click);
            this.generate_button.KeyDown += new System.Windows.Forms.KeyEventHandler(this.generate_button_KeyDown);
            // 
            // width_label
            // 
            this.width_label.AutoSize = true;
            this.width_label.Location = new System.Drawing.Point(12, 15);
            this.width_label.Name = "width_label";
            this.width_label.Size = new System.Drawing.Size(38, 13);
            this.width_label.TabIndex = 2;
            this.width_label.Text = "Width:";
            // 
            // research_button
            // 
            this.research_button.Enabled = false;
            this.research_button.Location = new System.Drawing.Point(73, 148);
            this.research_button.Name = "research_button";
            this.research_button.Size = new System.Drawing.Size(113, 36);
            this.research_button.TabIndex = 4;
            this.research_button.Text = "Research";
            this.research_button.UseVisualStyleBackColor = true;
            this.research_button.SizeChanged += new System.EventHandler(this.Research_Click);
            this.research_button.Click += new System.EventHandler(this.Research_Click);
            // 
            // info_label1
            // 
            this.info_label1.AutoSize = true;
            this.info_label1.Location = new System.Drawing.Point(12, 205);
            this.info_label1.Name = "info_label1";
            this.info_label1.Size = new System.Drawing.Size(214, 13);
            this.info_label1.TabIndex = 9;
            this.info_label1.Text = "Choose the height and width of the labyrinth";
            // 
            // info_label2
            // 
            this.info_label2.AutoSize = true;
            this.info_label2.Location = new System.Drawing.Point(12, 228);
            this.info_label2.Name = "info_label2";
            this.info_label2.Size = new System.Drawing.Size(54, 13);
            this.info_label2.TabIndex = 10;
            this.info_label2.Text = "Have fun!";
            // 
            // width_box
            // 
            this.width_box.Location = new System.Drawing.Point(59, 12);
            this.width_box.Name = "width_box";
            this.width_box.Size = new System.Drawing.Size(72, 20);
            this.width_box.TabIndex = 1;
            this.width_box.Text = "10";
            this.width_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.width_box_KeyDown);
            this.width_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.width_box_KeyPress);
            this.width_box.Validated += new System.EventHandler(this.width_box_Validated);
            // 
            // height_box
            // 
            this.height_box.Location = new System.Drawing.Point(59, 40);
            this.height_box.Name = "height_box";
            this.height_box.Size = new System.Drawing.Size(72, 20);
            this.height_box.TabIndex = 2;
            this.height_box.Text = "10";
            this.height_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.height_box_KeyDown);
            this.height_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.height_box_KeyPress);
            this.height_box.Validated += new System.EventHandler(this.height_box_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "Version 2.1";
            // 
            // Labyrinth_win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 285);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.height_box);
            this.Controls.Add(this.width_box);
            this.Controls.Add(this.info_label2);
            this.Controls.Add(this.info_label1);
            this.Controls.Add(this.research_button);
            this.Controls.Add(this.width_label);
            this.Controls.Add(this.generate_button);
            this.Controls.Add(this.height_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(259, 324);
            this.MinimumSize = new System.Drawing.Size(259, 324);
            this.Name = "Labyrinth_win";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Labyrinth 2.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label height_label;
        private System.Windows.Forms.Button generate_button;
        private System.Windows.Forms.Label width_label;
        private System.Windows.Forms.Button research_button;
        private System.Windows.Forms.Label info_label1;
        private System.Windows.Forms.Label info_label2;
        private System.Windows.Forms.TextBox width_box;
        private System.Windows.Forms.TextBox height_box;
        private System.Windows.Forms.Label label1;
    }
}

