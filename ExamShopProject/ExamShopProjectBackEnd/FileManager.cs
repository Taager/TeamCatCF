using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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


                        if (File.Exists(finalDir + file.Name))
                        {
                            //Console.WriteLine("File " + file.Name + " Exists");
                        }
                        else
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
    }
}
