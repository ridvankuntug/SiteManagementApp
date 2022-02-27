using Newtonsoft.Json;
using SiteManagementUi.Models.MessageModels;
using System.Collections.Generic;

namespace SiteManagementUi.Services
{
    public class MessageService
    {
        static string jsonData = "";
        static public List<GetMessageModel> GetAllMessages()
        {
            jsonData = WebApiService.GetAll("Messages/GetAllMessage").Result;
            return JsonConvert.DeserializeObject<List<GetMessageModel>>(jsonData);
        }
        static public List<GetMessageModel> GetMessageByReciverId(int id)
        {
            jsonData = WebApiService.GetAll("Messages/GetMessageByReciver/" + id).Result;
            return JsonConvert.DeserializeObject<List<GetMessageModel>>(jsonData);
        }
        static public List<GetMessageModel> GetMessageBySenderId(int id)
        {
            jsonData = WebApiService.GetAll("Messages/GetMessageBySender/" + id).Result;
            return JsonConvert.DeserializeObject<List<GetMessageModel>>(jsonData);
        }
        static public string ReadMessage(int id)
        {
            GetMessageModel message = null;
            jsonData = WebApiService.Put<GetMessageModel>("Messages/ReadMessage/" + id , message).Result;
            return JsonConvert.DeserializeObject(jsonData).ToString();
        }
        //static public Message GetMessage(int id)
        //{
        //    jsonData = WebApiService.GetSingle("getsingle", id).Result;
        //    return JsonConvert.DeserializeObject<Message>(jsonData);
        //}
        //static public string PostMessage(AddMessageModel message)
        //{
        //    jsonData = WebApiService.Post<AddMessageModel>("Messages/AddMessage", message).Result;
        //    return JsonConvert.DeserializeObject(jsonData).ToString();
        //}
        //static public string PutMessage(string block, int floor, int no, ChangeMessageSenderModel message)
        //{
        //    jsonData = WebApiService.Put<ChangeMessageSenderModel>("Messages/ChangeMessageBy/"+block+"/"+floor+"/"+no , message).Result;
        //    return JsonConvert.DeserializeObject(jsonData).ToString();
        //}
        //static public string Delete(int id)
        //{
        //    jsonData = WebApiService.Delete("delete", id).Result;
        //    return JsonConvert.DeserializeObject(jsonData).ToString();
        //}
    }
}
