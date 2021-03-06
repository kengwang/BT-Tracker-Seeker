﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace BT_Tracker_Seeker
{

    class TrackerInfo
    {
        public string trackerurl;
        public bool useable = false;
        public string status = "未检测";
    }

    class DistinctItemComparer : IEqualityComparer<TrackerInfo>
    {

        public bool Equals(TrackerInfo x, TrackerInfo y)
        {
            return x.trackerurl == y.trackerurl;
        }

        public int GetHashCode(TrackerInfo obj)
        {
            return obj.trackerurl.GetHashCode();
        }
    }

    class Tracker
    {
        static List<TrackerInfo> trackerlist = new List<TrackerInfo>();

        //列表来源 - https://tieba.baidu.com/p/4980837770
        static string[] innerlist = { "udp://tracker.torrent.eu.org:451/announce", "udp://tracker.tiny-vps.com:6969/announce", "udp://tracker.sith.su:80/announce", "udp://tracker.mg64.net:6969/announce", "udp://tracker.leechers-paradise.org:6969/announce", "udp://tracker.kuroy.me:5944/announce", "udp://tracker.grepler.com:6969/announce", "udp://tracker.filetracker.pl:8089/announce", "udp://tracker.desu.sh:6969/announce", "udp://tracker.coppersurfer.tk:6969/announce", "udp://tracker.coppersurfer.tk:6969", "udp://p4p.arenabg.com:1337/announce", "udp://open.stealth.si:80/announce", "udp://mgtracker.org:2710/announce", "udp://ipv4.tracker.harry.lu:80/announce", "udp://bt.xxx-tracker.com:2710/announce", "udp://9.rarbg.com:2790/announce", "udp://208.67.16.113:8000/announce", "udp://168.235.67.63:6969/announce", "http://tracker2.wasabii.com.tw:6969/announce", "http://tracker1.wasabii.com.tw:6969/announce", "http://tracker1.itzmx.com:8080/announce", "http://tracker.vanitycore.co:6969/announce", "http://tracker.tiny-vps.com:6969/announce", "http://tracker.skyts.net:6969/announce", "udp://tracker.opentrackr.org:1337/announce", "http://tracker.mg64.net:6881/announce", "http://tracker.kamigami.org:2710/announce", "http://tracker.grepler.com:6969/announce", "http://tracker.filetracker.pl:8089/announce", "http://tracker.dler.org:6969/announce", "http://tracker.baravik.org:6970/announce", "http://torrentsmd.com:8080/announce", "http://share.camoe.cn:8080/announce", "http://p4p.arenabg.com:1337/announce", "http://mgtracker.org:6969/announce", "http://ipv4.tracker.harry.lu:80/announce", "http://ipv4.tracker.harry.lu:80/annouce", "http://ipv4.tracker.harry.lu/announce", "http://inferno.demonoid.ph:3415/announce", "http://inferno.demonoid.ooo:3418/announce", "http://inferno.demonoid.ooo:3416/announce", "http://inferno.demonoid.ooo:3412/announce", "http://inferno.demonoid.ooo:3410/announce", "http://inferno.demonoid.ooo:3395/announce", "udp://explodie.org:6969/announce", "http://bt.ttk.artvid.ru:6969/announce", "http://bt.artvid.ru:6969/announce", "http://87.248.186.252:8080/announce", "http://5.79.83.193:2710/announce", "http://0123456789nonexistent.com:80/announce", "http://0123456789nonexistent.com/announce", "udp://9.rarbg.me:2770/announce", "udp://62.138.0.158:6969/announce", "http://inferno.demonoid.ph:3392/announce", "http://173.254.204.71:1096/announce", "udp://tracker.ilibr.org:6969/announce", "http://www.skyts.net:6969/announce", "http://tracker4.itzmx.com:2710/announce", "http://t.nyaatracker.com/announce", "http://t.acg.rip:6699/announce", "http://mgtracker.org:2710/announce", "http://tracker.kuroy.me:5944/announce", "http://open.acgtracker.com:1096/announce", "http://tracker3.itzmx.com:6961/announce", "http://tracker2.itzmx.com:6961/announce", "http://retracker.gorcomnet.ru/announce", "udp://tracker.piratepublic.com:1337/announce", "http://tracker.xfsub.com:6868/announce", "udp://shadowshq.yi.org:6969/announce", "udp://eddie4.nl:6969/announce", "udp://208.67.16.113:8000/annonuce", "udp://shadowshq.eddie4.nl:6969/announce", "udp://tracker.kamigami.org:2710/announce", "udp://tracker.leechers-paradise.org:6969", "udp://9.rarbg.to:2740/announce", "udp://p4p.arenabg.ch:1337/announce", "http://bt.cnscg.com:6969/announce", "http://bt.cnscg.org:6969/announce", "http://secure.pow7.com/announce", "http://tracker.tfile.me/a", "http://tracker.tfile.me/announce", "http://retracker.gorcomnet.ru:80/announce" };
        static string[] trackersource = {
            "inner",//innnetlist
            "https://trackerslist.com/all.txt" ,//XIU2 - TrackersListCollection - 全
            "https://trackerslist.com/best.txt" ,//XIU2 - TrackersListCollection - 优
            "https://raw.githubusercontent.com/ngosang/trackerslist/master/trackers_all.txt",//trackerslist - 全部
            "https://raw.githubusercontent.com/ngosang/trackerslist/master/trackers_best.txt",//trackerslist - 最优
            "https://raw.githubusercontent.com/ngosang/trackerslist/master/trackers_all_ip.txt",//trackerslist - 全 - IP
            "https://newtrackon.com/api/stable?include_ipv6_only_trackers=0",//NewTrackon
            "https://raw.githubusercontent.com/1265578519/OpenTracker/master/tracker.txt",//OpenTracker
            "http://newtab.tysv.top:88/tracker-icoa.php"//dns.icoa.cn/tracker
        };
        public static bool checking = false;

        public static void CleanTrackers()
        {
            trackerlist.Clear();
        }

        public static bool GetTracker(int sourcen)
        {

            if (sourcen == 0)
            {
                foreach (string tracker in innerlist)
                {
                    if (tracker.Length >= 1)
                    {
                        TrackerInfo ti = new TrackerInfo();
                        ti.trackerurl = tracker;
                        trackerlist.Add(ti);
                    }

                }
                return true;
            }
            try
            {
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                var address = trackersource[sourcen];
                string content = client.DownloadString(address);
                string[] trackers = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.None);
                foreach (string tracker in trackers)
                {
                    if (tracker.Length >= 1)
                    {
                        TrackerInfo ti = new TrackerInfo();
                        ti.trackerurl = tracker;
                        trackerlist.Add(ti);
                    }
                }
                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "获取错误");
                return false;
            }

        }

        public static int GetTrackerCount()
        {
            return trackerlist.Count;
        }

        public static void TrackerDistinct()
        {//英语不好,名字不好定
            trackerlist = trackerlist.Distinct(new DistinctItemComparer()).ToList();
        }



        public static string GetTrackerList(int type)
        {
            string tl = "";
            foreach (TrackerInfo tracker in trackerlist)
            {
                tl += tracker.trackerurl + "\r\n";
            }
            return tl;
        }

        public static List<TrackerInfo> GetTrackerList()
        {
            return trackerlist;
        }

        public static void CheckTrackers()
        {
            checking = true;
            for (int i = 0; i < GetTrackerCount(); i++)
            {
                CheckTracker(trackerlist[i]);
            }
            checking = false;
            MessageBox.Show("检测完成,一共:" + Tracker.GetAvailibleNum());
        }

        public static void CheckTracker(TrackerInfo tracker)
        {
            string cb = GetTrackerCallback(tracker.trackerurl);
            tracker.status = cb;
            tracker.useable = (cb == "可用");
        }

        private static string GetTrackerCallback(string site)
        {
            try
            {
                Uri uri = new Uri(site);
                if (uri.Scheme == "http" || uri.Scheme == "https")
                {
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(site);
                    webRequest.Timeout = 4000;
                    // Sends the HttpWebRequest and waits for a response.
                    try
                    {
                        HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
                        if (httpWebResponse.StatusCode == HttpStatusCode.BadGateway || httpWebResponse.StatusCode == HttpStatusCode.BadRequest)
                        {
                            return "可用";
                        }
                    }
                    catch (WebException e)
                    {
                        if (e.Status == WebExceptionStatus.Timeout)
                        {
                            Console.WriteLine("{0} : {1}", site, "超时");
                            return "超时";
                        }
                        if (e.Status != WebExceptionStatus.ProtocolError)
                        {
                            return "协议错误";
                        }
                        HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;

                        if (code == HttpStatusCode.BadRequest || code == HttpStatusCode.BadGateway)
                        {
                            return "可用";
                        }
                        else
                        {
                            Console.WriteLine("{0} : {1}", site, code.ToString());
                            return code.ToString();
                        }

                    }

                }
                else if (uri.Scheme == "udp")
                {
                    try
                    {
                        UdpClient udpc = new UdpClient();
                        udpc.Connect(uri.Host, uri.Port);
                        Byte[] sendBytes = Encoding.ASCII.GetBytes("hash");
                        udpc.Send(sendBytes, sendBytes.Length);
                        return "可用";
                    }
                    catch (SocketException e)
                    {
                        if (e.SocketErrorCode == SocketError.Success)
                        {
                            Console.WriteLine("{0} ( {2} ) : {1}", site, "可用", uri.Host);
                            return "可用";
                        }
                        else
                        {
                            Console.WriteLine("{0} : {1}", site, e.Message);
                            return "UDP失败";
                        }
                    }

                }
                else
                {
                    Console.WriteLine("检测到暂不支持的协议: " + uri.Scheme);
                    return "不支持检测";
                }
                return "逻辑性失败: " + uri.Scheme;
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }

        public static bool AddRegularTracker(string tracker)
        {
            if (tracker.Length >= 1)
            {
                TrackerInfo ti = new TrackerInfo();
                ti.trackerurl = tracker;
                trackerlist.Add(ti);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetTotalNum()
        {
            return trackerlist.Count;
        }

        public static List<TrackerInfo> GetAvalibleTrackers()
        {
            return trackerlist;
        }

        public static int GetAvailibleNum()
        {
            int n = 0;
            foreach (TrackerInfo ti in trackerlist)
            {
                if (ti.useable)
                {
                    n++;
                }
            }
            return n;
        }

        public static List<TrackerInfo> GetAvailibleTrackers()
        {//0 - 全部,1 - Http/https,2 - udp,3. - 未知协议
            List<TrackerInfo> tal = new List<TrackerInfo>();
            foreach (TrackerInfo ti in trackerlist)
            {
                if (ti.useable)
                {
                    tal.Add(ti);
                }
            }
            return tal;
        }


    }

}
