using AutoMapper;
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

        public GetAllDebtQuery(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dataBase = dbContext;
            _mapper = mapper;
        }

        public List<GetDebtModel> Handle()
        {
            var debt = _dataBase.Debts.Where(u => u.DebtId > 0);
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
