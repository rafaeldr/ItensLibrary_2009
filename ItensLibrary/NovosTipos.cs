using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ItensLibrary
{
	/// <summary>
	/// Summary description for NovosTipos.
	/// </summary>
	public class NovosTipos : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblTipo;
		private System.Windows.Forms.TextBox txtTipo;
		private System.Windows.Forms.Label lblTopo;
		private System.Windows.Forms.Button btnAdicionar;
		private System.Windows.Forms.ListBox lbTipos;

		private string tipoAtual;
	
		public string TipoAtual
		{
			get
			{
				return tipoAtual;
			}
			set
			{
				tipoAtual = value;
			}
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NovosTipos(string Tipo)
		{
			InitializeComponent();

            TipoAtual = Tipo;
		
			lblTopo.Text = TipoAtual;
			this.Text = TipoAtual;

			switch (TipoAtual)
			{
				case "Gênero de Filme":
					lbTipos.DataSource = ItensLibrary.DO.GeneroFilmeDO.Listar();
					lbTipos.DisplayMember = "nm_Genero";
					break;
				case "Localização":
					lbTipos.DataSource = ItensLibrary.DO.LocalizacaoDO.Listar();
					lbTipos.DisplayMember = "nm_Localizacao";
					break;
				case "Tipo de Mídia de Filme":
					lbTipos.DataSource = ItensLibrary.DO.TipoMidiaFilmeDO.Listar();
					lbTipos.DisplayMember = "nm_TipoMidia";
					break;
			}
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblTipo = new System.Windows.Forms.Label();
			this.txtTipo = new System.Windows.Forms.TextBox();
			this.btnAdicionar = new System.Windows.Forms.Button();
			this.lblTopo = new System.Windows.Forms.Label();
			this.lbTipos = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// lblTipo
			// 
			this.lblTipo.Location = new System.Drawing.Point(8, 160);
			this.lblTipo.Name = "lblTipo";
			this.lblTipo.Size = new System.Drawing.Size(40, 16);
			this.lblTipo.TabIndex = 0;
			this.lblTipo.Text = "Nome:";
			// 
			// txtTipo
			// 
			this.txtTipo.Location = new System.Drawing.Point(56, 160);
			this.txtTipo.MaxLength = 30;
			this.txtTipo.Name = "txtTipo";
			this.txtTipo.Size = new System.Drawing.Size(128, 20);
			this.txtTipo.TabIndex = 1;
			this.txtTipo.Text = "";
			// 
			// btnAdicionar
			// 
			this.btnAdicionar.Location = new System.Drawing.Point(192, 160);
			this.btnAdicionar.Name = "btnAdicionar";
			this.btnAdicionar.TabIndex = 2;
			this.btnAdicionar.Text = "Adicionar";
			this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
			// 
			// lblTopo
			// 
			this.lblTopo.Location = new System.Drawing.Point(16, 8);
			this.lblTopo.Name = "lblTopo";
			this.lblTopo.Size = new System.Drawing.Size(240, 23);
			this.lblTopo.TabIndex = 4;
			this.lblTopo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbTipos
			// 
			this.lbTipos.Location = new System.Drawing.Point(8, 40);
			this.lbTipos.Name = "lbTipos";
			this.lbTipos.Size = new System.Drawing.Size(256, 108);
			this.lbTipos.TabIndex = 5;
			// 
			// NovosTipos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(280, 197);
			this.Controls.Add(this.lbTipos);
			this.Controls.Add(this.lblTopo);
			this.Controls.Add(this.btnAdicionar);
			this.Controls.Add(this.txtTipo);
			this.Controls.Add(this.lblTipo);
			this.Name = "NovosTipos";
			this.Text = "NovosTipos";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAdicionar_Click(object sender, System.EventArgs e)
		{
			if (txtTipo.Text == "")
			{
				MessageBox.Show ("Valor Inválido!", "Erro!", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				txtTipo.Focus();
				return;
			}

			switch (TipoAtual)
			{
				case "Gênero de Filme":
					GeneroFilme genero = new GeneroFilme();
					genero.Nome = txtTipo.Text;
					lbTipos.DataSource = ItensLibrary.DO.GeneroFilmeDO.Listar();
					break;
				case "Localização":
					Localizacao local = new Localizacao();
					local.Nome = txtTipo.Text;
					ItensLibrary.DO.LocalizacaoDO.Gravar(local);
					lbTipos.DataSource = ItensLibrary.DO.LocalizacaoDO.Listar();
					break;
				case "Tipo de Mídia de Filme":
					TipoMidiaFilme midia = new TipoMidiaFilme();
					midia.Nome = txtTipo.Text;
					ItensLibrary.DO.TipoMidiaFilmeDO.Gravar(midia);
					lbTipos.DataSource = ItensLibrary.DO.TipoMidiaFilmeDO.Listar();
					break;
			}
		}
	}
}
