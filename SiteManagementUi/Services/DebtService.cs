using Newtonsoft.Json;
using SiteManagementUi.Entities;
using SiteManagementUi.Models.DebtModels;
using System.Collections.Generic;

namespace SiteManagementUi.Services
{
    public class DebtService
    {
        static string jsonData = "";
        static public List<GetAllDebtModel> GetAllDebts(bool paidCheck)
        {
            jsonData = WebApiService.GetAll("Debts/GetAllDebt/" + paidCheck).Result;
            return JsonConvert.DeserializeObject<List<GetAllDebtModel>>(jsonData);
        }
        static public List<GetAllDebtModel> GetAllDebtByPeriod(int debtMonth, int debtYear, bool paidCheck)
        {
            jsonData = WebApiService.GetAll("Debts/GetDebtBy/" + debtMonth + "/" + debtYear + "/" + paidCheck).Result;
            return JsonConvert.DeserializeObject<List<GetAllDebtModel>>(jsonData);
        }
        //static public Debt GetDebt(int id)
        //{
        //    jsonData = WebApiService.GetSingle("getsingle", id).Result;
        //    return JsonConvert.DeserializeObject<Debt>(jsonData);
        //}
        static public string PostDebt(AddDebtToAllModel debt)
        {
            jsonData = WebApiService.Post<AddDebtToAllModel>("Debts/AddDebtToAll", debt).Result;
            return JsonConvert.DeserializeObject(jsonData).ToString();
        }
        //static public string PutDebt(string block, int floor, int no, ChangeDebtSenderModel debt)
        //{
        //    jsonData = WebApiService.Put<ChangeDebtSenderModel>("Debts/ChangeDebtBy/" + block + "/" + floor + "/" + no, debt).Result;
        //    return JsonConvert.DeserializeObject(jsonData).ToString();
        //}
        //static public string Delete(int id)
        //{
        //    jsonData = WebApiService.Delete("delete", id).Result;
        //    return JsonConvert.DeserializeObject(jsonData).ToString();
        //}
    }
}
