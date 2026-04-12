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
#pragma warning disable CS8604 // Possible null reference argument.
                card.CanbanCardCrashType =
                    ExecuteList<CanbanCardCrashType>(
                        "EXEC dbo.CanbanCardCrashType @p0, @p1",
                        card.Id, card.Keys
                    );
#pragma warning restore CS8604 // Possible null reference argument.

                card.CanbanCardSection =
                    ExecuteList<CanbanCardSection>(
                        "EXEC dbo.CanbanCardSection @p0, @p1",
                        card.Id, card.Keys
                    );

                card.CanbanCardStructure =
                    ExecuteList<CanbanCardStructure>(
                        "EXEC dbo.CanbanCardStructure @p0, @p1",
                        card.Id, card.Keys
                    );

                card.CanbanCardWorkOrderType =
                    ExecuteList<CanbanCardWorkOrderType>(
                        "EXEC dbo.CanbanCardWorkOrderType @p0, @p1",
                        card.Id, card.Keys
                    );
            }

            return cards;
        }

        #endregion

        #region Helpers (UserStructureSee ilə EYNİ)

        public List<T>? ExecuteList<T>(string sql, params object[] parameters)
            where T : class
        {
            return _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()   // 🔥 ÇOX VACİB
                       .ToList();
        }

        public T? ExecuteSingle<T>(string sql, params object[] parameters)
            where T : class
        {
            return _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()   // 🔥 ÇOX VACİB
                       .FirstOrDefault();
        }

        public CanbanCardHub? CanbanCardHub(int PageInsert, int t)
        {
            CanbanCardHub? card =
    ExecuteSingle<CanbanCardHub>(
        "EXEC dbo.CanbanCardHub @p0, @p1",
        PageInsert,
        t
    );
            if (card == null)
            {
                return null;
            }
#pragma warning disable CS8604 // Possible null reference argument.
            card.CanbanCardCrashType =
    ExecuteList<CanbanCardCrashType>(
        "EXEC dbo.CanbanCardCrashType @p0, @p1",
                        card.Id, card.Keys
    );
#pragma warning restore CS8604 // Possible null reference argument.

            card.CanbanCardSection =
                ExecuteList<CanbanCardSection>(
                    "EXEC dbo.CanbanCardSection @p0, @p1",
                        card.Id, card.Keys
                );

            card.CanbanCardStructure =
                ExecuteList<CanbanCardStructure>(
                    "EXEC dbo.CanbanCardStructure @p0, @p1",
                        card.Id, card.Keys
                );

            card.CanbanCardWorkOrderType =
                ExecuteList<CanbanCardWorkOrderType>(
                    "EXEC dbo.CanbanCardWorkOrderType @p0, @p1",
                        card.Id, card.Keys
                );
            return card;
        }

        #endregion
    }
}
