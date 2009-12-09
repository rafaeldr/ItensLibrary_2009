using System;
using System.Data;
using System.Data.SqlClient;

namespace ItensLibrary.DO
{
	public class PessoaDO
	{
		public static Pessoa Selecionar(long ID)
		{
			return Selecionar(ID, new Pessoa());
		}

		public static Pessoa Selecionar(long ID, Pessoa Dado )
		{
			SqlConnection mConnection = Conexao.ObterConexao();
			SqlCommand mCommand = new SqlCommand( "dbo.crud_Pessoa_sel", mConnection );
			mCommand.CommandType = CommandType.StoredProcedure;
			mCommand.Parameters.Add( "@nsu_Pessoa", SqlDbType.Int).Value = ID;

			SqlDataReader mReader = null;
			try
			{
				mReader = mCommand.ExecuteReader();
				if( mReader.Read() )
				{
					Dado.ID = Util.GetInt32(mReader, "nsu_Pessoa");
					Dado.Nome = Util.GetString(mReader, "nm_Pessoa");
				}
			}
			finally
			{
				Conexao.CloseReader(mReader, mCommand);
			}

			return Dado;
		}

		public static Pessoa Gravar(Pessoa Dado)
		{
			return Gravar( Dado, null);
		}
			
		public static Pessoa Gravar(Pessoa Dado, SqlTransaction Transacao)
		{
			SqlTransaction mTransacaoInterna = Conexao.AbrirTransacao(Transacao);

			SqlCommand mCommand = new SqlCommand();			
			mCommand.CommandType = CommandType.StoredProcedure;
			mCommand.Transaction = mTransacaoInterna;
			mCommand.Connection = mTransacaoInterna.Connection;


			mCommand.Parameters.Add( "@nsu_Pessoa", SqlDbType.Int ).Value = Dado.ID;
			mCommand.Parameters.Add( "@nm_Pessoa", SqlDbType.VarChar ).Value = Dado.Nome;

			if ( Dado.ID == 0 )
			{
				mCommand.CommandText =  "dbo.crud_Pessoa_ins";	
			}
			else
			{
				mCommand.CommandText =  "dbo.crud_Pessoa_upd";			
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
			SqlCommand mCommand = new SqlCommand( "dbo.crud_Pessoa_list", mConnection );
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
