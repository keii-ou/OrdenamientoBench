namespace OrdenamientoBench
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grupoConfiguracion = new GroupBox();
            lblAlgoritmos = new Label();
            clbAlgoritmos = new CheckedListBox();
            lblTamanos = new Label();
            clbTamanos = new CheckedListBox();
            nudTamanoExtra = new NumericUpDown();
            btnAgregarTamano = new Button();
            lblCondiciones = new Label();
            clbCondiciones = new CheckedListBox();
            lblRepeticiones = new Label();
            nudRepeticiones = new NumericUpDown();
            lblSemilla = new Label();
            nudSemilla = new NumericUpDown();
            btnEjecutar = new Button();
            btnCancelar = new Button();
            btnExportarCsv = new Button();
            btnExportarPng = new Button();
            tabControlPrincipal = new TabControl();
            tabResultados = new TabPage();
            dgvResultados = new DataGridView();
            tabGrafica = new TabPage();
            pbGrafica = new PictureBox();
            panelControlesGrafica = new Panel();
            lblCondicionGrafica = new Label();
            cmbCondicionGrafica = new ComboBox();
            lblMetrica = new Label();
            cmbMetrica = new ComboBox();
            chkEscalaLog = new CheckBox();
            tabPruebaRapida = new TabPage();
            lblEntrada = new Label();
            txtEntrada = new TextBox();
            lblMetodoRapido = new Label();
            cmbMetodoRapido = new ComboBox();
            btnOrdenarRapido = new Button();
            lblTiempoRapido = new Label();
            lblSalida = new Label();
            txtSalida = new TextBox();
            barraEstado = new StatusStrip();
            lblEstado = new ToolStripStatusLabel();
            barraProgreso = new ToolStripProgressBar();
            dlgGuardarCsv = new SaveFileDialog();
            dlgGuardarPng = new SaveFileDialog();
            grupoConfiguracion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTamanoExtra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRepeticiones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSemilla).BeginInit();
            tabControlPrincipal.SuspendLayout();
            tabResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            tabGrafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbGrafica).BeginInit();
            panelControlesGrafica.SuspendLayout();
            tabPruebaRapida.SuspendLayout();
            barraEstado.SuspendLayout();
            SuspendLayout();
            // 
            // grupoConfiguracion
            // 
            grupoConfiguracion.Controls.Add(lblAlgoritmos);
            grupoConfiguracion.Controls.Add(clbAlgoritmos);
            grupoConfiguracion.Controls.Add(lblTamanos);
            grupoConfiguracion.Controls.Add(clbTamanos);
            grupoConfiguracion.Controls.Add(nudTamanoExtra);
            grupoConfiguracion.Controls.Add(btnAgregarTamano);
            grupoConfiguracion.Controls.Add(lblCondiciones);
            grupoConfiguracion.Controls.Add(clbCondiciones);
            grupoConfiguracion.Controls.Add(lblRepeticiones);
            grupoConfiguracion.Controls.Add(nudRepeticiones);
            grupoConfiguracion.Controls.Add(lblSemilla);
            grupoConfiguracion.Controls.Add(nudSemilla);
            grupoConfiguracion.Controls.Add(btnEjecutar);
            grupoConfiguracion.Controls.Add(btnCancelar);
            grupoConfiguracion.Controls.Add(btnExportarCsv);
            grupoConfiguracion.Controls.Add(btnExportarPng);
            grupoConfiguracion.Dock = DockStyle.Top;
            grupoConfiguracion.Location = new Point(0, 0);
            grupoConfiguracion.Name = "grupoConfiguracion";
            grupoConfiguracion.Size = new Size(1084, 185);
            grupoConfiguracion.TabIndex = 0;
            grupoConfiguracion.TabStop = false;
            grupoConfiguracion.Text = "Configuración del banco de pruebas";
            // 
            // lblAlgoritmos
            // 
            lblAlgoritmos.AutoSize = true;
            lblAlgoritmos.Location = new Point(12, 24);
            lblAlgoritmos.Name = "lblAlgoritmos";
            lblAlgoritmos.Size = new Size(68, 15);
            lblAlgoritmos.TabIndex = 0;
            lblAlgoritmos.Text = "Algoritmos";
            // 
            // clbAlgoritmos
            // 
            clbAlgoritmos.CheckOnClick = true;
            clbAlgoritmos.FormattingEnabled = true;
            clbAlgoritmos.Location = new Point(12, 44);
            clbAlgoritmos.Name = "clbAlgoritmos";
            clbAlgoritmos.Size = new Size(190, 130);
            clbAlgoritmos.TabIndex = 1;
            // 
            // lblTamanos
            // 
            lblTamanos.AutoSize = true;
            lblTamanos.Location = new Point(218, 24);
            lblTamanos.Name = "lblTamanos";
            lblTamanos.Size = new Size(107, 15);
            lblTamanos.TabIndex = 2;
            lblTamanos.Text = "Cantidad de datos";
            // 
            // clbTamanos
            // 
            clbTamanos.CheckOnClick = true;
            clbTamanos.FormattingEnabled = true;
            clbTamanos.Location = new Point(218, 44);
            clbTamanos.Name = "clbTamanos";
            clbTamanos.Size = new Size(150, 94);
            clbTamanos.TabIndex = 3;
            // 
            // nudTamanoExtra
            // 
            nudTamanoExtra.Location = new Point(218, 148);
            nudTamanoExtra.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudTamanoExtra.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nudTamanoExtra.Name = "nudTamanoExtra";
            nudTamanoExtra.Size = new Size(100, 23);
            nudTamanoExtra.TabIndex = 4;
            nudTamanoExtra.ThousandsSeparator = true;
            nudTamanoExtra.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // btnAgregarTamano
            // 
            btnAgregarTamano.Location = new Point(324, 147);
            btnAgregarTamano.Name = "btnAgregarTamano";
            btnAgregarTamano.Size = new Size(44, 25);
            btnAgregarTamano.TabIndex = 5;
            btnAgregarTamano.Text = "+";
            btnAgregarTamano.UseVisualStyleBackColor = true;
            btnAgregarTamano.Click += btnAgregarTamano_Click;
            // 
            // lblCondiciones
            // 
            lblCondiciones.AutoSize = true;
            lblCondiciones.Location = new Point(386, 24);
            lblCondiciones.Name = "lblCondiciones";
            lblCondiciones.Size = new Size(120, 15);
            lblCondiciones.TabIndex = 6;
            lblCondiciones.Text = "Condición de los datos";
            // 
            // clbCondiciones
            // 
            clbCondiciones.CheckOnClick = true;
            clbCondiciones.FormattingEnabled = true;
            clbCondiciones.Location = new Point(386, 44);
            clbCondiciones.Name = "clbCondiciones";
            clbCondiciones.Size = new Size(180, 76);
            clbCondiciones.TabIndex = 7;
            // 
            // lblRepeticiones
            // 
            lblRepeticiones.AutoSize = true;
            lblRepeticiones.Location = new Point(386, 128);
            lblRepeticiones.Name = "lblRepeticiones";
            lblRepeticiones.Size = new Size(72, 15);
            lblRepeticiones.TabIndex = 8;
            lblRepeticiones.Text = "Repeticiones";
            // 
            // nudRepeticiones
            // 
            nudRepeticiones.Location = new Point(386, 148);
            nudRepeticiones.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            nudRepeticiones.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRepeticiones.Name = "nudRepeticiones";
            nudRepeticiones.Size = new Size(80, 23);
            nudRepeticiones.TabIndex = 9;
            nudRepeticiones.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSemilla
            // 
            lblSemilla.AutoSize = true;
            lblSemilla.Location = new Point(480, 128);
            lblSemilla.Name = "lblSemilla";
            lblSemilla.Size = new Size(46, 15);
            lblSemilla.TabIndex = 10;
            lblSemilla.Text = "Semilla";
            // 
            // nudSemilla
            // 
            nudSemilla.Location = new Point(480, 148);
            nudSemilla.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            nudSemilla.Name = "nudSemilla";
            nudSemilla.Size = new Size(86, 23);
            nudSemilla.TabIndex = 11;
            // 
            // btnEjecutar
            // 
            btnEjecutar.Location = new Point(600, 44);
            btnEjecutar.Name = "btnEjecutar";
            btnEjecutar.Size = new Size(150, 36);
            btnEjecutar.TabIndex = 12;
            btnEjecutar.Text = "Ejecutar pruebas";
            btnEjecutar.UseVisualStyleBackColor = true;
            btnEjecutar.Click += btnEjecutar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Enabled = false;
            btnCancelar.Location = new Point(600, 88);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 36);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnExportarCsv
            // 
            btnExportarCsv.Location = new Point(770, 44);
            btnExportarCsv.Name = "btnExportarCsv";
            btnExportarCsv.Size = new Size(150, 36);
            btnExportarCsv.TabIndex = 14;
            btnExportarCsv.Text = "Exportar CSV";
            btnExportarCsv.UseVisualStyleBackColor = true;
            btnExportarCsv.Click += btnExportarCsv_Click;
            // 
            // btnExportarPng
            // 
            btnExportarPng.Location = new Point(770, 88);
            btnExportarPng.Name = "btnExportarPng";
            btnExportarPng.Size = new Size(150, 36);
            btnExportarPng.TabIndex = 15;
            btnExportarPng.Text = "Guardar gráfica (PNG)";
            btnExportarPng.UseVisualStyleBackColor = true;
            btnExportarPng.Click += btnExportarPng_Click;
            // 
            // tabControlPrincipal
            // 
            tabControlPrincipal.Controls.Add(tabResultados);
            tabControlPrincipal.Controls.Add(tabGrafica);
            tabControlPrincipal.Controls.Add(tabPruebaRapida);
            tabControlPrincipal.Dock = DockStyle.Fill;
            tabControlPrincipal.Location = new Point(0, 185);
            tabControlPrincipal.Name = "tabControlPrincipal";
            tabControlPrincipal.SelectedIndex = 0;
            tabControlPrincipal.Size = new Size(1084, 454);
            tabControlPrincipal.TabIndex = 1;
            // 
            // tabResultados
            // 
            tabResultados.Controls.Add(dgvResultados);
            tabResultados.Location = new Point(4, 24);
            tabResultados.Name = "tabResultados";
            tabResultados.Padding = new Padding(3);
            tabResultados.Size = new Size(1076, 426);
            tabResultados.TabIndex = 0;
            tabResultados.Text = "Resultados";
            tabResultados.UseVisualStyleBackColor = true;
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Dock = DockStyle.Fill;
            dgvResultados.Location = new Point(3, 3);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersVisible = false;
            dgvResultados.Size = new Size(1070, 420);
            dgvResultados.TabIndex = 0;
            // 
            // tabGrafica
            // 
            tabGrafica.Controls.Add(pbGrafica);
            tabGrafica.Controls.Add(panelControlesGrafica);
            tabGrafica.Location = new Point(4, 24);
            tabGrafica.Name = "tabGrafica";
            tabGrafica.Padding = new Padding(3);
            tabGrafica.Size = new Size(1076, 426);
            tabGrafica.TabIndex = 1;
            tabGrafica.Text = "Gráfica de tiempos";
            tabGrafica.UseVisualStyleBackColor = true;
            // 
            // pbGrafica
            // 
            pbGrafica.BackColor = Color.White;
            pbGrafica.Dock = DockStyle.Fill;
            pbGrafica.Location = new Point(3, 43);
            pbGrafica.Name = "pbGrafica";
            pbGrafica.Size = new Size(1070, 380);
            pbGrafica.TabIndex = 1;
            pbGrafica.TabStop = false;
            pbGrafica.Paint += pbGrafica_Paint;
            pbGrafica.Resize += pbGrafica_Resize;
            // 
            // panelControlesGrafica
            // 
            panelControlesGrafica.Controls.Add(lblCondicionGrafica);
            panelControlesGrafica.Controls.Add(cmbCondicionGrafica);
            panelControlesGrafica.Controls.Add(lblMetrica);
            panelControlesGrafica.Controls.Add(cmbMetrica);
            panelControlesGrafica.Controls.Add(chkEscalaLog);
            panelControlesGrafica.Dock = DockStyle.Top;
            panelControlesGrafica.Location = new Point(3, 3);
            panelControlesGrafica.Name = "panelControlesGrafica";
            panelControlesGrafica.Size = new Size(1070, 40);
            panelControlesGrafica.TabIndex = 0;
            // 
            // lblCondicionGrafica
            // 
            lblCondicionGrafica.AutoSize = true;
            lblCondicionGrafica.Location = new Point(8, 12);
            lblCondicionGrafica.Name = "lblCondicionGrafica";
            lblCondicionGrafica.Size = new Size(61, 15);
            lblCondicionGrafica.TabIndex = 0;
            lblCondicionGrafica.Text = "Condición";
            // 
            // cmbCondicionGrafica
            // 
            cmbCondicionGrafica.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCondicionGrafica.FormattingEnabled = true;
            cmbCondicionGrafica.Location = new Point(76, 9);
            cmbCondicionGrafica.Name = "cmbCondicionGrafica";
            cmbCondicionGrafica.Size = new Size(170, 23);
            cmbCondicionGrafica.TabIndex = 1;
            cmbCondicionGrafica.SelectedIndexChanged += OpcionesGraficaCambiaron;
            // 
            // lblMetrica
            // 
            lblMetrica.AutoSize = true;
            lblMetrica.Location = new Point(268, 12);
            lblMetrica.Name = "lblMetrica";
            lblMetrica.Size = new Size(45, 15);
            lblMetrica.TabIndex = 2;
            lblMetrica.Text = "Métrica";
            // 
            // cmbMetrica
            // 
            cmbMetrica.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetrica.FormattingEnabled = true;
            cmbMetrica.Location = new Point(320, 9);
            cmbMetrica.Name = "cmbMetrica";
            cmbMetrica.Size = new Size(150, 23);
            cmbMetrica.TabIndex = 3;
            cmbMetrica.SelectedIndexChanged += OpcionesGraficaCambiaron;
            // 
            // chkEscalaLog
            // 
            chkEscalaLog.AutoSize = true;
            chkEscalaLog.Checked = true;
            chkEscalaLog.CheckState = CheckState.Checked;
            chkEscalaLog.Location = new Point(492, 11);
            chkEscalaLog.Name = "chkEscalaLog";
            chkEscalaLog.Size = new Size(138, 19);
            chkEscalaLog.TabIndex = 4;
            chkEscalaLog.Text = "Escala logarítmica";
            chkEscalaLog.UseVisualStyleBackColor = true;
            chkEscalaLog.CheckedChanged += OpcionesGraficaCambiaron;
            // 
            // tabPruebaRapida
            // 
            tabPruebaRapida.Controls.Add(lblEntrada);
            tabPruebaRapida.Controls.Add(txtEntrada);
            tabPruebaRapida.Controls.Add(lblMetodoRapido);
            tabPruebaRapida.Controls.Add(cmbMetodoRapido);
            tabPruebaRapida.Controls.Add(btnOrdenarRapido);
            tabPruebaRapida.Controls.Add(lblTiempoRapido);
            tabPruebaRapida.Controls.Add(lblSalida);
            tabPruebaRapida.Controls.Add(txtSalida);
            tabPruebaRapida.Location = new Point(4, 24);
            tabPruebaRapida.Name = "tabPruebaRapida";
            tabPruebaRapida.Padding = new Padding(3);
            tabPruebaRapida.Size = new Size(1076, 426);
            tabPruebaRapida.TabIndex = 2;
            tabPruebaRapida.Text = "Prueba rápida";
            tabPruebaRapida.UseVisualStyleBackColor = true;
            // 
            // lblEntrada
            // 
            lblEntrada.AutoSize = true;
            lblEntrada.Location = new Point(12, 14);
            lblEntrada.Name = "lblEntrada";
            lblEntrada.Size = new Size(224, 15);
            lblEntrada.TabIndex = 0;
            lblEntrada.Text = "Números enteros separados por coma o espacio";
            // 
            // txtEntrada
            // 
            txtEntrada.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEntrada.Location = new Point(12, 34);
            txtEntrada.Multiline = true;
            txtEntrada.Name = "txtEntrada";
            txtEntrada.PlaceholderText = "Ej.: 9, 3, 7, 1, 5";
            txtEntrada.ScrollBars = ScrollBars.Vertical;
            txtEntrada.Size = new Size(700, 110);
            txtEntrada.TabIndex = 1;
            // 
            // lblMetodoRapido
            // 
            lblMetodoRapido.AutoSize = true;
            lblMetodoRapido.Location = new Point(740, 14);
            lblMetodoRapido.Name = "lblMetodoRapido";
            lblMetodoRapido.Size = new Size(48, 15);
            lblMetodoRapido.TabIndex = 2;
            lblMetodoRapido.Text = "Método";
            // 
            // cmbMetodoRapido
            // 
            cmbMetodoRapido.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbMetodoRapido.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoRapido.FormattingEnabled = true;
            cmbMetodoRapido.Location = new Point(740, 34);
            cmbMetodoRapido.Name = "cmbMetodoRapido";
            cmbMetodoRapido.Size = new Size(200, 23);
            cmbMetodoRapido.TabIndex = 3;
            // 
            // btnOrdenarRapido
            // 
            btnOrdenarRapido.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOrdenarRapido.Location = new Point(740, 70);
            btnOrdenarRapido.Name = "btnOrdenarRapido";
            btnOrdenarRapido.Size = new Size(200, 36);
            btnOrdenarRapido.TabIndex = 4;
            btnOrdenarRapido.Text = "Ordenar";
            btnOrdenarRapido.UseVisualStyleBackColor = true;
            btnOrdenarRapido.Click += btnOrdenarRapido_Click;
            // 
            // lblTiempoRapido
            // 
            lblTiempoRapido.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTiempoRapido.AutoSize = true;
            lblTiempoRapido.Location = new Point(740, 118);
            lblTiempoRapido.Name = "lblTiempoRapido";
            lblTiempoRapido.Size = new Size(0, 15);
            lblTiempoRapido.TabIndex = 5;
            // 
            // lblSalida
            // 
            lblSalida.AutoSize = true;
            lblSalida.Location = new Point(12, 162);
            lblSalida.Name = "lblSalida";
            lblSalida.Size = new Size(95, 15);
            lblSalida.TabIndex = 6;
            lblSalida.Text = "Resultado ordenado";
            // 
            // txtSalida
            // 
            txtSalida.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSalida.Location = new Point(12, 182);
            txtSalida.Multiline = true;
            txtSalida.Name = "txtSalida";
            txtSalida.ReadOnly = true;
            txtSalida.ScrollBars = ScrollBars.Vertical;
            txtSalida.Size = new Size(1050, 230);
            txtSalida.TabIndex = 7;
            // 
            // barraEstado
            // 
            barraEstado.Items.AddRange(new ToolStripItem[] { lblEstado, barraProgreso });
            barraEstado.Location = new Point(0, 639);
            barraEstado.Name = "barraEstado";
            barraEstado.Size = new Size(1084, 22);
            barraEstado.TabIndex = 2;
            // 
            // lblEstado
            // 
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(850, 17);
            lblEstado.Spring = true;
            lblEstado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // barraProgreso
            // 
            barraProgreso.Name = "barraProgreso";
            barraProgreso.Size = new Size(200, 16);
            // 
            // dlgGuardarCsv
            // 
            dlgGuardarCsv.DefaultExt = "csv";
            dlgGuardarCsv.FileName = "resultados_ordenamiento";
            dlgGuardarCsv.Filter = "Archivo CSV (*.csv)|*.csv";
            // 
            // dlgGuardarPng
            // 
            dlgGuardarPng.DefaultExt = "png";
            dlgGuardarPng.FileName = "grafica_ordenamiento";
            dlgGuardarPng.Filter = "Imagen PNG (*.png)|*.png";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 661);
            Controls.Add(tabControlPrincipal);
            Controls.Add(grupoConfiguracion);
            Controls.Add(barraEstado);
            MinimumSize = new Size(1000, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            grupoConfiguracion.ResumeLayout(false);
            grupoConfiguracion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTamanoExtra).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRepeticiones).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSemilla).EndInit();
            tabControlPrincipal.ResumeLayout(false);
            tabResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            tabGrafica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbGrafica).EndInit();
            panelControlesGrafica.ResumeLayout(false);
            panelControlesGrafica.PerformLayout();
            tabPruebaRapida.ResumeLayout(false);
            tabPruebaRapida.PerformLayout();
            barraEstado.ResumeLayout(false);
            barraEstado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grupoConfiguracion;
        private Label lblAlgoritmos;
        private CheckedListBox clbAlgoritmos;
        private Label lblTamanos;
        private CheckedListBox clbTamanos;
        private NumericUpDown nudTamanoExtra;
        private Button btnAgregarTamano;
        private Label lblCondiciones;
        private CheckedListBox clbCondiciones;
        private Label lblRepeticiones;
        private NumericUpDown nudRepeticiones;
        private Label lblSemilla;
        private NumericUpDown nudSemilla;
        private Button btnEjecutar;
        private Button btnCancelar;
        private Button btnExportarCsv;
        private Button btnExportarPng;
        private TabControl tabControlPrincipal;
        private TabPage tabResultados;
        private DataGridView dgvResultados;
        private TabPage tabGrafica;
        private PictureBox pbGrafica;
        private Panel panelControlesGrafica;
        private Label lblCondicionGrafica;
        private ComboBox cmbCondicionGrafica;
        private Label lblMetrica;
        private ComboBox cmbMetrica;
        private CheckBox chkEscalaLog;
        private TabPage tabPruebaRapida;
        private Label lblEntrada;
        private TextBox txtEntrada;
        private Label lblMetodoRapido;
        private ComboBox cmbMetodoRapido;
        private Button btnOrdenarRapido;
        private Label lblTiempoRapido;
        private Label lblSalida;
        private TextBox txtSalida;
        private StatusStrip barraEstado;
        private ToolStripStatusLabel lblEstado;
        private ToolStripProgressBar barraProgreso;
        private SaveFileDialog dlgGuardarCsv;
        private SaveFileDialog dlgGuardarPng;
    }
}
