using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace ItensLibrary
{
	public class UserControlFilmes : System.Windows.Forms.UserControl
	{
		#region WindowsForms Controls
		private System.Windows.Forms.TabControl tabControlFilmes;
		private System.Windows.Forms.TabPage tabPagePesquisar;
		private System.Windows.Forms.TabPage tabPageAssistidos;
		private System.Windows.Forms.TabPage tabPageAdicionar;
		private System.Windows.Forms.Label labelNomeFilme;
		private System.Windows.Forms.Label labelGeneroFilme;
		private System.Windows.Forms.Label labelTipoMidia;
		private System.Windows.Forms.Label labelDataAquisicao;
		private System.Windows.Forms.DateTimePicker dateTimePickerDataAquisicaoFilme;
		private System.Windows.Forms.Label labelImagemFilme;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnImagemFilme;
		private System.Windows.Forms.Button btnGravar;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox txtNomeFilme;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnPesquisar;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnNovoGenero;
		private System.Windows.Forms.Button btnNovoTipoMidia;
		private System.Windows.Forms.Label lblAssistidos;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label lblLocalizacao;
		private System.Windows.Forms.Button btnLocalizacao;
		#endregion
		
		#region Propriedades
		byte[] binaryImagedata;
		#endregion
		private System.Windows.Forms.ComboBox ddlTipoMidiaFilmePesquisa;
		private System.Windows.Forms.ComboBox ddlGeneroFilmePesquisa;
		private System.Windows.Forms.ComboBox ddlLocalizacaoAdicionar;
		private System.Windows.Forms.ComboBox ddlTipoMidiaFilmeAdicionar;
		private System.Windows.Forms.ComboBox ddlGeneroFilmeAdicionar;
		private System.Windows.Forms.ComboBox ddlTipoMidiaFilmeAssistidos;
		private System.Windows.Forms.CheckedListBox clbPessoa;

		private Filme filmeAtual;

		public Filme FilmeAtual
		{
			get
			{
				return filmeAtual;
			}
			set
			{
				filmeAtual = value;
			}
		}

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserControlFilmes(Filme filme)
		{
			FilmeAtual = filme;

			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			InicializaCombos();
		}

		private void InicializaCombos()
		{
			DataTable dtSource;
			DataRow dtRow;
			
			#region Aba Adicionar
			dtSource = ItensLibrary.DO.GeneroFilmeDO.Listar();
			dtRow = dtSource.NewRow();
			dtRow["nsu_Genero"] = 0;
			dtRow["nm_Genero"] = "(Selecionar)";
			dtSource.Rows.InsertAt(dtRow,0);
			ddlGeneroFilmeAdicionar.DataSource = dtSource;

			dtSource = ItensLibrary.DO.TipoMidiaFilmeDO.Listar();
			dtRow = dtSource.NewRow();
			dtRow["nsu_TipoMidia"] = 0;
			dtRow["nm_TipoMidia"] = "(Selecionar)";
			dtSource.Rows.InsertAt(dtRow,0);
			ddlTipoMidiaFilmeAdicionar.DataSource = dtSource;

			dtSource = ItensLibrary.DO.LocalizacaoDO.Listar();
			dtRow = dtSource.NewRow();
			dtRow["nsu_Localizacao"] = 0;
			dtRow["nm_Localizacao"] = "(Selecionar)";
			dtSource.Rows.InsertAt(dtRow,0);
			ddlLocalizacaoAdicionar.DataSource = dtSource;
			#endregion

			#region Aba Pesquisar
			dtSource = ItensLibrary.DO.GeneroFilmeDO.Listar();
			dtRow = dtSource.NewRow();
			dtRow["nsu_Genero"] = 0;
			dtRow["nm_Genero"] = "(Todos os G�neros)";
			dtSource.Rows.InsertAt(dtRow,0);
			ddlGeneroFilmePesquisa.DataSource = dtSource;
			
			dtSource = ItensLibrary.DO.TipoMidiaFilmeDO.Listar();
			dtRow = dtSource.NewRow();
			dtRow["nsu_TipoMidia"] = 0;
			dtRow["nm_TipoMidia"] = "(Todos os Tipos de M�dia)";
			dtSource.Rows.InsertAt(dtRow,0);
			ddlTipoMidiaFilmePesquisa.DataSource = dtSource;
			#endregion

			#region Aba Assistidos
			dtSource = ItensLibrary.DO.TipoMidiaFilmeDO.Listar();
			dtRow = dtSource.NewRow();
			dtRow["nsu_TipoMidia"] = 0;
			dtRow["nm_TipoMidia"] = "(Todos os Tipos de M�dia)";
			dtSource.Rows.InsertAt(dtRow,0);
			ddlTipoMidiaFilmeAssistidos.DataSource = dtSource;
			#endregion

			dtSource = ItensLibrary.DO.PessoaDO.Listar();
			clbPessoa.DataSource = dtSource;
			clbPessoa.DisplayMember = "nm_Pessoa";
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControlFilmes = new System.Windows.Forms.TabControl();
			this.tabPagePesquisar = new System.Windows.Forms.TabPage();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.lblAssistidos = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btnPesquisar = new System.Windows.Forms.Button();
			this.ddlTipoMidiaFilmePesquisa = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ddlGeneroFilmePesquisa = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPageAssistidos = new System.Windows.Forms.TabPage();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.clbPessoa = new System.Windows.Forms.CheckedListBox();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.ddlTipoMidiaFilmeAssistidos = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPageAdicionar = new System.Windows.Forms.TabPage();
			this.btnLocalizacao = new System.Windows.Forms.Button();
			this.lblLocalizacao = new System.Windows.Forms.Label();
			this.ddlLocalizacaoAdicionar = new System.Windows.Forms.ComboBox();
			this.btnNovoTipoMidia = new System.Windows.Forms.Button();
			this.btnNovoGenero = new System.Windows.Forms.Button();
			this.btnGravar = new System.Windows.Forms.Button();
			this.btnImagemFilme = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.labelImagemFilme = new System.Windows.Forms.Label();
			this.ddlTipoMidiaFilmeAdicionar = new System.Windows.Forms.ComboBox();
			this.ddlGeneroFilmeAdicionar = new System.Windows.Forms.ComboBox();
			this.dateTimePickerDataAquisicaoFilme = new System.Windows.Forms.DateTimePicker();
			this.labelDataAquisicao = new System.Windows.Forms.Label();
			this.labelTipoMidia = new System.Windows.Forms.Label();
			this.labelGeneroFilme = new System.Windows.Forms.Label();
			this.txtNomeFilme = new System.Windows.Forms.TextBox();
			this.labelNomeFilme = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tabControlFilmes.SuspendLayout();
			this.tabPagePesquisar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPageAssistidos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.tabPageAdicionar.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlFilmes
			// 
			this.tabControlFilmes.Controls.Add(this.tabPagePesquisar);
			this.tabControlFilmes.Controls.Add(this.tabPageAssistidos);
			this.tabControlFilmes.Controls.Add(this.tabPageAdicionar);
			this.tabControlFilmes.Location = new System.Drawing.Point(8, 8);
			this.tabControlFilmes.Name = "tabControlFilmes";
			this.tabControlFilmes.SelectedIndex = 0;
			this.tabControlFilmes.Size = new System.Drawing.Size(600, 496);
			this.tabControlFilmes.TabIndex = 0;
			// 
			// tabPagePesquisar
			// 
			this.tabPagePesquisar.Controls.Add(this.radioButton3);
			this.tabPagePesquisar.Controls.Add(this.radioButton2);
			this.tabPagePesquisar.Controls.Add(this.radioButton1);
			this.tabPagePesquisar.Controls.Add(this.lblAssistidos);
			this.tabPagePesquisar.Controls.Add(this.dataGrid1);
			this.tabPagePesquisar.Controls.Add(this.btnPesquisar);
			this.tabPagePesquisar.Controls.Add(this.ddlTipoMidiaFilmePesquisa);
			this.tabPagePesquisar.Controls.Add(this.label4);
			this.tabPagePesquisar.Controls.Add(this.ddlGeneroFilmePesquisa);
			this.tabPagePesquisar.Controls.Add(this.label3);
			this.tabPagePesquisar.Controls.Add(this.textBox2);
			this.tabPagePesquisar.Controls.Add(this.label2);
			this.tabPagePesquisar.Location = new System.Drawing.Point(4, 22);
			this.tabPagePesquisar.Name = "tabPagePesquisar";
			this.tabPagePesquisar.Size = new System.Drawing.Size(592, 470);
			this.tabPagePesquisar.TabIndex = 0;
			this.tabPagePesquisar.Text = "Pesquisar";
			// 
			// radioButton3
			// 
			this.radioButton3.Checked = true;
			this.radioButton3.Location = new System.Drawing.Point(464, 64);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.TabIndex = 17;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Ambos";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(464, 40);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 16;
			this.radioButton2.Text = "N�o Assistidos";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(464, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 15;
			this.radioButton1.Text = "J� Assistidos";
			// 
			// lblAssistidos
			// 
			this.lblAssistidos.Location = new System.Drawing.Point(360, 16);
			this.lblAssistidos.Name = "lblAssistidos";
			this.lblAssistidos.TabIndex = 14;
			this.lblAssistidos.Text = "Assistidos:";
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 128);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(560, 296);
			this.dataGrid1.TabIndex = 13;
			// 
			// btnPesquisar
			// 
			this.btnPesquisar.Location = new System.Drawing.Point(496, 432);
			this.btnPesquisar.Name = "btnPesquisar";
			this.btnPesquisar.TabIndex = 12;
			this.btnPesquisar.Text = "Pesquisar";
			// 
			// ddlTipoMidiaFilmePesquisa
			// 
			this.ddlTipoMidiaFilmePesquisa.DisplayMember = "nm_TipoMidia";
			this.ddlTipoMidiaFilmePesquisa.Location = new System.Drawing.Point(120, 80);
			this.ddlTipoMidiaFilmePesquisa.Name = "ddlTipoMidiaFilmePesquisa";
			this.ddlTipoMidiaFilmePesquisa.Size = new System.Drawing.Size(224, 21);
			this.ddlTipoMidiaFilmePesquisa.TabIndex = 10;
			this.ddlTipoMidiaFilmePesquisa.ValueMember = "nsu_TipoMidia";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 80);
			this.label4.Name = "label4";
			this.label4.TabIndex = 9;
			this.label4.Text = "Tipo de M�dia:";
			// 
			// ddlGeneroFilmePesquisa
			// 
			this.ddlGeneroFilmePesquisa.DisplayMember = "nm_Genero";
			this.ddlGeneroFilmePesquisa.Location = new System.Drawing.Point(120, 48);
			this.ddlGeneroFilmePesquisa.Name = "ddlGeneroFilmePesquisa";
			this.ddlGeneroFilmePesquisa.Size = new System.Drawing.Size(224, 21);
			this.ddlGeneroFilmePesquisa.TabIndex = 8;
			this.ddlGeneroFilmePesquisa.ValueMember = "nsu_Genero";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.TabIndex = 7;
			this.label3.Text = "G�nero:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(120, 16);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(224, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "Nome:";
			// 
			// tabPageAssistidos
			// 
			this.tabPageAssistidos.Controls.Add(this.button3);
			this.tabPageAssistidos.Controls.Add(this.button2);
			this.tabPageAssistidos.Controls.Add(this.button1);
			this.tabPageAssistidos.Controls.Add(this.label6);
			this.tabPageAssistidos.Controls.Add(this.clbPessoa);
			this.tabPageAssistidos.Controls.Add(this.dataGrid2);
			this.tabPageAssistidos.Controls.Add(this.ddlTipoMidiaFilmeAssistidos);
			this.tabPageAssistidos.Controls.Add(this.label5);
			this.tabPageAssistidos.Controls.Add(this.textBox1);
			this.tabPageAssistidos.Controls.Add(this.label1);
			this.tabPageAssistidos.Location = new System.Drawing.Point(4, 22);
			this.tabPageAssistidos.Name = "tabPageAssistidos";
			this.tabPageAssistidos.Size = new System.Drawing.Size(592, 470);
			this.tabPageAssistidos.TabIndex = 1;
			this.tabPageAssistidos.Text = "Assistidos";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(432, 368);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(136, 23);
			this.button3.TabIndex = 16;
			this.button3.Text = "Cadastrar Nova Pessoa";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(496, 424);
			this.button2.Name = "button2";
			this.button2.TabIndex = 15;
			this.button2.Text = "Gravar";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(480, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 23);
			this.button1.TabIndex = 14;
			this.button1.Text = "Procurar Filme";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 264);
			this.label6.Name = "label6";
			this.label6.TabIndex = 13;
			this.label6.Text = "Assistido Por:";
			// 
			// clbPessoa
			// 
			this.clbPessoa.Location = new System.Drawing.Point(128, 264);
			this.clbPessoa.Name = "clbPessoa";
			this.clbPessoa.Size = new System.Drawing.Size(440, 94);
			this.clbPessoa.TabIndex = 12;
			this.clbPessoa.Tag = "nm_Pessoa";
			// 
			// dataGrid2
			// 
			this.dataGrid2.CaptionVisible = false;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(8, 88);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.ReadOnly = true;
			this.dataGrid2.Size = new System.Drawing.Size(560, 128);
			this.dataGrid2.TabIndex = 11;
			// 
			// ddlTipoMidiaFilmeAssistidos
			// 
			this.ddlTipoMidiaFilmeAssistidos.DisplayMember = "nm_TipoMidia";
			this.ddlTipoMidiaFilmeAssistidos.Location = new System.Drawing.Point(120, 48);
			this.ddlTipoMidiaFilmeAssistidos.Name = "ddlTipoMidiaFilmeAssistidos";
			this.ddlTipoMidiaFilmeAssistidos.Size = new System.Drawing.Size(224, 21);
			this.ddlTipoMidiaFilmeAssistidos.TabIndex = 10;
			this.ddlTipoMidiaFilmeAssistidos.ValueMember = "nsu_TipoMidia";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 48);
			this.label5.Name = "label5";
			this.label5.TabIndex = 9;
			this.label5.Text = "Tipo de M�dia:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(224, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "Nome:";
			// 
			// tabPageAdicionar
			// 
			this.tabPageAdicionar.Controls.Add(this.btnLocalizacao);
			this.tabPageAdicionar.Controls.Add(this.lblLocalizacao);
			this.tabPageAdicionar.Controls.Add(this.ddlLocalizacaoAdicionar);
			this.tabPageAdicionar.Controls.Add(this.btnNovoTipoMidia);
			this.tabPageAdicionar.Controls.Add(this.btnNovoGenero);
			this.tabPageAdicionar.Controls.Add(this.btnGravar);
			this.tabPageAdicionar.Controls.Add(this.btnImagemFilme);
			this.tabPageAdicionar.Controls.Add(this.pictureBox1);
			this.tabPageAdicionar.Controls.Add(this.labelImagemFilme);
			this.tabPageAdicionar.Controls.Add(this.ddlTipoMidiaFilmeAdicionar);
			this.tabPageAdicionar.Controls.Add(this.ddlGeneroFilmeAdicionar);
			this.tabPageAdicionar.Controls.Add(this.dateTimePickerDataAquisicaoFilme);
			this.tabPageAdicionar.Controls.Add(this.labelDataAquisicao);
			this.tabPageAdicionar.Controls.Add(this.labelTipoMidia);
			this.tabPageAdicionar.Controls.Add(this.labelGeneroFilme);
			this.tabPageAdicionar.Controls.Add(this.txtNomeFilme);
			this.tabPageAdicionar.Controls.Add(this.labelNomeFilme);
			this.tabPageAdicionar.Location = new System.Drawing.Point(4, 22);
			this.tabPageAdicionar.Name = "tabPageAdicionar";
			this.tabPageAdicionar.Size = new System.Drawing.Size(592, 470);
			this.tabPageAdicionar.TabIndex = 2;
			this.tabPageAdicionar.Text = "Adicionar";
			// 
			// btnLocalizacao
			// 
			this.btnLocalizacao.Location = new System.Drawing.Point(376, 200);
			this.btnLocalizacao.Name = "btnLocalizacao";
			this.btnLocalizacao.Size = new System.Drawing.Size(176, 23);
			this.btnLocalizacao.TabIndex = 16;
			this.btnLocalizacao.Text = "Cadastrar Nova Localiza��o";
			this.btnLocalizacao.Click += new System.EventHandler(this.btnLocalizacao_Click);
			// 
			// lblLocalizacao
			// 
			this.lblLocalizacao.Location = new System.Drawing.Point(360, 144);
			this.lblLocalizacao.Name = "lblLocalizacao";
			this.lblLocalizacao.TabIndex = 15;
			this.lblLocalizacao.Text = "Localiza��o:";
			// 
			// ddlLocalizacaoAdicionar
			// 
			this.ddlLocalizacaoAdicionar.DisplayMember = "nm_Localizacao";
			this.ddlLocalizacaoAdicionar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlLocalizacaoAdicionar.Location = new System.Drawing.Point(360, 168);
			this.ddlLocalizacaoAdicionar.Name = "ddlLocalizacaoAdicionar";
			this.ddlLocalizacaoAdicionar.Size = new System.Drawing.Size(224, 21);
			this.ddlLocalizacaoAdicionar.TabIndex = 14;
			this.ddlLocalizacaoAdicionar.ValueMember = "nsu_Localizacao";
			// 
			// btnNovoTipoMidia
			// 
			this.btnNovoTipoMidia.Location = new System.Drawing.Point(376, 80);
			this.btnNovoTipoMidia.Name = "btnNovoTipoMidia";
			this.btnNovoTipoMidia.Size = new System.Drawing.Size(176, 23);
			this.btnNovoTipoMidia.TabIndex = 13;
			this.btnNovoTipoMidia.Text = "Cadastrar Novo Tipo de M�dia";
			this.btnNovoTipoMidia.Click += new System.EventHandler(this.btnNovoTipoMidia_Click);
			// 
			// btnNovoGenero
			// 
			this.btnNovoGenero.Location = new System.Drawing.Point(376, 48);
			this.btnNovoGenero.Name = "btnNovoGenero";
			this.btnNovoGenero.Size = new System.Drawing.Size(176, 23);
			this.btnNovoGenero.TabIndex = 12;
			this.btnNovoGenero.Text = "Cadastrar Novo G�nero";
			this.btnNovoGenero.Click += new System.EventHandler(this.btnNovoGenero_Click);
			// 
			// btnGravar
			// 
			this.btnGravar.Location = new System.Drawing.Point(496, 424);
			this.btnGravar.Name = "btnGravar";
			this.btnGravar.TabIndex = 11;
			this.btnGravar.Text = "Gravar";
			this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
			// 
			// btnImagemFilme
			// 
			this.btnImagemFilme.Location = new System.Drawing.Point(376, 280);
			this.btnImagemFilme.Name = "btnImagemFilme";
			this.btnImagemFilme.Size = new System.Drawing.Size(176, 23);
			this.btnImagemFilme.TabIndex = 10;
			this.btnImagemFilme.Text = "Adicionar Imagem";
			this.btnImagemFilme.Click += new System.EventHandler(this.btnImagemFilme_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Location = new System.Drawing.Point(120, 144);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(224, 304);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// labelImagemFilme
			// 
			this.labelImagemFilme.Location = new System.Drawing.Point(8, 144);
			this.labelImagemFilme.Name = "labelImagemFilme";
			this.labelImagemFilme.TabIndex = 8;
			this.labelImagemFilme.Text = "Imagem:";
			// 
			// ddlTipoMidiaFilmeAdicionar
			// 
			this.ddlTipoMidiaFilmeAdicionar.DisplayMember = "nm_TipoMidia";
			this.ddlTipoMidiaFilmeAdicionar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlTipoMidiaFilmeAdicionar.Location = new System.Drawing.Point(120, 80);
			this.ddlTipoMidiaFilmeAdicionar.Name = "ddlTipoMidiaFilmeAdicionar";
			this.ddlTipoMidiaFilmeAdicionar.Size = new System.Drawing.Size(224, 21);
			this.ddlTipoMidiaFilmeAdicionar.TabIndex = 7;
			this.ddlTipoMidiaFilmeAdicionar.ValueMember = "nsu_TipoMidia";
			// 
			// ddlGeneroFilmeAdicionar
			// 
			this.ddlGeneroFilmeAdicionar.DisplayMember = "nm_Genero";
			this.ddlGeneroFilmeAdicionar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlGeneroFilmeAdicionar.Location = new System.Drawing.Point(120, 48);
			this.ddlGeneroFilmeAdicionar.Name = "ddlGeneroFilmeAdicionar";
			this.ddlGeneroFilmeAdicionar.Size = new System.Drawing.Size(224, 21);
			this.ddlGeneroFilmeAdicionar.TabIndex = 6;
			this.ddlGeneroFilmeAdicionar.ValueMember = "nsu_Genero";
			// 
			// dateTimePickerDataAquisicaoFilme
			// 
			this.dateTimePickerDataAquisicaoFilme.Location = new System.Drawing.Point(120, 112);
			this.dateTimePickerDataAquisicaoFilme.Name = "dateTimePickerDataAquisicaoFilme";
			this.dateTimePickerDataAquisicaoFilme.Size = new System.Drawing.Size(224, 20);
			this.dateTimePickerDataAquisicaoFilme.TabIndex = 5;
			// 
			// labelDataAquisicao
			// 
			this.labelDataAquisicao.Location = new System.Drawing.Point(8, 112);
			this.labelDataAquisicao.Name = "labelDataAquisicao";
			this.labelDataAquisicao.TabIndex = 4;
			this.labelDataAquisicao.Text = "Data de Aquisi��o:";
			// 
			// labelTipoMidia
			// 
			this.labelTipoMidia.Location = new System.Drawing.Point(8, 80);
			this.labelTipoMidia.Name = "labelTipoMidia";
			this.labelTipoMidia.TabIndex = 3;
			this.labelTipoMidia.Text = "Tipo de M�dia:";
			// 
			// labelGeneroFilme
			// 
			this.labelGeneroFilme.Location = new System.Drawing.Point(8, 48);
			this.labelGeneroFilme.Name = "labelGeneroFilme";
			this.labelGeneroFilme.TabIndex = 2;
			this.labelGeneroFilme.Text = "G�nero:";
			// 
			// txtNomeFilme
			// 
			this.txtNomeFilme.Location = new System.Drawing.Point(120, 16);
			this.txtNomeFilme.Name = "txtNomeFilme";
			this.txtNomeFilme.Size = new System.Drawing.Size(224, 20);
			this.txtNomeFilme.TabIndex = 1;
			this.txtNomeFilme.Text = "";
			// 
			// labelNomeFilme
			// 
			this.labelNomeFilme.Location = new System.Drawing.Point(8, 16);
			this.labelNomeFilme.Name = "labelNomeFilme";
			this.labelNomeFilme.TabIndex = 0;
			this.labelNomeFilme.Text = "Nome:";
			// 
			// UserControlFilmes
			// 
			this.Controls.Add(this.tabControlFilmes);
			this.Name = "UserControlFilmes";
			this.Size = new System.Drawing.Size(616, 512);
			this.tabControlFilmes.ResumeLayout(false);
			this.tabPagePesquisar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPageAssistidos.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.tabPageAdicionar.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnImagemFilme_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				try
				{
					Image imagemOriginal = Image.FromFile(openFileDialog1.FileName);
					Image imagemResized = ResizeImage(imagemOriginal, pictureBox1.Width, pictureBox1.Height, true);
					pictureBox1.Image = imagemResized;
					pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

					binaryImagedata = StreamFile(openFileDialog1.FileName);
				}
				catch
				{
					MessageBox.Show ("N�o foi poss�vel adicionar a imagem!", "Erro!", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
			}
		}

		private void btnNovoGenero_Click(object sender, System.EventArgs e)
		{
			NovosTipos tipoGenero = new NovosTipos("G�nero de Filme");
			tipoGenero.Show();
		}

		private void btnLocalizacao_Click(object sender, System.EventArgs e)
		{
			NovosTipos tipoLocalizacao = new NovosTipos("Localiza��o");
			tipoLocalizacao.Show();
		}

		private void btnNovoTipoMidia_Click(object sender, System.EventArgs e)
		{
			NovosTipos tipoMidiaFilme = new NovosTipos("Tipo de M�dia de Filme");
			tipoMidiaFilme.Show();
		}

		private void btnGravar_Click(object sender, System.EventArgs e)
		{
			if (txtNomeFilme.Text == "")
			{
				MessageBox.Show ("N�o foi digitado um nome para o filme!", "Erro!", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				txtNomeFilme.Focus();
				return;
			}

			FilmeAtual.Nome = txtNomeFilme.Text;
			FilmeAtual.DataAquisicao = dateTimePickerDataAquisicaoFilme.Value;
			FilmeAtual.IDGenero = Convert.ToInt32(ddlGeneroFilmeAdicionar.SelectedValue);
			FilmeAtual.IDTipoMidia = Convert.ToInt32(ddlTipoMidiaFilmeAdicionar.SelectedValue);
			FilmeAtual.IDLocalizacao = Convert.ToInt32(ddlLocalizacaoAdicionar.SelectedValue);

			ItensLibrary.DO.FilmeDO.Gravar(FilmeAtual);

			// GRAVAR IMAGEM DEPOIS
		}

		#region M�todos Auxiliares
		// Extra�do de: http://snippets.dzone.com/posts/show/4336
		public Image ResizeImage(Image FullsizeImage, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
		{
			// Prevent using images internal thumbnail
			FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
			FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

			if (OnlyResizeIfWider)
			{
				if (FullsizeImage.Width <= NewWidth)
				{
					NewWidth = FullsizeImage.Width;
				}
			}

			int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
			if (NewHeight > MaxHeight)
			{
				// Resize with height instead
				NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
				NewHeight = MaxHeight;
			}

			Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
			return NewImage;

			// Clear handle to original file so that we can overwrite it if necessary
			//FullsizeImage.Dispose();
		}

		// Extra�do de: http://www.dotnetspider.com/resources/4515-convert-file-into-byte-array.aspx
		private byte[] StreamFile(string filename)
		{
			FileStream fs = new FileStream(filename, FileMode.Open,FileAccess.Read);

			// Create a byte array of file stream length
			byte[] ImageData = new byte[fs.Length];

			//Read block of bytes from stream into the byte array
			fs.Read(ImageData,0,System.Convert.ToInt32(fs.Length));

			//Close the File Stream
			fs.Close();
			return ImageData; //return the byte data
		}
		#endregion
	}
}
