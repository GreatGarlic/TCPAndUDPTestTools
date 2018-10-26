using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPAndUDPTestTools
{
    public class Utils
    {
        /// <summary>
        /// 十六进制字符串转byte数组.
        /// </summary>
        /// <param name="hexValues">字符串源.</param>
        /// <returns>byte[]</returns>
        public static byte[] StringToBytes(string hexValues)
        {
            List<byte> list = new List<byte>();
            string[] hexValuesSplit = hexValues.Split(' ');
            foreach (String hex in hexValuesSplit)
            {
                byte value = System.Convert.ToByte(hex, 16);
                list.Add(value);
            }
            return list.ToArray();
        }
    }
}
