using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace CjbfU8CwebAPI.Helper
{
    public static class MyRandom
    {
        public static string GetMyRandom()
        {
            String strResult="";
            byte[] buffer = Guid.NewGuid().ToByteArray();     
            int iSeed = BitConverter.ToInt32(buffer, 0);     
            Random random = new Random(iSeed);
            strResult = random.Next().ToString();
            return strResult;
        }
    }
}