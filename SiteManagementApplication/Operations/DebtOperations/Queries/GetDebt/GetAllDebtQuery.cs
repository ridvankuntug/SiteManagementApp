using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt
{
    public class GetAllDebtQuery
    {
        public GetDebtModel Model { get; set; }
        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;

        public bool newPaidCheck;

        public GetAllDebtQuery(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dataBase = dbContext;
            _mapper = mapper;
        }

        public List<GetDebtModel> Handle()
        {
            var debt = newPaidCheck ? 
                _dataBase.Debts.Include(a => a.User).Where(u => u.IsPaid == true).OrderBy(c=> c.DebtId):
                _dataBase.Debts.Include(a => a.User).Where(u => u.IsPaid == false).OrderBy(c => c.DebtId);

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
