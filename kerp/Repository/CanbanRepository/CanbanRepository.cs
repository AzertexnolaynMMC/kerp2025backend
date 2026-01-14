using kerp.Contexts;
using kerp.Prosedur.Canban;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.CanbanRepository
{
    public class CanbanRepository(KerpContext ctx) : ICanbanRepository
    {
        private readonly KerpContext _ctx = ctx;

        #region Select

        public List<CanbanCard>? GetCanbanCard(CanbanModel PageInsert)
        {
            // Əsas Canban card-ları çəkirik
            List<CanbanCard>? cards = ExecuteList<CanbanCard>(
                "EXEC dbo.CanbanCard @p0, @p1",
                PageInsert.Structure!,
                PageInsert.OrderType!
            );

            if (cards == null || cards.Count == 0)
            {
                return cards;
            }

            // Hər card üçün detail-ləri doldururuq
            foreach (CanbanCard card in cards)
            {
                card.CanbanCardCrashType =
                    ExecuteList<CanbanCardCrashType>(
                        "EXEC dbo.CanbanCardCrashType @p0",
                        card.Id
                    );

                card.CanbanCardSection =
                    ExecuteList<CanbanCardSection>(
                        "EXEC dbo.CanbanCardSection @p0",
                        card.Id
                    );

                card.CanbanCardStructure =
                    ExecuteList<CanbanCardStructure>(
                        "EXEC dbo.CanbanCardStructure @p0",
                        card.Id
                    );

                card.CanbanCardWorkOrderType =
                    ExecuteList<CanbanCardWorkOrderType>(
                        "EXEC dbo.CanbanCardWorkOrderType @p0",
                        card.Id
                    );
            }

            return cards;
        }

        #endregion

        #region Helpers (UserStructureSee ilə EYNİ)

        private List<T>? ExecuteList<T>(string sql, params object[] parameters)
            where T : class
        {
            return _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()   // 🔥 ÇOX VACİB
                       .ToList();
        }

        private T? ExecuteSingle<T>(string sql, params object[] parameters)
            where T : class
        {
            return _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()   // 🔥 ÇOX VACİB
                       .FirstOrDefault();
        }

        #endregion
    }
}
