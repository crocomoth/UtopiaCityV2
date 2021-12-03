using System;
using System.Collections.Generic;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Business.Dictionaries;

namespace UtopiaCity.Common.SubDbInitializers
{
    public class BusinessInitializer : ISubDbInitializer
    {
        public void ClearSet(AppDbContext context)
        {
            throw new NotImplementedException();
        }

        public void InitializeSet(AppDbContext context)
        {
            SeedCompanyTypes(context);
            SeedCompanyActivities(context);

            context.SaveChanges();
        }

        private void SeedCompanyTypes(AppDbContext context)
        {
            if (context.CompanyTypes.Any())
            {
                return;
            }

            var newCompanyTypes = new List<CompanyType>
            {
                new CompanyType{Title = "Товарищество с ограниченной ответственностью", ShortTitle = "ТОО"},
                new CompanyType{Title = "Индивидуальный предприниматель", ShortTitle = "ИП"},
                new CompanyType{Title = "Закрытое акционерное общество", ShortTitle = "ЗАО"},
                new CompanyType{Title = "Открытое акционерное общество", ShortTitle = "ОАО"},
            };

            context.AddRange(newCompanyTypes);
        }

        private void SeedCompanyActivities(AppDbContext context)
        {

            if (context.CompanyActivities.Any())
            {
                return;
            }

            var newCompanyActivivies = new List<CompanyActivity>
            {
                new CompanyActivity{ Title = "Сельское хозяйство"},
                new CompanyActivity{ Title = "Животноводство"},
                new CompanyActivity{ Title = "Разработка программного обеспечения"},
                new CompanyActivity{ Title = "Безопасность"},
                new CompanyActivity{ Title = "Образование"}
            };

            context.AddRange(newCompanyActivivies);
        }
    }
}
