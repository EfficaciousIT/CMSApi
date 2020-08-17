using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Threading.Tasks;
using System.Data;
using CMS_WebApi.Models;

namespace CMS_WebApi.Controllers
{
    public class FileUploadController : ApiController
    {
        Database.DB record = new Database.DB();
        public async Task<HttpResponseMessage> Post(string extension,string EventDescription)
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                //Save To this server location
                //var uploadPath = "C:/inetpub/wwwroot/Kolkata/CentralModel/e-SMS1/CentralModelServices/UploadImages/";

                var uploadPath = "D:/UAT/CMS_WebApi/CMS_WebApi/image/";

                //HttpContext.Current.Server.MapPath("~/image");
                string path = uploadPath;
                //The reason we not use the default MultipartFormDataStreamProvider is because
                //the saved file name is look weird, not believe me? uncomment below and try out, 
                //the odd file name is designed for security reason -_-'.
                //var streamProvider = new MultipartFormDataStreamProvider(uploadPath);

                //Save file via CustomUploadMultipartFormProvider
                var multipartFormDataStreamProvider = new CustomUploadMultipartFormProvider(uploadPath, extension);

                // Read the MIME multipart asynchronously 
                await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

                // Show all the key-value pairs.
                foreach (var key in multipartFormDataStreamProvider.FormData.AllKeys)
                {
                    foreach (var val in multipartFormDataStreamProvider.FormData.GetValues(key))
                    {
                        Console.WriteLine(string.Format("{0}: {1}", key, val));
                    }
                }


                //In Case you want to get the files name
                //string localFileName = multipartFormDataStreamProvider
                //    .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();

                DataSet ds = record.GalleryDetail(extension, EventDescription);
                return new HttpResponseMessage(HttpStatusCode.OK);


            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotImplemented)
                {
                    Content = new StringContent(e.Message)
                };
            }

        }

        public async Task<HttpResponseMessage> Post(string extension)
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                //Save To this server location
                //var uploadPath = "D:/Application Live/Kolkata/CentralModel/e-SMS1/CentralModelServices/UploadImages/";
                var uploadPath = "D:/Application Live/Kolkata/CMS_WebApi/CMS_WebApi/image/";
                // HttpContext.Current.Server.MapPath("~/image");
                string path = uploadPath;
              
                var multipartFormDataStreamProvider = new CustomUploadMultipartFormProvider(uploadPath, extension);

                // Read the MIME multipart asynchronously 
                await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

                // Show all the key-value pairs.
                foreach (var key in multipartFormDataStreamProvider.FormData.AllKeys)
                {
                    foreach (var val in multipartFormDataStreamProvider.FormData.GetValues(key))
                    {
                        Console.WriteLine(string.Format("{0}: {1}", key, val));
                    }
                }

                return new HttpResponseMessage(HttpStatusCode.OK);


            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotImplemented)
                {
                    Content = new StringContent(e.Message)
                };
            }

        }
    }
}
