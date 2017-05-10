using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ProxyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.WaitAll(Test());

            Console.WriteLine("Hello World!");
        }

        static async Task Test()
        {
            HttpWebRequest hwr = WebRequest.CreateHttp("http://1212.ip138.com/ic.asp");
            hwr.Proxy = new MyProxy();
            WebResponse wr = await hwr.GetResponseAsync();
            StreamReader sr = new StreamReader(wr.GetResponseStream());
            string str = sr.ReadToEnd();
            Console.WriteLine(str);
        }
    }

    public class MyProxy : IWebProxy
    {
        public ICredentials Credentials { get; set; }

        public Uri GetProxy(Uri destination)
        {
            //http://www.cool-proxy.net/proxies/http_proxy_list/sort:score/direction:desc/page:1/country_code:CN/port:/anonymous:
            /*
             * https://github.com/henson/ProxyPool
             * 
             * 1. [快代理](http://www.kuaidaili.com)
2. [代理66](http://www.66ip.cn)
3. [IP181](http://www.ip181.com)
4. [有代理](http://www.youdaili.net/Daili/http/)
5. [西刺代理](http://www.xicidaili.com/nn/)
6. [guobanjia](http://www.goubanjia.com/free/gngn/index)
7. [讯代理](http://www.xdaili.cn/freeproxy.html)
8. [无忧代理](http://www.data5u.com/free/index.shtml)
9. [Proxylist+](https://list.proxylistplus.com)
             * */
            return new Uri("http://111.23.10.175:80");
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }
    }
}