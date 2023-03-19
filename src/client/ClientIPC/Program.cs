using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;

using RemoteObjects;

namespace ClientIPC
{
    class Program
    {
        [STAThread]
        [SecurityPermission(SecurityAction.Demand)]
        static void Main(string[] args)
        {
            RemoteObject.CreateClient();
            RemoteObject ro = new RemoteObject();
            int nCount = 0;// IPC와 비교를 위한 숫자 변수 
            string sStr = "";// IPC와 비교를 위한 문자 변수
            while (true)
            {
                if (nCount != ro.Count)
                {
                    nCount = ro.Count;
                    sStr = ro.Str;
                    Console.WriteLine("{0}", nCount);
                    Console.WriteLine("서버입력={0}", sStr);
                }
            }
        }
    }
}
