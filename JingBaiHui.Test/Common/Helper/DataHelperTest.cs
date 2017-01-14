using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JingBaiHui.Common;
using JingBaiHui.Common.Helper;

namespace JingBaiHui.Test.Common.Helper
{
    [TestClass]
    public class DataHelperTest
    {
        [TestMethod]
        public void AddTest()
        {
            DataBase db = new DataBase("Test");
            DataHelper.Add(
                db, "test", new Dictionary<string, object>() { { "ID", "12123" } });
        }

        [TestMethod]
        public void UpdateTest()
        {
            DataBase db = new DataBase("Test");
            DataHelper.Update(
                db,
                "test",
                new Dictionary<string, object>() { { "ID", "12123" } },
                new Dictionary<string, object>() { { "Name", "123123" } }
           );
        }
    }
}