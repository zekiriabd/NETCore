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
        static string[] SCOPES = { 
            DriveService.Scope.Drive, 
            DriveService.Scope.DriveFile, 
            DriveService.Scope.DriveMetadata, 
            DriveService.Scope.DriveAppdata 
        };

        static  string APPLICATION_NAME = "MyGoogleConnect";
        static string CREDENTIALS_FILE_PATH = "credentials.json";
        static string TOKENS_DIRECTORY_PATH = "token.json";

        private static DriveService service;

        private static UserCredential GetUserCredentials()
        {
            UserCredential result = null;
            try
            {
                using (var stream = new FileStream(CREDENTIALS_FILE_PATH, FileMode.Open, FileAccess.Read))
                {
                    ClientSecrets clientSecrets  = GoogleClientSecrets.Load(stream).Secrets;

                    result = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        clientSecrets,
                        SCOPES,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(TOKENS_DIRECTORY_PATH, true)).Result;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        private static void Getfiles()
        {
            try
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
                            DownloadFile(file.Id);
                    }
                }
                else
                {
                    Console.WriteLine("No files found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void DownloadFile(string fileId)
        {
            try
            {
                var request = service.Files.Get(fileId);
                var stream = new System.IO.MemoryStream();

                request.MediaDownloader.ProgressChanged += (IDownloadProgress progress) =>
                {
                    if (progress.Status == DownloadStatus.Completed)
                    {
                        FileStream file = new FileStream("d:\\zekiri.jpg", FileMode.Create, FileAccess.Write);
                        try
                        {
                            Console.WriteLine("Download complete.");
                            stream.WriteTo(file);
                        }
                        finally
                        {
                            file.Close();
                            stream.Close();
                        }
                    }
                };

                request.Download(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void Main(string[] args)
        {
            try
            {
                UserCredential credential = GetUserCredentials();

                // Create Drive API service.
                service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = APPLICATION_NAME,
                });

                // List files.
                Getfiles();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}