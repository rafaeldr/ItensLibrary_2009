using System;
using System.Data;
using System.Data.SqlClient;

namespace ItensLibrary.DO
{
	public class GeneroFilmeDO
	{
		public static GeneroFilme Selecionar(long ID)
		{
			return Selecionar(ID, new GeneroFilme());
		}
		public static GeneroFilme Selecionar(long ID, GeneroFilme Dado )
		{
			SqlConnection mConnection = Conexao.ObterConexao();
			SqlCommand mCommand = new SqlCommand( "dbo.crud_Filme_Genero_sel", mConnection );
			mCommand.CommandType = CommandType.StoredProcedure;
			mCommand.Parameters.Add( "@nsu_Genero", SqlDbType.Int).Value = ID;

			SqlDataReader mReader = null;
			try
			{
				mReader = mCommand.ExecuteReader();
				if( mReader.Read() )
				{
					Dado.ID = Util.GetInt32(mReader, "nsu_Genero");
					Dado.Nome = Util.GetString(mReader, "nm_Genero");
				}
			}
			finally
			{
				Conexao.CloseReader(mReader, mCommand);
			}

			return Dado;
		}

		public static GeneroFilme Gravar(GeneroFilme Dado)
		{
			return Gravar( Dado, null);
		}
			
		public static GeneroFilme Gravar(GeneroFilme Dado, SqlTransaction Transacao)
		{
			SqlTransaction mTransacaoInterna = Conexao.AbrirTransacao(Transacao);

			SqlCommand mCommand = new SqlCommand();			
			mCommand.CommandType = CommandType.StoredProcedure;
			mCommand.Transaction = mTransacaoInterna;
			mCommand.Connection = mTransacaoInterna.Connection;


			mCommand.Parameters.Add( "@nsu_Genero", SqlDbType.Int ).Value = Dado.ID;
			mCommand.Parameters.Add( "@nm_Genero", SqlDbType.VarChar ).Value = Dado.Nome;

			if ( Dado.ID == 0 )
			{
				mCommand.CommandText =  "dbo.crud_Filme_Genero_ins";	
			}
			else
			{
				mCommand.CommandText =  "dbo.crud_Filme_Genero_upd";			
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
			SqlCommand mCommand = new SqlCommand( "dbo.crud_Filme_Genero_list", mConnection );
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
