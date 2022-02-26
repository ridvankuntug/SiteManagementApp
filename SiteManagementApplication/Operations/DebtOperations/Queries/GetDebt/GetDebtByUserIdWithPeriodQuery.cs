using AutoMapper;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt
{
    public class GetDebtByUserIdWithPeriodQuery
    {
        public GetDebtModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;

        public int newUserId;
        public int newDebtMonth;
        public int newDebtYear;

        public bool newPaidCheck;

        public GetDebtByUserIdWithPeriodQuery(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dataBase = dbContext;
            _mapper = mapper;
        }

        public GetDebtModel Handle()
        {
            var debt = newPaidCheck ? 
                _dataBase.Debts.FirstOrDefault(u => 
                u.User_Id == newUserId && u.DebtMonth == newDebtMonth && u.DebtYear == newDebtYear && 
                u.IsPaid == false) :

                _dataBase.Debts.FirstOrDefault(u => 
                u.User_Id == newUserId && u.DebtMonth == newDebtMonth && u.DebtYear == newDebtYear);

            if (debt is not null)
            {
                GetDebtModel debtObj = _mapper.Map<GetDebtModel>(debt);
                return debtObj;
            }
            else
            { throw new InvalidOperationException("Fatura mevcut değil."); }

        }
    }
}
