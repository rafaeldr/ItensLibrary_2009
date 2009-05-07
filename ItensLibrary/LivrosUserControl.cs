using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ItensLibrary
{
	/// <summary>
	/// Summary description for LivrosUserControl.
	/// </summary>
	public class UserControlLivros : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TabControl tabControlLivros;
		private System.Windows.Forms.TabPage tabPagePesquisar;
		private System.Windows.Forms.TabPage tabPageAdicionar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelTituloLivro;
		private System.Windows.Forms.Label labelAutorLivro;
		private System.Windows.Forms.TextBox textBoxTituloLivro;
		private System.Windows.Forms.TextBox textBoxAutorLivro;
		private System.Windows.Forms.Label labelDataAquisicao;
		private System.Windows.Forms.DateTimePicker dateTimePickerDataAquisicaoLivro;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserControlLivros()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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
			this.tabControlLivros = new System.Windows.Forms.TabControl();
			this.tabPagePesquisar = new System.Windows.Forms.TabPage();
			this.tabPageAdicionar = new System.Windows.Forms.TabPage();
			this.textBoxTituloLivro = new System.Windows.Forms.TextBox();
			this.labelAutorLivro = new System.Windows.Forms.Label();
			this.labelDataAquisicao = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.labelTituloLivro = new System.Windows.Forms.Label();
			this.textBoxAutorLivro = new System.Windows.Forms.TextBox();
			this.dateTimePickerDataAquisicaoLivro = new System.Windows.Forms.DateTimePicker();
			this.tabControlLivros.SuspendLayout();
			this.tabPageAdicionar.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlLivros
			// 
			this.tabControlLivros.Controls.Add(this.tabPagePesquisar);
			this.tabControlLivros.Controls.Add(this.tabPageAdicionar);
			this.tabControlLivros.Location = new System.Drawing.Point(8, 8);
			this.tabControlLivros.Name = "tabControlLivros";
			this.tabControlLivros.SelectedIndex = 0;
			this.tabControlLivros.Size = new System.Drawing.Size(592, 496);
			this.tabControlLivros.TabIndex = 0;
			// 
			// tabPagePesquisar
			// 
			this.tabPagePesquisar.Location = new System.Drawing.Point(4, 22);
			this.tabPagePesquisar.Name = "tabPagePesquisar";
			this.tabPagePesquisar.Size = new System.Drawing.Size(584, 470);
			this.tabPagePesquisar.TabIndex = 0;
			this.tabPagePesquisar.Text = "Pesquisar";
			// 
			// tabPageAdicionar
			// 
			this.tabPageAdicionar.Controls.Add(this.dateTimePickerDataAquisicaoLivro);
			this.tabPageAdicionar.Controls.Add(this.textBoxAutorLivro);
			this.tabPageAdicionar.Controls.Add(this.textBoxTituloLivro);
			this.tabPageAdicionar.Controls.Add(this.labelAutorLivro);
			this.tabPageAdicionar.Controls.Add(this.labelDataAquisicao);
			this.tabPageAdicionar.Controls.Add(this.label2);
			this.tabPageAdicionar.Controls.Add(this.labelTituloLivro);
			this.tabPageAdicionar.Location = new System.Drawing.Point(4, 22);
			this.tabPageAdicionar.Name = "tabPageAdicionar";
			this.tabPageAdicionar.Size = new System.Drawing.Size(584, 470);
			this.tabPageAdicionar.TabIndex = 1;
			this.tabPageAdicionar.Text = "Adicionar";
			// 
			// textBoxTituloLivro
			// 
			this.textBoxTituloLivro.Location = new System.Drawing.Point(120, 16);
			this.textBoxTituloLivro.Name = "textBoxTituloLivro";
			this.textBoxTituloLivro.Size = new System.Drawing.Size(224, 20);
			this.textBoxTituloLivro.TabIndex = 4;
			this.textBoxTituloLivro.Text = "";
			// 
			// labelAutorLivro
			// 
			this.labelAutorLivro.Location = new System.Drawing.Point(8, 48);
			this.labelAutorLivro.Name = "labelAutorLivro";
			this.labelAutorLivro.TabIndex = 3;
			this.labelAutorLivro.Text = "Autor:";
			// 
			// labelDataAquisicao
			// 
			this.labelDataAquisicao.Location = new System.Drawing.Point(8, 112);
			this.labelDataAquisicao.Name = "labelDataAquisicao";
			this.labelDataAquisicao.TabIndex = 2;
			this.labelDataAquisicao.Text = "Data de Aquisição:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "label2";
			// 
			// labelTituloLivro
			// 
			this.labelTituloLivro.Location = new System.Drawing.Point(8, 16);
			this.labelTituloLivro.Name = "labelTituloLivro";
			this.labelTituloLivro.TabIndex = 0;
			this.labelTituloLivro.Text = "Título:";
			// 
			// textBoxAutorLivro
			// 
			this.textBoxAutorLivro.Location = new System.Drawing.Point(120, 48);
			this.textBoxAutorLivro.Name = "textBoxAutorLivro";
			this.textBoxAutorLivro.Size = new System.Drawing.Size(224, 20);
			this.textBoxAutorLivro.TabIndex = 5;
			this.textBoxAutorLivro.Text = "";
			// 
			// dateTimePickerDataAquisicaoLivro
			// 
			this.dateTimePickerDataAquisicaoLivro.Location = new System.Drawing.Point(120, 112);
			this.dateTimePickerDataAquisicaoLivro.Name = "dateTimePickerDataAquisicaoLivro";
			this.dateTimePickerDataAquisicaoLivro.Size = new System.Drawing.Size(224, 20);
			this.dateTimePickerDataAquisicaoLivro.TabIndex = 6;
			// 
			// UserControlLivros
			// 
			this.Controls.Add(this.tabControlLivros);
			this.Name = "UserControlLivros";
			this.Size = new System.Drawing.Size(616, 512);
			this.tabControlLivros.ResumeLayout(false);
			this.tabPageAdicionar.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
