using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Google_Drive_API
{

    class Program
    {
        static string[] Scopes = { 
            DriveService.Scope.Drive, 
            DriveService.Scope.DriveFile, 
            DriveService.Scope.DriveMetadata, 
            DriveService.Scope.DriveAppdata 
        };

        static string ApplicationName = "MyGoogleConnect";
        private static UserCredential GetUserCredential()
        {
            UserCredential result;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                result = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            return result;

        }


        private static void Getfiles(DriveService service)
        {
            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";

            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
            Console.WriteLine("Files:");
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    Console.WriteLine("{0} ({1})", file.Name, file.Id);
                    if (file.Name == "zekiri.jpg")
                        DownloadFile(file.Id, service);
                }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            Console.Read();
        }

        private static void DownloadFile(string fileId, DriveService service)
        {
            var request = service.Files.Get(fileId);
            var stream = new System.IO.MemoryStream();


            request.MediaDownloader.ProgressChanged += (IDownloadProgress progress) =>
            {
                if (progress.Status == DownloadStatus.Completed)
                {
                    Console.WriteLine("Download complete.");
                    FileStream file = new FileStream("d:\\zekiri.jpg", FileMode.Create, FileAccess.Write);
                    stream.WriteTo(file);
                    file.Close();
                    stream.Close();
                }
            };

            request.Download(stream);
        }
        static void Main(string[] args)
        {

            UserCredential credential = GetUserCredential();
            
            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // List files.
              Getfiles(service);
            
        }

    }
}