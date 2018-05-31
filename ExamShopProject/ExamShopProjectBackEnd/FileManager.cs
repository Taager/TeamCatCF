using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Renci.SshNet;
using System.Configuration;

namespace ExamShopProjectBackEnd
{
    class FileManager
    {
        private static SftpClient ConnectMe() // Establish an SFTP CLient
        {
            SftpClient client = new SftpClient(ConfigurationManager.AppSettings["ServerIP"].ToString(), ConfigurationManager.AppSettings["ServerUserName"].ToString(), ConfigurationManager.AppSettings["ServerUserPW"].ToString());
            return client;
        }

        public static bool ExportFile(string fileName)
        {
            SftpClient client = ConnectMe();
            client.Connect();
            string remoteDir = ConfigurationManager.AppSettings["ExportDir"].ToString(); // Where to send the fíle
            string localDir = ConfigurationManager.AppSettings["MyBaseDir"].ToString(); // Where to currently find the file


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
                string remoteDirectory = ConfigurationManager.AppSettings["ImportDir"].ToString(); // Where to find the files
                string finalDir = @"";
                using (var sftp = client)
                {
                    var files = sftp.ListDirectory(remoteDirectory);
                    foreach (var file in files)
                    {
                        string remoteFileName = file.Name;
                        if ((file.Name.StartsWith(ConfigurationManager.AppSettings["ImportFilePrefix"].ToString())) /*&& ((file.LastWriteTime.Date == DateTime.Today))*/ ) //The date check needs to be reimplemented
                        {
                            if (!File.Exists(finalDir + file.Name))
                            {
                                using (Stream file1 = File.OpenWrite(finalDir + remoteFileName))
                                {
                                    sftp.DownloadFile(remoteDirectory + remoteFileName, file1);
                                }
                                bool succes = PrepareFile(remoteFileName);
                            }
                        }
                    }
                }
                Thread.Sleep(900000); // repeat after 15 minutesS
            } while (true);
            
        }

        public static bool PrepareFile(string fileName)
        {
            string newFileLocation = @ConfigurationManager.AppSettings["MyBaseDir"].ToString() + fileName;

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
            
            string fileLocation = @ConfigurationManager.AppSettings["MyBaseDir"].ToString() + fileName +".csv";

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
