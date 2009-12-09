using System;
using System.Data;
using System.Data.SqlClient;

namespace ItensLibrary.DO
{
	public class FilmeDO
	{
		public static Filme Selecionar(long ID)
		{
			return Selecionar(ID, new Filme());
		}
		public static Filme Selecionar(long ID, Filme Dado )
		{
			SqlConnection mConnection = Conexao.ObterConexao();
			SqlCommand mCommand = new SqlCommand( "dbo.crud_Filme_sel", mConnection );
			mCommand.CommandType = CommandType.StoredProcedure;
			mCommand.Parameters.Add( "@nsu_Filme", SqlDbType.Int).Value = ID;

			SqlDataReader mReader = null;
			try
			{
				mReader = mCommand.ExecuteReader();
				if( mReader.Read() )
				{
					Dado.ID = Util.GetInt32(mReader, "nsu_Filme");
					Dado.Nome = Util.GetString(mReader, "nm_Filme");
					Dado.IDGenero = Util.GetInt32(mReader, "nsu_Genero");
					Dado.IDImagem = Util.GetInt32(mReader, "nsu_Imagem");
					Dado.IDLocalizacao = Util.GetInt32(mReader, "nsu_Localizacao");
					Dado.IDTipoMidia = Util.GetInt32(mReader, "nsu_TipoMidia");
				}
			}
			finally
			{
				Conexao.CloseReader(mReader, mCommand);
			}

			return Dado;
		}

		public static Filme Gravar(Filme Dado)
		{
			return Gravar( Dado, null);
		}
			
		public static Filme Gravar(Filme Dado, SqlTransaction Transacao)
		{
			SqlTransaction mTransacaoInterna = Conexao.AbrirTransacao(Transacao);

			SqlCommand mCommand = new SqlCommand();			
			mCommand.CommandType = CommandType.StoredProcedure;
			mCommand.Transaction = mTransacaoInterna;
			mCommand.Connection = mTransacaoInterna.Connection;

			mCommand.Parameters.Add( "@nm_Filme", SqlDbType.VarChar ).Value = Dado.Nome;
			mCommand.Parameters.Add( "@nsu_Genero", SqlDbType.Int ).Value = Util.dbValue(Dado.IDGenero, 0);
			mCommand.Parameters.Add( "@nsu_TipoMidia", SqlDbType.Int).Value = Util.dbValue(Dado.IDTipoMidia, 0);
			mCommand.Parameters.Add( "@nsu_Localizacao", SqlDbType.Int).Value = Util.dbValue(Dado.IDLocalizacao, 0);
			mCommand.Parameters.Add( "@dt_Aquisicao", SqlDbType.DateTime).Value = Dado.DataAquisicao;

			if ( Dado.ID == 0 )
			{
				mCommand.CommandText =  "dbo.crud_Filme_ins";
				//email.ID = Convert.ToInt64(mCommand.ExecuteScalar());
			}
			else
			{
				mCommand.Parameters.Add( "@nsu_Filme", SqlDbType.Int ).Value = Dado.ID;
				mCommand.CommandText =  "dbo.crud_Filme_upd";			
			}
			try
			{
				mCommand.ExecuteNonQuery();
			}
			catch 
			{
				Conexao.RollbackTransacao( mTransacaoInterna );
				throw;
			}

			Conexao.FecharTransacao( Transacao , mTransacaoInterna );
		
			return Dado;
		}
	}
}
