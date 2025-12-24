using kerp.Contexts;
using kerp.Prosedur.Hr.Users;
using kerp.Prosedur.Hr.Users.Mail;
using kerp.Prosedur.Hr.Users.Phone;
using kerp.Prosedur.Hr.Users.Section;
using kerp.Prosedur.Hr.Users.Structur;
using kerp.Prosedur.Hr.Users.User;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.HrRepository.UserRepository
{
    public class UserRepository(KerpContext ctx) : IUserRepository
    {
        private readonly KerpContext _ctx = ctx;

        public List<UserSelectAdmin>? Get()
        {
            return [.. _ctx.UserSelectAdmin
                .FromSqlRaw("EXEC dbo.UserSelectAdmin")
                .AsNoTracking()
            ];
        }

        public List<UserSelectMail>? GetUserSelectMail()
        {
            return [.. _ctx.UserSelectMail
                .FromSqlRaw("EXEC dbo.UserSelectMail")
                .AsNoTracking()
            ];
        }

        public List<UserSelectPhone>? GetUserSelectPhone()
        {
            return [.. _ctx.UserSelectPhone
                .FromSqlRaw("EXEC dbo.UserSelectPhone")
                .AsNoTracking()
            ];
        }

        public List<UserSelectSection>? GetUserSelectSection()
        {
            return [.. _ctx.UserSelectSection
                .FromSqlRaw("EXEC dbo.UserSelectSection")
                .AsNoTracking()
            ];
        }

        public List<UserSelectStructure>? GetUserSelectStructure()
        {
            return [.. _ctx.UserSelectStructure
                .FromSqlRaw("EXEC dbo.UserSelectStructure")
                .AsNoTracking()
            ];
        }

        public InsertUserMailPhoneSelectList? Post(UserInsert PageInsert)
        {
            // 1) User insert (prosedurun param sıra ilə)
            UserSelectAdmin? userRow = _ctx.UserSelectAdmin.FromSqlRaw(
                "EXEC dbo.UserInsert @p0, @p1, @p2, @p3, @p4, @p5, @p6",
                PageInsert.FirstName,
                PageInsert.LastName,
                PageInsert.Position,
                PageInsert.StructureId ?? (object)DBNull.Value,
                PageInsert.SectionId ?? (object)DBNull.Value,
                PageInsert.CanLogin,
                PageInsert.UserId
            ).ToList().FirstOrDefault();

            if (userRow == null)
            {
                return null;
            }

            InsertUserMailPhoneSelectList response = new()
            {
                UserSelectAdmin = userRow,
                UserSelectMail = [],
                UserSelectPhone = []
            };

            // 2) Mail insertlər -> cavabda UserSelectMail listi dolsun
            if (PageInsert.UserInsertMail != null && PageInsert.UserInsertMail.Count > 0)
            {
                foreach (UserInsertMail m in PageInsert.UserInsertMail)
                {
                    UserSelectMail? mailRow = _ctx.UserSelectMail.FromSqlRaw(
                        "EXEC dbo.UserInsertMail @p0, @p1, @p2",
                        m.Title,
                        m.UserId,
                        userRow.Id // yeni yaranan user id
                    ).ToList().FirstOrDefault();

                    if (mailRow != null)
                    {
                        response.UserSelectMail!.Add(mailRow);
                    }
                }
            }

            // 3) Phone insertlər -> cavabda UserSelectPhone listi dolsun
            if (PageInsert.UserInsertPhone != null && PageInsert.UserInsertPhone.Count > 0)
            {
                foreach (UserInsertPhone p in PageInsert.UserInsertPhone)
                {
                    UserSelectPhone? phoneRow = _ctx.UserSelectPhone.FromSqlRaw(
                        "EXEC dbo.UserInsertPhone @p0, @p1, @p2",
                        p.Title,
                        p.UserId,
                        userRow.Id
                    ).ToList().FirstOrDefault();

                    if (phoneRow != null)
                    {
                        response.UserSelectPhone!.Add(phoneRow);
                    }
                }
            }

            return response;
        }

        public UserSelectAdmin? Put(UserUpdate StructureUpdate)
        {
            // Prosedur head:
            // UserUpdate(@FirstName,@LastName,@Position,@StructureId,@SectionId,@CanLogin,@UserId,@Id)
            return _ctx.UserSelectAdmin.FromSqlRaw(
                "EXEC dbo.UserUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7",
                StructureUpdate.FirstName,
                StructureUpdate.LastName,
                StructureUpdate.Position,
                StructureUpdate.StructureId ?? (object)DBNull.Value,
                StructureUpdate.SectionId ?? (object)DBNull.Value,
                StructureUpdate.CanLogin,
                StructureUpdate.UserId,
                StructureUpdate.Id
            ).AsNoTracking().AsEnumerable().FirstOrDefault();
        }

        public UserSelectAdmin? Delete(UserStatus StructureStatus)
        {
            // Prosedur: UserStatus(@Id,@Status,@UserId)
            return _ctx.UserSelectAdmin.FromSqlRaw(
                "EXEC dbo.UserStatus @p0, @p1, @p2",
                StructureStatus.Id,
                StructureStatus.Status,
                StructureStatus.UserId
            ).AsNoTracking().AsEnumerable().FirstOrDefault();
        }

        public UserStatusMail? PostUserInsertMail(UserInsertMail PageInsert)
        {
            // Prosedur: UserInsertMail(@Title,@UserId,@SelectUserId)
            UserSelectMail? row = _ctx.UserSelectMail.FromSqlRaw(
                "EXEC dbo.UserInsertMail @p0, @p1, @p2",
                PageInsert.Title,
                PageInsert.UserId,
                PageInsert.SelectUserId ?? (object)DBNull.Value
            ).AsNoTracking().AsEnumerable().FirstOrDefault();

            return row == null
                ? null
                : new UserStatusMail
                {
                    Id = row.Id,
                    Status = row.Status == true ? 1 : 0,
                    UserId = row.UserId
                };
        }

        public UserStatusMail? PutUserUpdatetMail(UserUpdatetMail StructureUpdate)
        {
            // Prosedur: UserUpdatetMail(@Title,@UserId,@Id)
            UserSelectMail? row = _ctx.UserSelectMail.FromSqlRaw(
                "EXEC dbo.UserUpdatetMail @p0, @p1, @p2",
                StructureUpdate.Title,
                StructureUpdate.UserId,
                StructureUpdate.Id
            ).AsNoTracking().AsEnumerable().FirstOrDefault();

            return row == null
                ? null
                : new UserStatusMail
                {
                    Id = row.Id,
                    Status = row.Status == true ? 1 : 0,
                    UserId = row.UserId
                };
        }

        public UserStatusMail? DeleteUserStatusMail(UserStatusMail StructureStatus)
        {
            // Prosedur: UserStatusMail(@Id,@Status,@UserId)
            UserSelectMail? row = _ctx.UserSelectMail.FromSqlRaw(
                "EXEC dbo.UserStatusMail @p0, @p1, @p2",
                StructureStatus.Id,
                StructureStatus.Status,
                StructureStatus.UserId
            ).AsNoTracking().AsEnumerable().FirstOrDefault();

            return row == null
                ? null
                : new UserStatusMail
                {
                    Id = row.Id,
                    Status = row.Status == true ? 1 : 0,
                    UserId = row.UserId
                };
        }

        public UserSelectPhone? PostUserInsertPhone(UserInsertPhone PageInsert)
        {
            // Prosedur: UserInsertPhone(@Title,@UserId,@SelectUserId)
            return _ctx.UserSelectPhone.FromSqlRaw(
                "EXEC dbo.UserInsertPhone @p0, @p1, @p2",
                PageInsert.Title,
                PageInsert.UserId,
                PageInsert.SelectUserId ?? (object)DBNull.Value
            ).AsNoTracking().AsEnumerable().FirstOrDefault();
        }

        public UserSelectPhone? PutUserUpdatetPhone(UserUpdatetPhone StructureUpdate)
        {
            // Prosedur: UserUpdatetPhone(@Title,@UserId,@Id)
            return _ctx.UserSelectPhone.FromSqlRaw(
                "EXEC dbo.UserUpdatetPhone @p0, @p1, @p2",
                StructureUpdate.Title,
                StructureUpdate.UserId,
                StructureUpdate.Id
            ).AsNoTracking().AsEnumerable().FirstOrDefault();
        }

        public UserSelectPhone? DeleteUserStatusPhone(UserStatus StructureStatus)
        {
            // Prosedur: UserStatusPhone(@Id,@Status,@UserId)
            return _ctx.UserSelectPhone.FromSqlRaw(
                "EXEC dbo.UserStatusPhone @p0, @p1, @p2",
                StructureStatus.Id,
                StructureStatus.Status,
                StructureStatus.UserId
            ).AsNoTracking().AsEnumerable().FirstOrDefault();
        }
    }
}
