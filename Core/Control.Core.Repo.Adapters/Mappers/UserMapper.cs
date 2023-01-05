using Control.Infrastructure.Domain.Models.DTOs;
using Control.Infrastructure.Repo.DBContext.Models;

namespace Control.Infrastructure.Domain.Models.Mappers
{
    internal static partial class Mapper
    {
        internal static List<UserDTO> MapFromEF(IQueryable<User> datatable) => Apply(datatable, MapFromEF);
        internal static List<UserDTO> MapFromEF(ICollection<User> datatable) => Apply(datatable, MapFromEF);

        internal static List<User> MapToEF(IQueryable<UserDTO> datatable) => Apply(datatable, MapToEF);
        internal static List<User> MapFToEF(ICollection<UserDTO> datatable) => Apply(datatable, MapToEF);

        internal static User MapToEF(UserDTO? model)
        {
            if (model == null) return null;
            User? row = new();
            MapToEF(model, ref row);
            return row;
        }

        internal static void MapToEF(UserDTO? model, ref User? row)
        {
            if (model == null || row == null) return;
            row.Id = model.Id;
            row.Email = model.Email;
            row.Name = model.Name;
        }

        internal static UserDTO? MapFromEF(User? user)
        {
            UserDTO userMapped = new UserDTO();
            userMapped.Id = user.Id;
            userMapped.Name = user.Name;
            userMapped.Email = user.Email;

            return userMapped;
        }
    }
}
