using JingBaiHui.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static JingBaiHui.Common.DataBase;

namespace JingBaiHui.Common.Helper
{
    public static class DataHelper
    {
        /// <summary>
        /// 数据添加
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static object Add(DataBase db, string tableName, Dictionary<string, object> fields)
        {
            AssertHelper.IsTrue(db != null, "db is null");
            AssertHelper.IsTrue(!string.IsNullOrWhiteSpace(tableName), "tableName IsNullOrWhiteSpace");
            AssertHelper.IsTrue(fields.Count > 0, "fields.Count<=0");

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            StringBuilder sql = new StringBuilder();
            sql.Append($"INSERT INTO [dbo].[{tableName}]");
            sql.Append("(");

            foreach (var item in fields)
            {
                sql.Append($"[{item.Key}],");
            }
            string temp = sql.ToString().TrimEnd(',');
            sql.Clear();
            sql.Append(temp);
            sql.Append(")VALUES(");
            foreach (var item in fields)
            {
                sql.Append($"@{item.Key},");
                if (!parameters.ContainsKey($"@{item.Key}"))
                {
                    parameters.Add($"@{item.Key}", item.Value);
                }
            }
            temp = sql.ToString().TrimEnd(',');
            sql.Clear();
            sql.Append(temp);
            sql.Append(")");
            return db.ExecuteNoneQuery(sql.ToString(), parameters);
        }

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static object Delete(DataBase db, string tableName, Dictionary<string, object> filters)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            StringBuilder sql = new StringBuilder();
            sql.Append($"DELETE FROM [dbo].[{tableName}] WHERE ");
            foreach (var item in filters)
            {
                sql.Append($" [{item.Key}]=@{item.Key} AND");
                parameters.Add($"@{item.Key}", item.Value);
            }
            string temp = sql.ToString().TrimEnd("AND".ToCharArray());
            sql.Clear();
            sql.Append(temp);

            return db.ExecuteNoneQuery(sql.ToString(), parameters);
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        public static T GetEntity<T>(DataBase db, string sql, Dictionary<string, object> parameters, EntityConverter<T> converter) where T : class, new()
        {
            return db.GetEntity<T>(converter, sql, parameters);
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(DataBase db, string sql, Dictionary<string, object> parameters, EntityConverter<T> converter) where T : class, new()
        {
            return db.GetList<T>(converter, sql, parameters).ToList();
        }

        /// <summary>
        /// 分页获取集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="converter"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>内部用RowNumber() 分页</remarks>
        public static List<T> GetList<T>(DataBase db, string sql, Dictionary<String, Object> parameters, EntityConverter<T> converter, int pageIndex, int pageSize, string order) where T : class, new()
        {
            return db.GetList<T>(converter, sql, parameters, pageIndex, pageSize, order).ToList();
        }

        /// <summary>
        /// 通过存储过程获取集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        public static List<T> GetListProcedure<T>(
        DataBase db,
        string procedureName,
        List<DbParameterInfo> parameters,
        EntityConverter<T> converter

        ) where T : class, new()
        {
            return db.GetList<T>(converter, procedureName, parameters, CommandType.StoredProcedure).ToList();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <param name="fields"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static object Update(DataBase db, string tableName, Dictionary<string, object> fields, Dictionary<string, object> filters)
        {
            AssertHelper.IsTrue(db != null, "db is null");
            AssertHelper.IsTrue(!string.IsNullOrWhiteSpace(tableName), "tableName IsNullOrWhiteSpace");
            AssertHelper.IsTrue(fields.Count > 0, "fields.Count<=0");

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            StringBuilder sql = new StringBuilder();
            sql.Append($"UPDATE [dbo].[{tableName}] SET ");

            foreach (var item in fields)
            {
                sql.Append($"[{item.Key}]=@{item.Key},");
                if (!parameters.ContainsKey($"@{item.Key}"))
                {
                    parameters.Add($"@{item.Key}", item.Value);
                }
            }
            string temp = sql.ToString().TrimEnd(',');
            sql.Clear();
            sql.Append(temp);
            sql.Append(" WHERE ");
            foreach (var item in filters)
            {
                sql.Append($" [{item.Key}]=@{item.Key} AND");
                if (!parameters.ContainsKey($"@{item.Key}"))
                {
                    parameters.Add($"@{item.Key}", item.Value);
                }
            }
            temp = sql.ToString().TrimEnd("AND".ToCharArray());
            sql.Clear();
            sql.Append(temp);
            return db.ExecuteNoneQuery(sql.ToString(), parameters);
        }
    }
}