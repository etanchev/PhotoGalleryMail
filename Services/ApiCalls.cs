using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;
using PhotoGalleryMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;

namespace PhotoGalleryMail.Services
{
    public class ApiCalls 
    {
        readonly private IHttpClientFactory _clientFactory;
        public ApiCalls(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
           
        }

        public async Task<List<SendGridDbModel>> GetEmails()
        {
            try
            {
                return await _clientFactory.CreateClient("PhotoGalleryMailCoreAPI")
                                       .GetFromJsonAsync<List<SendGridDbModel>>("/SendGridInboundParce");
                
            }
            catch (AccessTokenNotAvailableException exception)
            {
                 exception.Redirect();
                 return null;
            }

        }

        public async Task<SendGridDbModel> GetEmail(int id)
        {
            try
            {
                return  await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                    .GetFromJsonAsync<SendGridDbModel>("/SendGridInboundParce/" + id);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return null;
            }

        }

        public async Task<HttpResponseMessage> DeleteEmail(int id)
        {
            try
            {
                await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                    .DeleteAsync("/SendGridInboundParce/" + id);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            catch
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

        }
        public async Task UpdateEmailRecord(int id, HttpContent content)
        {
            try
            {
                await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                    .PatchAsync("/SendGridInboundParce/" + id , content);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }



        public async Task PostEmail(MailSendModel mail)
        {
            try
            {
                string jsons = JsonSerializer.Serialize(mail).ToString();
                await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                       .PostAsync("/EmailSender", new StringContent(jsons, Encoding.UTF8, "application/json"));


            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();

            }

        }
        public async Task<HttpResponseMessage> PostFiles(HttpContent content)
        {
            try
            {
                return await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                       .PostAsync("/EmailSender/PostFile", content );
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }

        }




        public async Task<EmailSentDbModel[]> GetSentEmails()
        {
            try
            {
                return await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                       .GetFromJsonAsync<EmailSentDbModel[]>("/EmailSender");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return null;
            }

        }
        public async Task<EmailSentDbModel> GetSentEmail(int id)
        {
            try
            {
                return await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                    .GetFromJsonAsync<EmailSentDbModel>("/EmailSender/" + id);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return null;
            }

        }

        public async Task DeleteSentEmail(int id)
        {
            try
            {
                await _clientFactory.CreateClient("PhotoGalleryCoreAPI")
                                    .DeleteAsync("/EmailSender/" + id);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }

        }

       
    }
}
