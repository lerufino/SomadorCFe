namespace SomadorCFe
{
    partial class PrincipalForm
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
            btnEscolhePasta = new Button();
            fbdBrowserPasta = new FolderBrowserDialog();
            btnCalcular = new Button();
            lblCaminho = new Label();
            lblResultado = new Label();
            SuspendLayout();
            // 
            // btnEscolhePasta
            // 
            btnEscolhePasta.Location = new Point(12, 33);
            btnEscolhePasta.Name = "btnEscolhePasta";
            btnEscolhePasta.Size = new Size(167, 23);
            btnEscolhePasta.TabIndex = 0;
            btnEscolhePasta.Text = "Escolha a pasta com os XML";
            btnEscolhePasta.UseVisualStyleBackColor = true;
            btnEscolhePasta.Click += btnEscolhePasta_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(12, 102);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(109, 23);
            btnCalcular.TabIndex = 1;
            btnCalcular.Text = "Calcula total";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblCaminho
            // 
            lblCaminho.Location = new Point(12, 71);
            lblCaminho.Name = "lblCaminho";
            lblCaminho.Size = new Size(314, 28);
            lblCaminho.TabIndex = 2;
            lblCaminho.Text = "Selecione o caminho";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblResultado.Location = new Point(12, 137);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(301, 30);
            lblResultado.TabIndex = 3;
            lblResultado.Text = "O resultado será exibido aqui.";
            // 
            // PrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 186);
            Controls.Add(lblResultado);
            Controls.Add(lblCaminho);
            Controls.Add(btnCalcular);
            Controls.Add(btnEscolhePasta);
            Name = "PrincipalForm";
            Text = "PrincipalForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEscolhePasta;
        private FolderBrowserDialog fbdBrowserPasta;
        private Button btnCalcular;
        private Label lblCaminho;
        private Label lblResultado;
    }
}