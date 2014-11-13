using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace FCLScraper
{
    class DataScraper
    {
        // Member Variables
        private String pv_strURL;
        private String pv_strPatternStart;
        private String pv_strPatternEnd;
        private String pv_strPaginationParams;
        private List<String> pv_listToRemove;
        private Dictionary<String,String> pv_dicDataPatternsMainPage;
        private Dictionary<String, String> pv_dicDataPatternsSubPage;
        private CookieCollection pv_cookies = new CookieCollection();

        private PostDataParser pv_PostDataParser = null;
        private int pv_nStateNum = 0;
        // Member Functions
        public DataScraper(String strURL, String strPatternStart, String strPatternEnd)
        {
            pv_strURL = strURL;
            pv_strPatternStart = strPatternStart;
            pv_strPatternEnd = strPatternEnd;
            
            pv_strPaginationParams = "";

            pv_dicDataPatternsMainPage = new Dictionary<String, String>();
            pv_dicDataPatternsSubPage = new Dictionary<String, String>();
            pv_listToRemove = new List<string>();

            pv_PostDataParser = new PostDataParser(@"PostData.txt");
                
        }



        public void Start(int nMode)
        {
            String strHome = Settings.Default.HOMEURL;
            String strContents = "";

            // Simulate Opening the page using a browswer to get the cookies
            //GetWebPageByGET_S(strHome, "");
            //GetWebPageByGET_S(strHome + "?&", "");
            //GetWebPageByGET_S(strHome, "");
            strContents = GetWebPageByGET_S(Settings.Default.WELCOMEURL, "");

            pv_nStateNum = 2;

            // Simulate clicking Search button from Welcome Page using Request
            //GetResourceByGET_S("https://schooljobs.education.vic.gov.au/cs/ROLPPRD1_EA/cache/PSSTYLEREQ_3.css", strHome);
            //GetResourceByGET_S("https://schooljobs.education.vic.gov.au/cs/ROLPPRD1_EA/cache/PSSTYLEDEF_TANGERINE_5.css", strHome);
            //GetResourceByGET_S("https://schooljobs.education.vic.gov.au/cs/ROLPPRD1_EA/cache/PT_COMMON_MIN_5.js", strHome);
            //GetResourceByGET_S("https://schooljobs.education.vic.gov.au/cs/ROLPPRD1_EA/cache/PT_AJAX_NET_MIN_5.js", strHome);
            //GetResourceByGET_S("https://schooljobs.education.vic.gov.au/cs/ROLPPRD1_EA/cache/PT_PAGESCRIPT_win0_MIN_525.js", strHome);
            //GetResourceByGET_S("https://schooljobs.education.vic.gov.au/cs/ROLPPRD1_EA/cache/PT_PORTAL_IC_CLOSE_1.gif", strHome);
            //GetResourceByGET_S("https://schooljobs.education.vic.gov.au/cs/ROLPPRD1_EA/cache/DOEWELCOMEUPLOAD_410.JPG", strHome);
            //GetResourceByGET_S("https://schooljobs.education.vic.gov.au/cs/ROLPPRD1_EA/cache/PT_POPUPSCRIPT_win0_MIN_5.js", strHome);
            //GetResourceByGET_S("https://schooljobs.education.vic.gov.au/cs/ROLPPRD1_EA/cache/PT_GRIDSCRIPT_win0_MIN_5.js", strHome);
            //GetResourceByGET_S("https://schooljobs.education.vic.gov.au/cs/ROLPPRD1_EA/cache/PT_EDITSCRIPT_win0_MIN_1.js", strHome);
            //GetResourceByGET_S("https://schooljobs.education.vic.gov.au/cs/ROLPPRD1_EA/cache/PT_PIXEL_1.gif", strHome);
            //GetResourceByGET_S("https://schooljobs.education.vic.gov.au/favicon.ico", strHome);

            //strContents = GetWebPageByPOST(Settings.Default.WELCOMEPOSTURL, strContents, "HRS_CE_WELCM_WK_HRS_CE_WELCM_BTN", strHome);
            //strContents = GetWebPageByGET_S(pv_strURL, Settings.Default.URL);
            strContents = GetWebPageByPOST(Settings.Default.WELCOMEPOSTURL, strContents, "HRS_CE_WELCM_WK_HRS_CE_WELCM_BTN", strHome);
            strContents = GetWebPageByGET_S(Settings.Default.HOMEURL, Settings.Default.WELCOMEPOSTURL);
            
        }

        public String GeneratePOSTData(String strContents, String strAction)
        {
            String strPostData = "";

            int nCount = pv_PostDataParser.ListPostData.Count();
            int nCounter = 1;

            foreach (PostData item in pv_PostDataParser.ListPostData)
            {
                String strValue = "";
                if (item.Start == "#CONSTANT")
                {
                    strValue = item.End;
                }
                else
                {
                    if (item.Name == "ICStateNum")
                    {
                        strValue = string.Format("{0}", pv_nStateNum);
                        pv_nStateNum++;
                    }
                    else if (item.Name == "ICAction")
                    {
                        strValue = strAction;
                    }
                    else
                    {
                        if (item.Name == "ICFocus")
                        {
                            strValue = GetValueByPattern(ref strContents, item.Start, item.End, 0);
                        }
                        else
                        {
                            strValue = GetValueByPattern(ref strContents, item.Start, item.End, 0);
                        }
                    }
                }
                if (nCount > nCounter)
                {
                    strPostData = strPostData + item.Name + "=" +strValue + "&";

                }
                else
                {
                    strPostData = strPostData + item.Name + "=" + strValue;
                }

                nCounter++;
            }

            
            return strPostData;
        }


        // DoPaging is used to simulate click next button in the webpage
        // to navigate to the results
        public void DoPaging()
        {
            /*
            String strContents = "";
            int nTotalRows = 0;
            int nStartPos = 0;
            int nEndPos = 0;
            int nPrevPG = 1;
            int nCurrPG = 0;
            int nPageIncrement = 0;
            
            Int32.TryParse(pv_jobInfoData.PageIncrement, out nPageIncrement);

            if (pv_jobInfoData.MainHTTPVerb == "POST")
            {
                strContents = GetWebPageByPOST(pv_jobInfoData.JobsURL, nTotalRows, nPrevPG, nCurrPG, true);
            }
            else
            {
                strContents = GetWebPageByGET(pv_jobInfoData.JobsURL);
            }

            nStartPos = strContents.IndexOf(pv_jobInfoData.JobListingPatternStart);


            if (pv_jobInfoData.JobListingPatternEnd.Length > 0)
            {
                nEndPos = strContents.IndexOf(pv_jobInfoData.JobListingPatternEnd);
            }

            nTotalRows = GetTotalRows(ref strContents, 0);

            if (nStartPos > -1 && (nEndPos == 0 || (nStartPos < nEndPos)) && nTotalRows > 0)
            {
                ProcessPageContents(ref strContents, nStartPos);
                String strPagingURL = pv_jobInfoData.JobsURL;

                if (pv_jobInfoData.PagingURL != null && pv_jobInfoData.PagingURL.Length > 0)
                {
                    strPagingURL = pv_jobInfoData.PagingURL;
                }

                int nTotalPages = nTotalRows / nPageIncrement;

                for (int i = 2; i <= nTotalPages; i++)
                {

                    nCurrPG = i;

                    if (pv_jobInfoData.PagingHTTPVerb == "POST")
                    {
                        strContents = GetWebPageByPOST2(strPagingURL, ref strContents, nCurrPG);
                    }
                    else
                    {
                        strContents = GetWebPageByGET(strPagingURL);
                    }

                    nStartPos = strContents.IndexOf(pv_jobInfoData.JobListingPatternStart);
                    ProcessPageContents(ref strContents, nStartPos);
                    nPrevPG = nPrevPG + nPageIncrement;
                }
            }
             */
        }

        public void ProcessPageContents(ref String strContents, int nStartPos)
        {
            /*
            int nPatternPos = strContents.IndexOf(firstPattern.Start, nStartPos);
            int nPatternEndPos = nStartPos;
            int nPatternCount = pv_jobInfoData.MainPatterns.Count();

            
            while (nPatternPos > 0)
            {
            
                

                nPatternEndPos = strContents.IndexOf(firstPattern.End, nPatternPos + firstPattern.End.Length + 1);
                nPatternPos = strContents.IndexOf(firstPattern.Start, nPatternEndPos);
            }
             * */
        }

        public int GetTotalRows(ref String strContents, int nStartPos)
        {
            int nRetVal = 0;

            

            return nRetVal;
        }
        public void GetNextPage(String strPage, String strCount)
        {
        }

        public void SetPaginationInfo(String strPaginationParams)
        {
            pv_strPaginationParams = strPaginationParams;
        }

        public void AddMainPageDataPattern(String strStart, String strEnd)
        {
            if ( false == pv_dicDataPatternsMainPage.ContainsKey(strStart) )
            {
                pv_dicDataPatternsMainPage.Add(strStart, strEnd);
            }
        }

        public void AddSubPageDataPattern(String strStart, String strEnd)
        {
            if (false == pv_dicDataPatternsSubPage.ContainsKey(strStart))
            {
                pv_dicDataPatternsSubPage.Add(strStart, strEnd);
            }
        }

        public void AddToRemovePattern(String strToRemove)
        {
            pv_listToRemove.Add(strToRemove);
        }

        public void RemoveItemsUsingPattern(String strData)
        {
            if (pv_listToRemove.Count() > 0)
            {
                foreach (String strItem in pv_listToRemove)
                {
                    strData = strData.Replace(strItem, "");
                }
            }
        }
        

        public void InitializeClass()
        {
            
        }

        public static String GetValueByPattern(ref String strContents, String strPatternStart, String strPatternEnd, int nStart)
        {
            String strRetVal = "";
            // Get Internet Address
            int nPos = strContents.IndexOf(strPatternStart, nStart);
            if (nPos > -1)
            {
                int nPos2 = strContents.IndexOf(strPatternEnd, nPos + strPatternStart.Length);
                if (nPos2 > -1)
                {
                    strRetVal = strContents.Substring(nPos + strPatternStart.Length, nPos2 - nPos - strPatternStart.Length);
                    //Console.WriteLine(strRetVal);
                }
            }

            return StripTagsCharArray(strRetVal.Trim());
        }

        public static String GetValueByPattern2(ref String strContents, String strPatternStart, String strPatternEnd, String strPatternMid, int nStart)
        {
            String strRetVal = "";
            // Get Internet Address
            int nPos = strContents.IndexOf(strPatternStart, nStart);
            if (nPos > -1)
            {
                int nPosMid = strContents.IndexOf(strPatternMid, nPos + strPatternStart.Length + 1);
                if (nPosMid > -1)
                {
                    int nPosEnd = strContents.IndexOf(strPatternEnd, nPosMid + strPatternMid.Length + 1);
                    strRetVal = strContents.Substring(nPosMid + strPatternMid.Length, nPosEnd - nPosMid - strPatternMid.Length);
                    //Console.WriteLine(strRetVal);
                }
            }

            return StripTagsCharArray(strRetVal.Trim());
        }

        public static string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        
        public String GetWebPageByGET_S(String strURL, String strReferer)
        {
            // Create a request for the URL. 
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            String strContents = "";
            Console.WriteLine("Retrieving .. {0}", strURL);
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(strURL);
                request.Method = WebRequestMethods.Http.Get;
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.124 Safari/537.36";

               
                request.Credentials = CredentialCache.DefaultCredentials;
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(pv_cookies);
                request.Referer = strReferer;
                request.Headers.Add("Accept-Language: en-US,en;q=0.8,fil;q=0.6");
                request.Headers.Add("Accept-Encoding: gzip, deflate");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                
                //request.ProtocolVersion = HttpVersion.Version11;
                //request.AllowAutoRedirect = true;
                //request.Timeout = 20000;
                request.KeepAlive = true;
                //Get the response from the server and save the cookies from the first request..
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                strContents = reader.ReadToEnd();
                Console.Out.WriteLine(strContents);
                pv_cookies = response.Cookies;
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Response.ToString());                
            }

            return strContents;
            
        }

        public String GetResourceByGET_S(String strURL, String strReferer)
        {
            // Create a request for the URL. 
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            String strContents = "";
            Console.WriteLine("Retrieving .. {0}", strURL);
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(strURL);
                request.Method = WebRequestMethods.Http.Get;
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.124 Safari/537.36";


                request.Credentials = CredentialCache.DefaultCredentials;
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(pv_cookies);
                request.Referer = strReferer;
                request.Headers.Add("Accept-Language: en-US,en;q=0.8,fil;q=0.6");
                request.Headers.Add("Accept-Encoding: gzip, deflate");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                //request.ProtocolVersion = HttpVersion.Version11;
                //request.AllowAutoRedirect = true;
                //request.Timeout = 20000;
                request.KeepAlive = true;
                //Get the response from the server and save the cookies from the first request..
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                strContents = reader.ReadToEnd();
                Console.Out.WriteLine(strContents);                
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Response.ToString());
            }

            return strContents;

        }

        public String GetWebPageByGET(String strURL)
        {
            String strContents = "";
            Console.WriteLine("Retrieving .. {0}", strURL);
            
            WebRequest request = WebRequest.Create(strURL);
            // If required by the server, set the credentials.
            //request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            strContents = reader.ReadToEnd();
            // Display the content.
            //Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();


            return strContents;
            
             
        }
        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

                

        public String GetWebPageByPOST(String strURL, String strCurrPage, String strAction, String strReferer)
        {
            String strContents = "";
            String strPostData = GeneratePOSTData(strCurrPage, strAction);

            Console.WriteLine("Retrieving:" + strURL);
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            Console.WriteLine(strPostData);

            try
            {
                HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(strURL);
                getRequest.Proxy = null;
                getRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";

                getRequest.Credentials = CredentialCache.DefaultCredentials;
                
                getRequest.Method = "POST";
                getRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.124 Safari/537.36";
                getRequest.AllowWriteStreamBuffering = true;
                getRequest.Headers.Add("Accept-Language: en-US");
                getRequest.Headers.Add("Accept-Encoding: gzip, deflate");
                //getRequest.ProtocolVersion = HttpVersion.Version11;
                getRequest.AllowAutoRedirect = true;
                getRequest.Referer = strReferer;
                getRequest.KeepAlive = true;
                getRequest.ContentType = "application/x-www-form-urlencoded";
                getRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                getRequest.CookieContainer = new CookieContainer();
                getRequest.CookieContainer.Add(pv_cookies);

                strPostData = System.Net.WebUtility.UrlEncode(strPostData);

                byte[] byteArray = Encoding.UTF8.GetBytes(strPostData);
                getRequest.ContentLength = byteArray.Length;
                Stream newStream = getRequest.GetRequestStream(); //open connection
                newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
                newStream.Close();

                HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
                using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
                {
                    strContents = sr.ReadToEnd();
                }

                pv_cookies = getResponse.Cookies;
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    WebResponse resp = e.Response;
                    using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                    {
                        strContents = sr.ReadToEnd();
                        Console.WriteLine(strContents);
                    }
                }
            }

            return strContents;
        }
    }
}
