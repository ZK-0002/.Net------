using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05
{
    public partial class Form1 : Form
    {
        private readonly List<string> crawledUrls = new List<string>();
        private readonly HashSet<string> uniquePhoneNumbers = new HashSet<string>();
        private readonly Dictionary<string, List<string>> phoneNumberUrlDictionary = new Dictionary<string, List<string>>();
        private readonly object lockObject = new object();
        private int foundPhoneNumbersCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a keyword.");
                return;
            }

            // 使用 Bing 搜索引擎
            string searchUrl = $"https://www.bing.com/search?q={keyword}";

            // 异步调用爬虫方法
            await CrawlAsync(searchUrl);
        }

        private async Task CrawlAsync(string url)
{
    try
    {
        HttpClient httpClient = new HttpClient();
        string html = await httpClient.GetStringAsync(url);

        // 正则表达式匹配电话号码
        Regex phoneRegex = new Regex(@"\b\d{3}[-.]?\d{3}[-.]?\d{4}\b");

        // 提取匹配到的电话号码
        List<string> phoneNumbers = new List<string>();

        // 循环直到找到足够的电话号码
        while (foundPhoneNumbersCount < 100)
        {
            // 匹配电话号码
            MatchCollection matches = phoneRegex.Matches(html);

            foreach (Match match in matches)
            {
                string phoneNumber = match.Value;

                // 检查是否已找到100个电话号码
                if (foundPhoneNumbersCount >= 100)
                    break;

                // 检查是否为重复电话号码
                if (uniquePhoneNumbers.Add(phoneNumber))
                {
                    phoneNumbers.Add(phoneNumber);
                    AddCrawledUrl(url);
                    foundPhoneNumbersCount++;
                }
            }
        }

        // 处理爬取到的电话号码
        ProcessPhoneNumbers(phoneNumbers, url);
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}


        private void AddCrawledUrl(string url)
        {
            lock (lockObject)
            {
                crawledUrls.Add(url);
            }
        }

        private void ProcessPhoneNumbers(List<string> phoneNumbers, string url)
        {
            // 处理电话号码，记录每个电话号码所属的URL，并在列表框中显示已爬取的URL
            foreach (string phoneNumber in phoneNumbers)
            {
                RecordPhoneNumberUrl(phoneNumber, url);
            }

            // 显示已爬取的URL
            DisplayCrawledUrls();
        }

        private void RecordPhoneNumberUrl(string phoneNumber, string url)
        {
            lock (lockObject)
            {
                // 检查字典中是否已存在该电话号码
                if (!phoneNumberUrlDictionary.ContainsKey(phoneNumber))
                {
                    phoneNumberUrlDictionary[phoneNumber] = new List<string>();
                }

                // 添加URL到电话号码对应的列表中
                phoneNumberUrlDictionary[phoneNumber].Add(url);
            }
        }

        private void DisplayCrawledUrls()
        {
            // 在ListBox中显示已爬取的URL
            lstCrawledUrls.Items.Clear();
            lock (lockObject)
            {
                foreach (var entry in phoneNumberUrlDictionary)
                {
                    string phoneNumber = entry.Key;
                    List<string> urls = entry.Value;

                    foreach (string url in urls)
                    {
                        lstCrawledUrls.Items.Add($"Phone number: {phoneNumber}, URL: {url}");
                    }
                }
            }
        }
    }
}
