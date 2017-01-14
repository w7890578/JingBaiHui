using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JingBaiHui.Common
{
    public class LogHelper
    {
        public static void CmdError(Exception ex, DbCommand cmd)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetTraceInfo()}");
            sb.AppendLine($"{ex.GetType().ToString()}：{ex.Message}");
            sb.AppendLine(string.Format("服务器名称:{0},数据库名称:{1}", cmd.Connection.DataSource, cmd.Connection.Database));
            sb.AppendLine("SQL命令:" + cmd.CommandText);
            sb.AppendLine("参数:");
            for (int i = 0; i < cmd.Parameters.Count; i++)
            {
                sb.AppendLine(string.Format("{0}={1}", cmd.Parameters[i].ParameterName, cmd.Parameters[i].Value));
            }
            sb.AppendLine($"{ex.StackTrace}");
            Write(sb.ToString());
        }

        public static void Error(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetTraceInfo()}");
            sb.AppendLine($"{ex.GetType().ToString()}：{ex.Message}");
            sb.AppendLine($"{ex.StackTrace}");
            Write(sb.ToString());
        }

        public static void Error(Exception ex, string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetTraceInfo()}");
            sb.AppendLine($"{ex.GetType().ToString()}：{message}");
            sb.AppendLine($"{ex.StackTrace}");
            Write(sb.ToString());
        }

        private static string GetTraceInfo()
        {
            StackTrace trace = new StackTrace();
            MethodBase methodName = trace.GetFrame(2).GetMethod();
            string className = methodName.ReflectedType.FullName;
            return $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")}  {className}.{methodName.Name}";
        }

        private static void Write(string text)
        {
            string applicationName = ConfigurationManager.AppSettings["ApplicationName"] ?? "app";
            string folderPath = $"c:\\app.logfiles\\{applicationName}";
            //Web请求
            if (System.Web.HttpContext.Current != null)
            {
                folderPath = System.Web.HttpContext.Current.Server.MapPath("\\log.files");
            }

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string FileName = $"{folderPath}\\{DateTime.Now.ToString("yyyy-MM-dd")}.log";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine(text);
            StreamWriter sw = new StreamWriter(FileName, true);
            sw.Write(sb.ToString());
            sw.Dispose();
            sw.Close();
        }
    }
}