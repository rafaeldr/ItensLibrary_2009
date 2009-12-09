using System;

namespace ItensLibrary
{
	#region Filme
	public class Filme
	{
		#region Propriedades
		int _ID;
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}
		string _nome;
		public string Nome
		{
			get
			{
				return _nome;
			}
			set
			{
				_nome = value;
			}
		}

		int	_genero;
		public int IDGenero
		{
			get
			{
				return _genero;
			}
			set
			{
				_genero = value;
			}
		}

		int _tipoMidia;
		public int IDTipoMidia
		{
			get
			{
				return _tipoMidia;
			}
			set
			{
				_tipoMidia = value;
			}
		}

		DateTime _dataAquisicao;
		public DateTime DataAquisicao
		{
			get
			{
				return _dataAquisicao;
			}
			set
			{
				_dataAquisicao = value;
			}
		}

		int _localizacao;
		public int IDLocalizacao
		{
			get
			{
				return _localizacao;
			}
			set
			{
				_localizacao = value;
			}
		}

		int _imagem;
		public int IDImagem
		{
			get
			{
				return _imagem;
			}
			set
			{
				_imagem = value;
			}
		}

		#endregion
	}

	public class GeneroFilme
	{
		int _ID;
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}
		string _nome;
		public string Nome
		{
			get
			{
				return _nome;
			}
			set
			{
				_nome = value;
			}
		}
	}

	public class TipoMidiaFilme
	{
		int _ID;
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}
		string _nome;
		public string Nome
		{
			get
			{
				return _nome;
			}
			set
			{
				_nome = value;
			}
		}
	}
	#endregion

	public class Localizacao
	{
		int _ID;
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}
		string _nome;
		public string Nome
		{
			get
			{
				return _nome;
			}
			set
			{
				_nome = value;
			}
		}
	}

	public class Pessoa
	{
		int _ID;
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}
		string _nome;
		public string Nome
		{
			get
			{
				return _nome;
			}
			set
			{
				_nome = value;
			}
		}
	}
	
	public class Livro
	{

	}

	public class Jogo
	{

	}
}
