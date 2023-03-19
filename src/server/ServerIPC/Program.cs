using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;

using RemoteObjects;

namespace ServerIPC
{
    class Program
    {
        [STAThread]
        [SecurityPermission(SecurityAction.Demand)]
        static void Main(string[] args)
        {
            RemoteObject.CreateServer();
            RemoteObject ro = new RemoteObject();

            int nCount = 0;
            ro.Count = nCount;

            while (true)
            {
                Console.Write("아무키나 눌러주세요 , Q=종료");
                string tx = Console.ReadLine();

                if (tx.ToUpper() == "Q")
                {
                    break;
                }

                nCount++;
                ro.Count = nCount;
                ro.Str = tx;

                Console.WriteLine("카운터={0}", nCount);
            }
        }
    }
}
