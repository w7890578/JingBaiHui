using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JingBaiHui.Common;

namespace JingBaiHui.Test.Common.Helper
{
    [TestClass]
    public class LogHelperTest
    {
        [TestMethod]
        public void ErrorTest()
        {
            try
            {
                new Guid("sdf");
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex, "乱写文字");
            }
        }
    }
}