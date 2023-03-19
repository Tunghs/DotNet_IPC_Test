using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace RemoteObjects
{
    public class RemoteObject : MarshalByRefObject
    {
        static int count = 0;
        static string str = "";

        public int Count
        {
            get { return RemoteObject.count; }
            set { RemoteObject.count = value; }
        }

        public string Str
        {
            get { return RemoteObject.str; }
            set { RemoteObject.str = value; }
        }

        public static void CreateServer()
        {
            try
            {
                IpcServerChannel svr = new IpcServerChannel("remote"); //remote 포트 만들기
                ChannelServices.RegisterChannel(svr, false); // 채널 등록
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject), "test", WellKnownObjectMode.SingleCall); // 원격 객체 준비작업

                Console.WriteLine("서버 시작 " + svr.GetChannelUri());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void CreateClient()
        {
            IpcClientChannel clientChannel = new IpcClientChannel();


            //클라이언트  생성
            ChannelServices.RegisterChannel(clientChannel, false);
            RemotingConfiguration.RegisterWellKnownClientType(typeof(RemoteObject), "ipc://remote/test");
        }
    }
}
