using AutoMapper;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt
{
    public class GetDebtByIdQuery
    {
        public GetDebtModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;
        public bool newPaidChecknewPaidCheck;

        public int newDebtId;
        public bool newPaidCheck;

        public GetDebtByIdQuery(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dataBase = dbContext;
            _mapper = mapper;
        }

        public GetDebtModel Handle()
        {
            var debt = newPaidCheck ?
               _dataBase.Debts.Where(u => u.DebtId == newDebtId && u.IsPaid == false) :
               _dataBase.Debts.Where(u => u.DebtId == newDebtId);
            if (debt is not null)
            {
                GetDebtModel debtObj = _mapper.Map<GetDebtModel>(debt);
                return debtObj;
            }
            else
            {
                throw new InvalidOperationException("Fatura mevcut değil.");
            }

        }
    }
}
