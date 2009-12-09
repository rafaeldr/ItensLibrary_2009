using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ItensLibrary
{
	/// <summary>
	/// Implementa as rotinas padr�o de acesso a base de dados
	/// </summary>
	public class Conexao 
	{
		private static string mStrConexao;
		private static string StrConexao
		{
			get
			{
				if(mStrConexao == null)
				{
					mStrConexao = ConfigurationSettings.AppSettings["user"] + ";" +
						ConfigurationSettings.AppSettings["password"] + ";" +
						ConfigurationSettings.AppSettings["datasource"] + ";" +
						ConfigurationSettings.AppSettings["basecatalog"];
				}
				return mStrConexao;
			}
		}
		/// <summary>
		/// Devolve uma conex�o Aberta para o banco de dados da aplica��o.
		/// </summary>
		/// <returns></returns>
		static public SqlConnection ObterConexao() 
		{
			SqlConnection con = new SqlConnection(StrConexao);
			con.Open();

			return con;
		}

		/// <summary>
		/// Abre uma transa��o atrav�s da regra: se a TransacaoParametro for null,
		/// uma nova transa��o ser� retornada, caso contr�rio a pr�pria TransacaoParametro
		/// ser� retornada.
		/// </summary>
		/// <param name="TransacaoParametro"></param>
		/// <returns>Transa��o a ser utilizada</returns>
		public static SqlTransaction AbrirTransacao( SqlTransaction TransacaoParametro ) 
		{
			if( TransacaoParametro == null ) 
			{
				SqlConnection mConexao = ObterConexao();
				
				return mConexao.BeginTransaction();
			}
			else
				return TransacaoParametro;
		}

		/// <summary>
		/// Realiza commit na TransacaoInterna e fecha a conex�o se a Transa��oParametro for null, caso contr�rio
		/// n�o faz nada.
		/// </summary>
		/// <param name="TransacaoParametro"></param>
		/// <param name="TransacaoInterna"></param>
		public static void FecharTransacao( SqlTransaction TransacaoParametro, SqlTransaction TransacaoInterna ) 
		{
			if( TransacaoParametro == null ) 
			{
				SqlConnection mConexao = TransacaoInterna.Connection;
				if(mConexao != null && mConexao.State == ConnectionState.Open) 
				{
					TransacaoInterna.Commit();
					mConexao.Close();
				}
			}
		}

		/// <summary>
		/// Faz rollback e fecha a conex�o da transacao
		/// </summary>
		/// <param name="Transacao">Transa��o a fazer rollback</param>
		public static void RollbackTransacao( SqlTransaction Transacao ) 
		{
			if( Transacao != null && Transacao.Connection != null ) 
			{
				SqlConnection mConexao = Transacao.Connection;
				Transacao.Rollback();
				mConexao.Close();
			}
		}


		public static void CloseReader(SqlDataReader reader, SqlCommand command)
		{
			if(command.Connection.State == ConnectionState.Open)
				command.Cancel();//Este cancel serve apenas para aumentar a performance do reader.Close() (Segundo MSDN), e n�o faz sentido se n�o for chamado nesta ordem.

			if(reader != null)
			{
				reader.Close();
				GC.SuppressFinalize(reader); //Para melhor utiliza��o de mem�ria.
			}

			command.Connection.Close();
		}
	}
}
