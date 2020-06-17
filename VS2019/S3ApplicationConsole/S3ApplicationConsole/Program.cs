using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace S3ApplicationConsole
{
    class Program
    {
        //QA Access
        private static string accessKeyID = "XXXXXXXXXXXXXXXXXXXXXX";
        private static string secretKey = "YYYYYYYYYYYYYYYYYYYYYY";
        private static string bucketName = "ZZZZZZZZZZZZZZZZZZZZZ";

        private static readonly string PostDir = @"D:\";
        private static IAmazonS3 service;
        private static bool firstfileisOk = false;

        private static void UserCredential()
        {
            var credentials = new BasicAWSCredentials(accessKeyID, secretKey);
            service = new AmazonS3Client(
                credentials, 
                RegionEndpoint.USEast1
                );
        }

        private static async Task GetFiles()
        {
            try
            {
                ListObjectsV2Request request = new ListObjectsV2Request 
                { 
                    BucketName = bucketName, 
                    MaxKeys = 10 
                };

                ListObjectsV2Response response;
               
                do
                {
                    response = await service.ListObjectsV2Async(request);

                    foreach (S3Object fileobj in response.S3Objects)
                    {
                        string[] filePath = fileobj.Key.Split('/');

                        if (filePath.Count() == 3 && filePath[2].Contains('.'))
                        {
                            string exten = filePath[2].Split('.')[1];
                            Console.WriteLine("key = XXXXXXXXXX.{0} size = {1}", exten, fileobj.Size);

                            if (!firstfileisOk)
                            {
                               // DownloadFile(fileobj.Key).Wait();
                            }
                        }
                    }
                    request.ContinuationToken = response.NextContinuationToken;

                } while (response.IsTruncated);

                Console.ReadKey();
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                Console.WriteLine("S3 error occurred. Exception: " + amazonS3Exception.ToString());
                Console.ReadKey();
            }
        }


        public static async Task DownloadFile(string fileId)
        {
            string localFile = Guid.NewGuid().ToString() + ".csv";
            try
            {
                GetObjectRequest request = new GetObjectRequest() { BucketName = bucketName, Key = fileId };

                GetObjectResponse response = await service.GetObjectAsync(request);

                await response.WriteResponseStreamToFileAsync(Path.Combine(PostDir, localFile), true, CancellationToken.None);

                firstfileisOk = true;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                Console.WriteLine(amazonS3Exception.ToString());
            }

        }

        public static void Main()
        {
            UserCredential();

            GetFiles().Wait();
        }

    }
}