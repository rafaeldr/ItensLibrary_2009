using System;
using System.Data;
using System.Data.SqlClient;

namespace ItensLibrary.DO
{
	public class TipoMidiaFilmeDO
	{
		public static TipoMidiaFilme Selecionar(long ID)
		{
			return Selecionar(ID, new TipoMidiaFilme());
		}
		public static TipoMidiaFilme Selecionar(long ID, TipoMidiaFilme Dado )
		{
			SqlConnection mConnection = Conexao.ObterConexao();
			SqlCommand mCommand = new SqlCommand( "dbo.crud_Filme_TipoMidia_sel", mConnection );
			mCommand.CommandType = CommandType.StoredProcedure;
			mCommand.Parameters.Add( "@nsu_TipoMidia", SqlDbType.Int).Value = ID;

			SqlDataReader mReader = null;
			try
			{
				mReader = mCommand.ExecuteReader();
				if( mReader.Read() )
				{
					Dado.ID = Util.GetInt32(mReader, "nsu_TipoMidia");
					Dado.Nome = Util.GetString(mReader, "nm_TipoMidia");
				}
			}
			finally
			{
				Conexao.CloseReader(mReader, mCommand);
			}

			return Dado;
		}

		public static TipoMidiaFilme Gravar(TipoMidiaFilme Dado)
		{
			return Gravar( Dado, null);
		}
			
		public static TipoMidiaFilme Gravar(TipoMidiaFilme Dado, SqlTransaction Transacao)
		{
			SqlTransaction mTransacaoInterna = Conexao.AbrirTransacao(Transacao);

			SqlCommand mCommand = new SqlCommand();			
			mCommand.CommandType = CommandType.StoredProcedure;
			mCommand.Transaction = mTransacaoInterna;
			mCommand.Connection = mTransacaoInterna.Connection;

			mCommand.Parameters.Add( "@nm_TipoMidia", SqlDbType.VarChar ).Value = Dado.Nome;

			if ( Dado.ID == 0 )
			{
				mCommand.CommandText =  "dbo.crud_Filme_TipoMidia_ins";	
			}
			else
			{
				mCommand.Parameters.Add( "@nsu_TipoMidia", SqlDbType.Int ).Value = Dado.ID;
				mCommand.CommandText =  "dbo.crud_Filme_TipoMidia_upd";			
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

		public static DataTable Listar()
		{
			SqlDataAdapter mAdapter = new SqlDataAdapter();
			SqlConnection mConnection = Conexao.ObterConexao();
			SqlCommand mCommand = new SqlCommand( "dbo.crud_Filme_TipoMidia_list", mConnection );
			mCommand.CommandType = CommandType.StoredProcedure;
			mAdapter.SelectCommand = mCommand;

			DataTable mTable = new DataTable();
			
			try
			{
				mAdapter.Fill( mTable );
			}
			finally
			{
				mCommand.Cancel();
				if (mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			return mTable;
		}
	}
}
