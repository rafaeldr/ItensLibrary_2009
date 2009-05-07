using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ItensLibrary
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnFilmes;
		private System.Windows.Forms.Button btnLivros;
		private System.Windows.Forms.Panel panelMenu;
		private System.Windows.Forms.Panel panelCanvas;
		
		private UserControlFilmes userControlFilmes = new UserControlFilmes();
		private UserControlLivros userControlLivros = new UserControlLivros();
		private System.Windows.Forms.Button btnJogos;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.panelMenu = new System.Windows.Forms.Panel();
			this.btnLivros = new System.Windows.Forms.Button();
			this.btnFilmes = new System.Windows.Forms.Button();
			this.panelCanvas = new System.Windows.Forms.Panel();
			this.btnJogos = new System.Windows.Forms.Button();
			this.panelMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMenu
			// 
			this.panelMenu.Controls.Add(this.btnJogos);
			this.panelMenu.Controls.Add(this.btnLivros);
			this.panelMenu.Controls.Add(this.btnFilmes);
			this.panelMenu.Location = new System.Drawing.Point(0, 8);
			this.panelMenu.Name = "panelMenu";
			this.panelMenu.Size = new System.Drawing.Size(184, 512);
			this.panelMenu.TabIndex = 0;
			// 
			// btnLivros
			// 
			this.btnLivros.Location = new System.Drawing.Point(16, 88);
			this.btnLivros.Name = "btnLivros";
			this.btnLivros.Size = new System.Drawing.Size(144, 32);
			this.btnLivros.TabIndex = 1;
			this.btnLivros.Text = "Livros";
			this.btnLivros.Click += new System.EventHandler(this.btnLivros_Click);
			// 
			// btnFilmes
			// 
			this.btnFilmes.Location = new System.Drawing.Point(16, 40);
			this.btnFilmes.Name = "btnFilmes";
			this.btnFilmes.Size = new System.Drawing.Size(144, 32);
			this.btnFilmes.TabIndex = 0;
			this.btnFilmes.Text = "Filmes";
			this.btnFilmes.Click += new System.EventHandler(this.btnFilmes_Click);
			// 
			// panelCanvas
			// 
			this.panelCanvas.Location = new System.Drawing.Point(192, 8);
			this.panelCanvas.Name = "panelCanvas";
			this.panelCanvas.Size = new System.Drawing.Size(616, 512);
			this.panelCanvas.TabIndex = 1;
			// 
			// btnJogos
			// 
			this.btnJogos.Location = new System.Drawing.Point(16, 136);
			this.btnJogos.Name = "btnJogos";
			this.btnJogos.Size = new System.Drawing.Size(144, 32);
			this.btnJogos.TabIndex = 2;
			this.btnJogos.Text = "Jogos";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 525);
			this.Controls.Add(this.panelCanvas);
			this.Controls.Add(this.panelMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "ItensLibrary";
			this.panelMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void btnFilmes_Click(object sender, System.EventArgs e)
		{
			panelCanvas.Controls.Clear();
			panelCanvas.Controls.Add(userControlFilmes);
		}

		private void btnLivros_Click(object sender, System.EventArgs e)
		{
			panelCanvas.Controls.Clear();
			panelCanvas.Controls.Add(userControlLivros);		
		}
	}
}
