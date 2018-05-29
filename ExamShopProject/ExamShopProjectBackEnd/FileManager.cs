using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Renci.SshNet;

namespace ExamShopProjectBackEnd
{
    class FileManager
    {
        private static SftpClient ConnectMe()
        {
            SftpClient client = new SftpClient("10.152.120.37", "charlie", "char1234lie");
            return client;
        }
        public static bool FetchFile()
        {
            SftpClient client = ConnectMe();
            client.Connect();
            string remoteDirectory = "/home/indbakke/";
            string finalDir = "";
            string localDirectory = @"";
            using (var sftp = client)
            {
                //Console.WriteLine("Connecting to " + host + " as " + username);
                //sftp.Connect();
                //Console.WriteLine("Connected!");
                var files = sftp.ListDirectory(remoteDirectory);

                foreach (var file in files)
                {

                    string remoteFileName = file.Name;

                    if ((!file.Name.StartsWith(".")) /*&& ((file.LastWriteTime.Date == DateTime.Today))*/) //The date check needs to be reimplemented
                    {

                        finalDir = localDirectory;


                        if (!File.Exists(finalDir + file.Name))
                        {
                            //Console.WriteLine("Downloading file: " + file.Name);
                            using (Stream file1 = File.OpenWrite(finalDir + remoteFileName))
                            {
                                sftp.DownloadFile(remoteDirectory + remoteFileName, file1);
                            }
                        }
                    }
                }
            }
            
            return true;
        }

        public static bool PrepareFile(string fileName)
        {
            string newFileLocation = @"C:\Users\8570W\"+fileName;

            using (FileStream fs = new FileStream(newFileLocation, FileMode.Create))
            {
                var writer = new StreamWriter(fs, Encoding.Default);

                using (var reader = new StreamReader(fileName, Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        string companyId = values[0];
                        string interhangeId = values[1];
                        string productId = values[2];
                        string productName = values[3];
                        string productName2 = values[4];
                        string itemUnit = values[5];
                        string description = values[6];
                        string synonym = values[7];
                        string productGroup = values[8];
                        string weight = values[9];
                        string minQuantity = values[10];
                        string price = values[11];
                        string discount = values[12];
                        string netPrice = values[13];
                        string pCode = values[14];
                        string distCode = values[15];


                        price = price.Replace(',', '.'); // Converting decimal point so the BULK INSERT registers it correctly
                        string strippedDescription = StripHTML(description);
                        var productLine = string.Format("{0};{1};{2};{3};{4}", productId, productName, strippedDescription, price, productId.Substring(0, 4));
                        writer.WriteLine(productLine);
                        writer.Flush();
                    }
                }
                writer.Close();
                fs.Close();
                return true;
            }
        }

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

    }
}
