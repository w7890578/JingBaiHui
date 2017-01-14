using JingBaiHui.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JingBaiHui.Common.Helper
{
    public class AssertHelper
    {
        public static void IsTrue(bool assertResult, string message)
        {
            if (!assertResult)
            {
                throw new AssertException(message);
            }
        }
    }
}