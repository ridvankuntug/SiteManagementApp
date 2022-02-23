using AutoMapper;
using SiteManagementDomain.Entities;
using SiteManagementInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Commands.AddDebt
{
    public class AddDebtCommand
    {
        public AddDebtModel Model { get; set; }

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;

        public AddDebtCommand(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        public void Handle()
        {
            var debt = _dataBase.Debts.SingleOrDefault(x =>
                x.DebtPeriod == Model.DebtPeriod &&
                x.User_Id == Model.User_Id);

            if (debt is not null)
            {
                throw new InvalidOperationException("Bu kişi için dönemin fatura ve aidat bilgisi girilmiş");
            }
            else
            {
                debt = _mapper.Map<Debt>(Model);
                _dataBase.Debts.Add(debt);
                _dataBase.SaveChanges();
            }

        }
    }
}
