using kerp.Contexts;
using kerp.Prosedur.Helpers;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.HelperRepository
{
    public class HelperRepository(KerpContext ctx) : IHelperRepository
    {
        private readonly KerpContext _ctx = ctx;
        public List<LoginTypeLang>? LoginTypeLangs()
        {
            return [.. _ctx.LoginTypeLang.FromSqlRaw(
          "EXEC dbo.LoginTypeLang "
          )];
        }
    }
}
//DictionaryLoginTypeLang