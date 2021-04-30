using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;



//改进书上例子9-10的爬虫程序。
// （1）优选爬取起始网站上的网页 
//（2）只有当爬取的是html文本时，才解析并爬取下一级URL。
// （3）相对地址转成绝对地址进行爬取。
//（4）尝试使用Winform来配置初始URL，启动爬虫，显示已经爬取的URL和错误的URL信息。

namespace SimpleCrawler
{
    //一些注释掉的代码是我之前写的满足基本要求的版本，后来按照老师的代码进行了改进。
    public class Crawler
    {
        //public Hashtable urls = new Hashtable();
        //private int count = 0;
        //public string startUrl;

        public event Action<Crawler> CrawlerStopped;
        public event Action<Crawler, string, string> PageDownloaded;

        //已下载的URL，key是URL，value表示是否下载成功
        private Dictionary<string, bool> done = new Dictionary<string, bool>();

        //待下载队列
        private Queue<string> pending = new Queue<string>();

        //URL检测表达式，用于在HTML文本中查找URL
        private readonly string urlDetectRegex = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";

        //URL解析表达式
        public static readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
       
        public string HostFilter { get; set; } //主机过滤规则
        public string FileFilter { get; set; } //文件过滤规则
        public int MaxPage { get; set; } //最大下载数量
        public string StartURL { get; set; } //起始网址
        public Encoding HtmlEncoding { get; set; } //网页编码
        public Dictionary<string, bool> DownloadedPages { get; } //已下载网页

        public Crawler()
        {
            MaxPage = 100;
            HtmlEncoding = Encoding.UTF8;
        }

        public void Excute()
        {
            //this.startUrl = "http://www.cnblogs.com/dstang2000/";
            ////if (args.Length >= 1) myCrawler.startUrl = args[0];
            //this.urls.Add(this.startUrl, false);//加入初始页面
            //new Thread(this.Crawl).Start();

            done.Clear();
            pending.Clear();
            pending.Enqueue(StartURL);
            Crawl();

        }


        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = done.Count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private void Parse(string html, string startUrl)
        {
            //string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(urlDetectRegex).Matches(html);
            foreach (Match match in matches)
            {
                //strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                //          .Trim('"', '\"', '#', '>');
                //if (strRef.Length == 0) continue;
                //if (Regex.IsMatch(strRef, @"^/"))//改为绝对地址
                //{
                //    strRef = startUrl.Substring(0,startUrl.Length-1) + strRef;
                //}
                //if (urls[strRef] == null) urls[strRef] = false;
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "") continue;
                linkUrl = FixUrl(linkUrl, startUrl);//转绝对路径
                                                    //解析出host和file两个部分，进行过滤
                Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string file = linkUrlMatch.Groups["file"].Value;
                if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter)
                  && !done.ContainsKey(linkUrl))
                {
                    pending.Enqueue(linkUrl);
                }

            }
        }

        private void Crawl()
        {

            //爬取
            while (done.Count < MaxPage && pending.Count > 0)
            {
                string url = pending.Dequeue();
                try
                {
                    string html = DownLoad(url); // 下载
                    done[url] = true;
                    PageDownloaded(this, url, "success");
                    Parse(html, url);//解析,并加入新的链接
                }
                catch (Exception ex)
                {
                    PageDownloaded(this, url, "  Error:" + ex.Message);
                }
            }
            CrawlerStopped(this);

            //Console.WriteLine("开始爬行了.... ");
            //while (true)
            //{
            //    string current = null;
            //    foreach (string url in urls.Keys)
            //    {
            //        if ((bool)urls[url]) continue;
            //        current = url;
            //    }
            //    if (!Regex.IsMatch(current, @"^(https?://www.cnblogs.com/dstang2000)")) continue;
            //    if (current == null || count > 10) break;
            //    Console.WriteLine("爬行" + current + "页面!");


            //    string html = DownLoad(current); // 下载
            //    urls[current] = true;
            //    count++;
            //    Regex pthtml = new Regex(@"^(<!DOCTYPE\shtml>)");
            //    if (!pthtml.IsMatch(html))
            //    {
            //        Console.WriteLine("爬行结束");
            //        continue;
            //    }

            //    Parse(html,startUrl);//解析,并加入新的链接
            //    Console.WriteLine("爬行结束");

            //}
        }
        

        //将相对路径转为绝对路径
        private string FixUrl(string url, string pageUrl)
        {
            if (url.Contains("://"))
            {
                return url;
            }
            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
                String site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }

            if (url.StartsWith("../"))
            {
                url = url.Substring(3);
                int idx = pageUrl.LastIndexOf('/');
                return FixUrl(url, pageUrl.Substring(0, idx));
            }

            if (url.StartsWith("./"))
            {
                return FixUrl(url.Substring(2), pageUrl);
            }
            if (url.Contains("://"))
            {
                return url;
            }
            if (url.StartsWith("//"))
            {
                return "http:" + url;
            }

            int end = pageUrl.LastIndexOf("/");
            return pageUrl.Substring(0, end) + "/" + url;
        }
    }
}
