using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt
{
    public class GetDebtByUserIdQuery
    {
        public GetDebtModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;

        public int newUserId;
        public bool newPaidCheck;

        public GetDebtByUserIdQuery(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dataBase = dbContext;
            _mapper = mapper;
        }

        public List<GetDebtModel> Handle()
        {
            var debt = newPaidCheck ?
                _dataBase.Debts.Include(a => a.User).Where(u => u.User_Id == newUserId && u.IsPaid == false).OrderBy(c => c.DebtId) :
                _dataBase.Debts.Include(a => a.User).Where(u => u.User_Id == newUserId).OrderBy(c => c.DebtId);

            if (debt is not null)
            {
                List<GetDebtModel> debtList = _mapper.Map<List<GetDebtModel>>(debt);
                return debtList;
            }
            else
            {
                throw new InvalidOperationException("Fatura mevcut değil.");
            }

        }
    }
}
