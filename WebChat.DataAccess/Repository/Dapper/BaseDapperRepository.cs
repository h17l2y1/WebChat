using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.DataAccess.Config;
using WebChat.DataAccess.Repository.Interfaces;

namespace WebChat.DataAccess.Repository.Dapper
{
	public class BaseDapperRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		protected readonly string _tableName = $"{ typeof(TEntity).Name }s";
		protected readonly string _connectionString;

		protected IDbConnection Connection {
			get { return new SqlConnection(_connectionString); }
		}

		public BaseDapperRepository(IOptions<ConnectionStrings> connectionConfig)
		{
			var connection = connectionConfig.Value;
			_connectionString = connection.DefaultConnection;
		}

		public async Task Add(TEntity item)
		{
			await Connection.InsertAsync(item);
		}

		public async Task AddRange(IEnumerable<TEntity> entity)
		{
			await Connection.InsertAsync(entity);
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return await Connection.GetAllAsync<TEntity>();
		}

		public async Task<TEntity> Get(long id)
		{
			return await Connection.GetAsync<TEntity>(id);
		}

		public Task<IEnumerable<TEntity>> GetRange(IEnumerable<long> entityIdList)
		{
			throw new NotImplementedException();
		}

		public async Task Update(TEntity entity)
		{
			await Connection.UpdateAsync(entity);
		}

		public async Task Remove(TEntity entity)
		{
			await Connection.DeleteAsync(entity);
		}

		public async Task Remove(long id)
		{
			var entity = await Connection.GetAsync<TEntity>(id);
			await Connection.DeleteAsync(entity);
		}

		public async Task RemoveRange(IEnumerable<TEntity> entities)
		{
			await Connection.DeleteAsync(entities);
		}

		public async Task<int> GetCount()
		{
			var table = await Connection.GetAllAsync<TEntity>();
			var count = table.ToArray().Length;
			return count;
		}


	}
}
