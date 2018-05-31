using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

        public static bool ExportFile(string fileName)
        {
            SftpClient client = ConnectMe();
            client.Connect();
            string remoteDir = ""; // Should be /home/charlie/udbakke/ but permission is denied for right now
            string localDir = @"C:\Users\8570W\";


            client.ChangeDirectory(remoteDir);

            string uploadFile = localDir+fileName;
            using (var sftp = client)
            {
                using (var fileStream = new FileStream(uploadFile, FileMode.Open))
                {

                    client.BufferSize = 4 * 1024; // bypass Payload error large files
                    client.UploadFile(fileStream, uploadFile);
                }
            }

            return true;
        }

        public static void FetchFile()
        {
            do
            {
                SftpClient client = ConnectMe();
                client.Connect();
                string remoteDirectory = "/home/indbakke/";
                string finalDir = @"";
                using (var sftp = client)
                {
                    //Console.WriteLine("Connecting to " + host + " as " + username);
                    //sftp.Connect();
                    //Console.WriteLine("Connected!");
                    var files = sftp.ListDirectory(remoteDirectory);

                    foreach (var file in files)
                    {

                        string remoteFileName = file.Name;

                        if ((file.Name.StartsWith("ApEngros_PriCat_")) /*&& ((file.LastWriteTime.Date == DateTime.Today))*/) //The date check needs to be reimplemented
                        {


                            if (!File.Exists(finalDir + file.Name))
                            {
                                //Console.WriteLine("Downloading file: " + file.Name);
                                using (Stream file1 = File.OpenWrite(finalDir + remoteFileName))
                                {
                                    sftp.DownloadFile(remoteDirectory + remoteFileName, file1);
                                }
                                bool succes = PrepareFile(remoteFileName);
                            }
                        }
                    }
                }
                Thread.Sleep(600000);
            } while (true);
            
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

                        var productLine = string.Format("{0};{1};{2};{3};{4}", productId, productName, description, price, productGroup.Substring(0, 2));
                        writer.WriteLine(productLine);
                        writer.Flush();
                    }
                }
                writer.Close();
                fs.Close();
                return DB.ImportCatalogue(newFileLocation);
            }
        }

        public static StreamWriter CreateExportFileHeader(string fileName)
        {
            
            string fileLocation = @"C:\Users\8570W\" + fileName +".csv";

            using (FileStream fs = new FileStream(fileLocation, FileMode.Create))
            {
                var writer = new StreamWriter(fs, Encoding.Default);
                writer.WriteLine("ProductId;ProductName;Description;Price;");
                writer.Flush();

                return writer;
            }
            
        }

        public static bool WriteExportProductLine(StreamWriter writer, string productLine)
        {
            writer.WriteLine(productLine);
            writer.Flush();

            return true;
        }


    }
}
