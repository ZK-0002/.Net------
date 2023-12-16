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

            // ʹ�� Bing ��������
            string searchUrl = $"https://www.bing.com/search?q={keyword}";

            // �첽�������淽��
            await CrawlAsync(searchUrl);
        }

        private async Task CrawlAsync(string url)
{
    try
    {
        HttpClient httpClient = new HttpClient();
        string html = await httpClient.GetStringAsync(url);

        // ������ʽƥ��绰����
        Regex phoneRegex = new Regex(@"\b\d{3}[-.]?\d{3}[-.]?\d{4}\b");

        // ��ȡƥ�䵽�ĵ绰����
        List<string> phoneNumbers = new List<string>();

        // ѭ��ֱ���ҵ��㹻�ĵ绰����
        while (foundPhoneNumbersCount < 100)
        {
            // ƥ��绰����
            MatchCollection matches = phoneRegex.Matches(html);

            foreach (Match match in matches)
            {
                string phoneNumber = match.Value;

                // ����Ƿ����ҵ�100���绰����
                if (foundPhoneNumbersCount >= 100)
                    break;

                // ����Ƿ�Ϊ�ظ��绰����
                if (uniquePhoneNumbers.Add(phoneNumber))
                {
                    phoneNumbers.Add(phoneNumber);
                    AddCrawledUrl(url);
                    foundPhoneNumbersCount++;
                }
            }
        }

        // ������ȡ���ĵ绰����
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
            // ����绰���룬��¼ÿ���绰����������URL�������б������ʾ����ȡ��URL
            foreach (string phoneNumber in phoneNumbers)
            {
                RecordPhoneNumberUrl(phoneNumber, url);
            }

            // ��ʾ����ȡ��URL
            DisplayCrawledUrls();
        }

        private void RecordPhoneNumberUrl(string phoneNumber, string url)
        {
            lock (lockObject)
            {
                // ����ֵ����Ƿ��Ѵ��ڸõ绰����
                if (!phoneNumberUrlDictionary.ContainsKey(phoneNumber))
                {
                    phoneNumberUrlDictionary[phoneNumber] = new List<string>();
                }

                // ���URL���绰�����Ӧ���б���
                phoneNumberUrlDictionary[phoneNumber].Add(url);
            }
        }

        private void DisplayCrawledUrls()
        {
            // ��ListBox����ʾ����ȡ��URL
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
