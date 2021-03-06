﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper
{
    public static partial class SqlMapper
    {
        /// <summary>
        /// Execute a query asynchronously using .NET 4.5 Task.
        /// </summary>
        public static async Task<IEnumerable<T>> QueryAsync<T>(this IDbConnection cnn, string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var identity = new Identity(sql, commandType, cnn, typeof(T), param == null ? null : param.GetType(), null);
            var info = GetCacheInfo(identity);
            var cmd = (DbCommand)SetupCommand(cnn, transaction, sql, info.ParamReader, param, commandTimeout, commandType);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                return ExecuteReader<T>(reader, identity, info).ToList();
            }
        }

        /// <summary>
        /// Maps a query to objects
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="cnn"></param>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn">The Field we should split and read the second object from (default: id)</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns></returns>
        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return MultiMapAsync<TFirst, TSecond, DontMap, DontMap, DontMap, DontMap, DontMap, TReturn>(cnn, sql, map, param as object, transaction, buffered, splitOn, commandTimeout, commandType);
        }

        /// <summary>
        /// Maps a query to objects
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TThird"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="cnn"></param>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn">The Field we should split and read the second object from (default: id)</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return MultiMapAsync<TFirst, TSecond, TThird, DontMap, DontMap, DontMap, DontMap, TReturn>(cnn, sql, map, param as object, transaction, buffered, splitOn, commandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi mapping query with 4 input parameters
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TThird"></typeparam>
        /// <typeparam name="TFourth"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="cnn"></param>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return MultiMapAsync<TFirst, TSecond, TThird, TFourth, DontMap, DontMap, DontMap, TReturn>(cnn, sql, map, param as object, transaction, buffered, splitOn, commandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi mapping query with 5 input parameters
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TThird"></typeparam>
        /// <typeparam name="TFourth"></typeparam>
        /// <typeparam name="TFifth"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="cnn"></param>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return MultiMapAsync<TFirst, TSecond, TThird, TFourth, TFifth, DontMap, DontMap, TReturn>(cnn, sql, map, param as object, transaction, buffered, splitOn, commandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi mapping query with 6 input parameters
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TThird"></typeparam>
        /// <typeparam name="TFourth"></typeparam>
        /// <typeparam name="TFifth"></typeparam>
        /// <typeparam name="TSixth"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="cnn"></param>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return MultiMapAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, DontMap, TReturn>(cnn, sql, map, param as object, transaction, buffered, splitOn, commandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi mapping query with 7 input parameters
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TThird"></typeparam>
        /// <typeparam name="TFourth"></typeparam>
        /// <typeparam name="TFifth"></typeparam>
        /// <typeparam name="TSixth"></typeparam>
        /// <typeparam name="TSeventh"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="cnn"></param>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return MultiMapAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(cnn, sql, map, param as object, transaction, buffered, splitOn, commandTimeout, commandType);
        }

        static async Task<IEnumerable<TReturn>> MultiMapAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(this IDbConnection cnn, string sql, object map, object param, IDbTransaction transaction, bool buffered, string splitOn, int? commandTimeout, CommandType? commandType)
        {
            var identity = new Identity(sql, commandType, cnn, typeof(TFirst), (object)param == null ? null : ((object)param).GetType(), new[] { typeof(TFirst), typeof(TSecond), typeof(TThird), typeof(TFourth), typeof(TFifth), typeof(TSixth), typeof(TSeventh) });
            var info = GetCacheInfo(identity);
            var cmd = (DbCommand)SetupCommand(cnn, transaction, sql, info.ParamReader, param, commandTimeout, commandType);
            using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
            {
                var results = MultiMapImpl<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(null, null, map, null, null, splitOn, null, null, reader, identity);
                return buffered ? results.ToList() : results;
            }
        }

        static IEnumerable<T> ExecuteReader<T>(IDataReader reader, Identity identity, CacheInfo info)
        {
            var tuple = info.Deserializer;
            int hash = GetColumnHash(reader);
            if (tuple.Func == null || tuple.Hash != hash)
            {
                tuple = info.Deserializer = new DeserializerState(hash, GetDeserializer(typeof(T), reader, 0, -1, false));
                SetQueryCache(identity, info);
            }

            var func = tuple.Func;

            while (reader.Read())
            {
                yield return (T)func(reader);
            }
        }

        /// <summary>
        /// Query Async Multiple
        /// </summary>
        /// <param name="cnn"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static async Task<GridReader> QueryMultipleAsync(this IDbConnection cnn, string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var identity = new Identity(sql, commandType, cnn, typeof(GridReader), (object)param == null ? null : ((object)param).GetType(), null);
            var info = GetCacheInfo(identity);

            DbCommand cmd = null;
            IDataReader reader = null;
            var wasClosed = cnn.State == ConnectionState.Closed;
            var commandBehavior = wasClosed ? CommandBehavior.CloseConnection : CommandBehavior.Default;
            try
            {
                if (wasClosed) cnn.Open();
                cmd = SetupCommand(cnn, transaction, sql, info.ParamReader, param, commandTimeout, commandType);
                reader = await cmd.ExecuteReaderAsync(commandBehavior).ConfigureAwait(false);

                var result = new GridReader(cmd, reader, identity);
                wasClosed = false; // *if* the connection was closed and we got this far, then we now have a reader
                // with the CloseConnection flag, so the reader will deal with the connection; we
                // still need something in the "finally" to ensure that broken SQL still results
                // in the connection closing itself
                return result;
            }
            catch
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                        try { cmd.Cancel(); }
                        catch { /* don't spoil the existing exception */ }
                    reader.Dispose();
                }
                if (cmd != null) cmd.Dispose();
                if (wasClosed) cnn.Close();
                throw;
            }
        }

        static async Task<int> ExecuteCommandAsync(IDbConnection cnn, IDbTransaction transaction, string sql, Action<IDbCommand, object> paramReader, object obj, int? commandTimeout, CommandType? commandType)
        {
            DbCommand cmd = null;
            bool wasClosed = cnn.State == ConnectionState.Closed;
            try
            {
                cmd = (DbCommand)SetupCommand(cnn, transaction, sql, paramReader, obj, commandTimeout, commandType);
                if (wasClosed) cnn.Open();
                return await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
            finally
            {
                if (wasClosed) cnn.Close();
                if (cmd != null) cmd.Dispose();
            }
        }

        /// <summary>
        /// Execute parameterized SQL where the parameter is an IEnumerable.
        /// </summary>
        /// <returns>Number of rows affected</returns>
        public static async Task<int> MultiExecuteAsync(this IDbConnection cnn, string sql, IEnumerable param, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            CacheInfo info = null;
            DbCommand firstCommand = null;
            int total = 0;
            var cmdTasks = new List<Task<int>>();
            foreach (var obj in param)
            {
                DbCommand cmd;
                if (firstCommand == null)
                {
                    firstCommand = cmd = (DbCommand)SetupCommand(cnn, transaction, sql, null, null, commandTimeout, commandType);
                    var identity = new Identity(sql, cmd.CommandType, cnn, null, obj.GetType(), null);
                    info = GetCacheInfo(identity);
                }
                else
                {
                    // Clone the first command
                    cmd = (DbCommand)cnn.CreateCommand();
                    cmd.CommandText = firstCommand.CommandText;
                    cmd.CommandType = firstCommand.CommandType;
                    cmd.CommandTimeout = firstCommand.CommandTimeout;
                    cmd.Transaction = firstCommand.Transaction;
                }
                info.ParamReader(cmd, obj);

                var resultTask = cmd.ExecuteNonQueryAsync().ContinueWith(et => {
                    cmd.Dispose();
                    return et.Result;
                }, TaskContinuationOptions.ExecuteSynchronously);
                cmdTasks.Add(resultTask);
            }
            foreach (var cmdTask in cmdTasks)
                total += await cmdTask.ConfigureAwait(false);
            return total;
        }

        /// <summary>
        /// Execute parameterized SQL where the parameter is an IEnumerable.
        /// </summary>
        /// <returns>Number of rows affected</returns>
        public static async Task<int> MultiExecuteAsyncSerialized(this IDbConnection cnn, string sql, IEnumerable param, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            CacheInfo info = null;
            bool isFirst = true;
            int total = 0;

            using (var cmd = (DbCommand)SetupCommand(cnn, transaction, sql, null, null, commandTimeout, commandType))
            {
                string masterSql = null;
                foreach (var obj in param)
                {
                    if (isFirst)
                    {
                        masterSql = cmd.CommandText;
                        isFirst = false;
                        var identity = new Identity(sql, cmd.CommandType, cnn, null, obj.GetType(), null);
                        info = GetCacheInfo(identity);
                    }
                    else
                    {
                        cmd.CommandText = masterSql;
                        cmd.Parameters.Clear();
                    }
                    info.ParamReader(cmd, obj);

                    total += await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }

            return total;
        }

        /// <summary>
        /// Execute parameterized SQL  
        /// </summary>
        /// <returns>Number of rows affected</returns>
        public static Task<int> ExecuteAsync(this IDbConnection cnn, string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, bool serialized = false)
        {
            IEnumerable multiExec = (object)param as IEnumerable;
            if (multiExec != null && !(multiExec is string))
            {
                if (serialized)
                    return MultiExecuteAsyncSerialized(cnn, sql, multiExec, transaction, commandTimeout, commandType);
                else
                    return MultiExecuteAsync(cnn, sql, multiExec, transaction, commandTimeout, commandType); 
            }

            // nice and simple
            CacheInfo info = null;
            if ((object)param != null)
            {
                var identity = new Identity(sql, commandType, cnn, null, (object)param == null ? null : ((object)param).GetType(), null);
                info = GetCacheInfo(identity);
            }
            return ExecuteCommandAsync(cnn, transaction, sql, (object)param == null ? null : info.ParamReader, (object)param, commandTimeout, commandType);
        }
    }
}