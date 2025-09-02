namespace Ejercicio8
{
    partial class FormPrincipal
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
            btnActualizar = new Button();
            listView1 = new ListView();
            btnAgregar = new Button();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tbRadio = new TextBox();
            tbLargo = new TextBox();
            tbAncho = new TextBox();
            btnVer = new Button();
            btnEliminar = new Button();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(454, 47);
            btnActualizar.Margin = new Padding(4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(96, 53);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar Listado";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(6, 34);
            listView1.Name = "listView1";
            listView1.Size = new Size(429, 255);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(454, 58);
            btnAgregar.Margin = new Padding(4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(96, 53);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Confirmar Registro";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tbRadio);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(tbLargo);
            groupBox1.Controls.Add(tbAncho);
            groupBox1.Location = new Point(6, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(565, 170);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de la figura";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(radioButton1);
            groupBox3.Controls.Add(radioButton2);
            groupBox3.Location = new Point(18, 33);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(161, 101);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tipo de Figura";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(31, 39);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(106, 25);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Rectangulo";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(31, 70);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(77, 25);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Circulo";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(212, 129);
            label3.Name = "label3";
            label3.Size = new Size(50, 21);
            label3.TabIndex = 7;
            label3.Text = "Radio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(226, 68);
            label2.Name = "label2";
            label2.Size = new Size(38, 21);
            label2.TabIndex = 6;
            label2.Text = "Alto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(212, 33);
            label1.Name = "label1";
            label1.Size = new Size(54, 21);
            label1.TabIndex = 5;
            label1.Text = "Ancho";
            // 
            // tbRadio
            // 
            tbRadio.Location = new Point(296, 125);
            tbRadio.Name = "tbRadio";
            tbRadio.Size = new Size(100, 29);
            tbRadio.TabIndex = 4;
            // 
            // tbLargo
            // 
            tbLargo.Location = new Point(294, 65);
            tbLargo.Name = "tbLargo";
            tbLargo.Size = new Size(100, 29);
            tbLargo.TabIndex = 3;
            // 
            // tbAncho
            // 
            tbAncho.Location = new Point(294, 30);
            tbAncho.Name = "tbAncho";
            tbAncho.Size = new Size(102, 29);
            tbAncho.TabIndex = 2;
            // 
            // btnVer
            // 
            btnVer.Location = new Point(454, 172);
            btnVer.Margin = new Padding(4);
            btnVer.Name = "btnVer";
            btnVer.Size = new Size(96, 53);
            btnVer.TabIndex = 5;
            btnVer.Text = "Ver Registro";
            btnVer.UseVisualStyleBackColor = true;
            btnVer.Click += btnVer_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(454, 233);
            btnEliminar.Margin = new Padding(4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(96, 53);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar Registro";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listView1);
            groupBox2.Controls.Add(btnEliminar);
            groupBox2.Controls.Add(btnVer);
            groupBox2.Controls.Add(btnActualizar);
            groupBox2.Location = new Point(6, 184);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(565, 295);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Listado de Figuras";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 483);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormPrincipal";
            Text = "Ejemplo de ABM";
            Load += FormPrincipal_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnActualizar;
        private ListView listView1;
        private Button btnAgregar;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tbRadio;
        private TextBox tbLargo;
        private TextBox tbAncho;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox3;
        private Button btnVer;
        private Button btnEliminar;
        private GroupBox groupBox2;
    }
}
