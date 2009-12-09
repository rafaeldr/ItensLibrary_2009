using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ItensLibrary
{
	/// <summary>
	/// Define mÈtodos auxiliares.
	/// Utilizado para evitar a duplicaÁ„o de cÛdigo.
	/// </summary>
	public class Util 
	{
		private Util(){}


		#region Ranges SQL Para ValidaÁ„o
		public static readonly DateTime MinSmallDateTimeSQL = new DateTime(1900,01,01);
		public static readonly DateTime MaxSmallDateTimeSQL = new DateTime(2079,06,06);
		#endregion

		#region FunÁıes Auxiliares para leitura no SqlDataReader

		#region N˙meros Inteiros

		public static long GetInt64(SqlDataReader mReader, string coluna) 
		{
			return GetInt64(mReader, coluna, 0);
		}
		public static long GetInt64(SqlDataReader mReader, string coluna, long nullValue) 
		{
			if( !mReader.IsDBNull(mReader.GetOrdinal(coluna)) )
				return mReader.GetInt64(mReader.GetOrdinal(coluna));
			return nullValue;
		}

		public static int GetInt32(SqlDataReader mReader, string coluna) 
		{
			return GetInt32(mReader, coluna, 0);
		}
		public static int GetInt32(SqlDataReader mReader, string coluna, int nullValue) 
		{
			if( !mReader.IsDBNull(mReader.GetOrdinal(coluna)) )
				return mReader.GetInt32(mReader.GetOrdinal(coluna));
			return nullValue;
		}

		public static short GetInt16(SqlDataReader mReader, string coluna) 
		{
			return GetInt16(mReader, coluna, 0);
		}
		public static short GetInt16(SqlDataReader mReader, string coluna, short nullValue) 
		{
			if( !mReader.IsDBNull(mReader.GetOrdinal(coluna)) )
				return mReader.GetInt16(mReader.GetOrdinal(coluna));
			return nullValue;
		}

		public static byte GetByte(SqlDataReader mReader, string coluna) 
		{
			return GetByte(mReader, coluna, 0);
		}
		public static byte GetByte(SqlDataReader mReader, string coluna, byte nullValue) 
		{
			if( !mReader.IsDBNull(mReader.GetOrdinal(coluna)) )
				return mReader.GetByte(mReader.GetOrdinal(coluna));
			return nullValue;
		}

		#endregion

		#region N˙meros Reais
		public static double GetDouble(SqlDataReader mReader, string coluna) 
		{
			return GetDouble(mReader, coluna, 0);
		}
		public static double GetDouble(SqlDataReader mReader, string coluna, double nullValue) 
		{
			if( !mReader.IsDBNull(mReader.GetOrdinal(coluna)) )
				return mReader.GetDouble(mReader.GetOrdinal(coluna));
			return nullValue;
		}

		public static decimal GetDecimal(SqlDataReader mReader, string coluna) 
		{
			return GetDecimal(mReader, coluna, 0);
		}
		public static decimal GetDecimal(SqlDataReader mReader, string coluna, decimal nullValue) 
		{
			if( !mReader.IsDBNull(mReader.GetOrdinal(coluna)) )
				return mReader.GetDecimal(mReader.GetOrdinal(coluna));
			return nullValue;
		}
		#endregion

		#region Caracteres

		public static string GetString(SqlDataReader mReader, string coluna) 
		{
			return GetString(mReader, coluna, null);
		}
		public static string GetString(SqlDataReader mReader, string coluna, string nullValue) 
		{
			if( !mReader.IsDBNull(mReader.GetOrdinal(coluna)) )
				return mReader.GetString(mReader.GetOrdinal(coluna));
			return nullValue;
		}

		public static char GetChar(SqlDataReader mReader, string coluna) 
		{
			return GetChar(mReader, coluna, char.MinValue);
		}
		public static char GetChar(SqlDataReader mReader, string coluna, char nullValue) 
		{
			string str = GetString(mReader, coluna);
			if(str != null && str.Length > 0)
				return str[0];
			else
				return nullValue;
		}
		

		/// <summary>
		/// 'S' = true
		/// 'N' = false
		/// null = true
		/// </summary>
		public static bool GetCharBoolean(SqlDataReader mReader, string coluna) 
		{
			return GetCharBoolean(mReader, coluna, true);
		}
		/// <summary>
		/// 'S','Y' = true
		/// 'N'     = false
		/// </summary>
		public static bool GetCharBoolean(SqlDataReader mReader, string coluna, bool nullValue) 
		{
			string str = GetString(mReader, coluna);
			if(str != null && str.Length > 0)
				return (str[0] == 'S' || str[0] == 'Y' || str[0] == 's' || str[0] == 'y');
			else
				return nullValue;
		}
		#endregion

		/// <summary>
		/// 1 = true
		/// 0 = false
		/// null = false
		/// </summary>
		public static bool GetBoolean(SqlDataReader mReader, string coluna) 
		{
			return GetBoolean(mReader, coluna, false);
		}
		/// <summary>
		/// 1 = true
		/// 0 = false
		/// </summary>
		public static bool GetBoolean(SqlDataReader mReader, string coluna, bool nullValue) 
		{
			if( !mReader.IsDBNull(mReader.GetOrdinal(coluna)) )
				return mReader.GetBoolean(mReader.GetOrdinal(coluna));
			return nullValue;
		}

		public static DateTime GetDateTime(SqlDataReader mReader, string coluna) 
		{
			return GetDateTime(mReader, coluna, Convert.ToDateTime(null));
		}
		public static DateTime GetDateTime(SqlDataReader mReader, string coluna, DateTime nullValue) 
		{
			if( !mReader.IsDBNull(mReader.GetOrdinal(coluna)) )
				return mReader.GetDateTime(mReader.GetOrdinal(coluna));
			return nullValue;
		}
		#endregion

		#region FunÁıes Auxiliares para passagem de par‚metros em um SqlCommand
		/// <summary>
		/// Retorna DbNull se o valor for igual nullValue,
		/// caso contr·rio retorna o prÛprio valor.
		/// Ex.:
		/// mCommand.Parameters.Add( "@nm_Correntista", SqlDbType.VarChar ).Value = Util.dbValue(Correntista, null, "");
		/// </summary>
		/// <param name="valor">O valor a ser testado</param>
		/// <param name="nullValues">valores considerados nulos</param>
		/// <returns>Retorna DbNull se [valor] for igual a algum dos [nullValues], caso contr·rio retorna [valor]</returns>
		public static object dbValue(object valor, params object[] nullValues)
		{
			if(valor == null)
				return DBNull.Value;

			foreach(object nullValue in nullValues)
				if(valor.Equals(nullValue))
					return DBNull.Value;

			return valor;
		}
		#endregion

		#region Select em um DataTable - obter uma ˙nica cÈlula.
		/// <summary>
		/// Efetua um Select em um DataTable.
		/// Retorna o resultado da primeira linha, na coluna [columnName].
		/// </summary>
		/// <param name="columnName">Nome da coluna a se obter.</param>
		/// <param name="dt">DataTable a se pesquisar.</param>
		/// <param name="filter">O Filtro da Pesquisa. Ex.: "cod_Loja = 51"</param>
		/// <param name="nullValue">Se n„o for encontrado nenhum resultado, ou se der algum erro, este ser· o valor retornado.</param>
		/// <returns>o resultado da primeira linha, na coluna [columnName].</returns>
		/// <example>
		/// long IDContaCorrente = (long)Util.SelectFromDataTable("nsu_ContaCorrente", mDataTable, "nsu_Inscricao = 1330", 0L)
		/// </example>
		public static object SelectFromDataTable(string columnName, DataTable dt, string filter, object nullValue)
		{
			DataRow[] drs = dt.Select(filter);

			if(drs.Length == 0)
				return nullValue;
			
			return drs[0][columnName];			
		}
		#endregion


		#region ExecuÁ„o de uma Stored Procedure que resulta em um Select no banco de dados.
		/// <summary>
		/// ExecuÁ„o de uma Stored Procedure que resulta em um select.
		/// Retorna um DataTable com o resultado.
		/// </summary>
		/// <param name="sqlCommand">O comando sql j· associado a uma conex„o, com o nome da proc e seus par‚metros</param>
		/// <returns>DataTable com o resultado</returns>
		/// <example>
		/// SqlCommand mCommand = new SqlCommand("dbo.crud_cpr_CCLancInscricao", Conexao.ObterConexao());
		/// mCommand.Parameters.Add("@nsu_Inscricao", SqlDbType.Int).Value = IDInscricao;
		/// DataTable dt = Util.ExecFill(mCommand);
		/// </example>
		public static DataTable ExecFill(SqlCommand sqlCommand)
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter mAdapter = new SqlDataAdapter(sqlCommand);

			DataTable mDataTable = new DataTable();
			mAdapter.Fill(mDataTable);

			return mDataTable;
		}
		#endregion


		#region DateTime com Dia/Mes/Ano

		public static DateTime Data(DateTime data) 
		{
			return data.Date;
		}

		public static DateTime DataAtual 
		{
			get 
			{
				return DateTime.Now.Date;
			}
		}
		#endregion

		#region Clonagem "profunda" de objetos serializ·veis
		/// <summary>
		/// Retorna um objeto clonado completamente.
		/// Este objeto precisa ser serializ·vel.
		/// </summary>
		/// <param name="dado">o objeto a ser clonado</param>
		/// <returns>uma cÛpia completa</returns>
		public static object DeepCopy(object dado) 
		{			
			MemoryStream stream = new MemoryStream(); 
			BinaryFormatter formatter = new BinaryFormatter();
 
			formatter.Serialize(stream, dado);
			stream.Position = 0;
			object copia = formatter.Deserialize(stream);
			stream.Close();
 
			return copia;
		}

		#endregion

		#region CÛdigo de ValidaÁ„o
		public static string GerarCodigoValidacao(string Nome, string DtNascimento)
		{
			string codValidacao;	
			bool bNomeValido;
			string[] nome = Nome.Split(' ');
			//vetor de palavras que n„o ser„o consideradas no cÛdigo de validaÁ„o
			string[] nomeExcluido = {"da", "das", "e", "de", "di", "dos", "do"};

			if(nome.Length > 0)
			{
				//pelo menos 3 primeiras letas do nome
				codValidacao = nome[0].Substring(0, nome[0].Length>2 ? 3: nome[0].Length);
				//comprimento do primeiro nome
				codValidacao += nome[0].Length;

				//percorre todos os nomes da pessoa
				for(int i=1;i<nome.Length;i++)
				{
					bNomeValido = true;
					for(int j=0;j<nomeExcluido.Length;j++)
					{
						//encontrou um nome inv·lido
						if ((nome[i].ToLower()).Equals(nomeExcluido[j]))
						{
							bNomeValido = false;
						}			
						
						if(nome[i].Trim() == "")
							bNomeValido = false;
					}
					
					//iniciais dos sobrenomes
					if (bNomeValido)
					{
						codValidacao += nome[i].Substring(0,1);
					}
				}

				//data de nascimento
				if(DtNascimento != "")
					codValidacao += Convert.ToDateTime(DtNascimento).ToString("dMyy");

				return SemAcentos(codValidacao.ToUpper());
			}
			else
				return "";	
		}

		#endregion

		#region SemAcentos
		/// <summary>
		/// Troca letras com acentos por letras sem acentos.
		/// PS: N„o tira todos os acentos e outras variaÁıes que existem nos caracteres UNICODE.
		/// Por exemplo: Â, a, A, L, É n„o ser„o considerados.
		/// Mas Á«·‡‚„‰¡¿¬√ƒÈËÍÎ…» ÀÌÏÓÔÕÃŒœÛÚÙıˆ”“‘’÷˙˘˚¸⁄Ÿ€‹ ser„o.
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string SemAcentos(string str)
		{
			char[] chars = str.ToCharArray();
			for(int i=0; i< chars.Length; i++)
				chars[i] = charSemAcento(chars[i]);
			return new String(chars);
		}
		private static char charSemAcento(char ch)
		{
			if(Char.IsUpper(ch))//Reduzindo o n˙mero de letras a se testar.
				return Char.ToUpper(charSemAcento(Char.ToLower(ch)));

			switch(ch)
			{
				case 'Á':
					return 'c';
				case '·':
				case '‡':
				case '‚':
				case '„':
				case '‰':
				case 'a':
					return 'a';
				case 'È':
				case 'Ë':
				case 'Í':
				case 'Î':
				case 'e':
					return 'e';
				case 'Ì':
				case 'Ï':
				case 'Ó':
				case 'Ô':
					return 'i';
				case 'Û':
				case 'Ú':
				case 'Ù':
				case 'ı':
				case 'ˆ':
					return 'o';
				case '˙':
				case '˘':
				case '˚':
				case '¸':
					return 'u';
				case '˝':
				case 'ˇ':
					return 'y';
			}
			return ch;
		}
		#endregion

	}
}